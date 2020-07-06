using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebPDRSystem.Data;
using WebPDRSystem.Models;

namespace WebPDRSystem.Controllers
{
    public class PDRAPI : ControllerBase
    {
        private readonly WebPDRContext _context;

        public PDRAPI(WebPDRContext context) 
        {
            _context = context;
        }

        public class PdrTime
        {
            public double Time { get; set; }
            public List<Pdr> Pdrs { get; set; }
        }

        [HttpGet]
        [Route("/pdrapi/getusers")]
        public async Task<ActionResult<List<Pdrusers>>> GetUsers()
        {
            var users = await _context.Pdrusers.Where(x => x.Designation == "nursedoc").ToListAsync();

            return users;
        }

        [HttpPost]
        [Route("/pdrapi/saveusers")]
        public async Task<ActionResult> SaveUsers(string urls)
        {
            var url = "https://" + urls + "/pdrapi/getusers";
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    using (var content = response.Content)
                    {
                        var result = await content.ReadAsStringAsync();
                        var root = JsonConvert.DeserializeObject<List<Pdrusers>>(result);
                        /*foreach(var user in root)
                        {
                            user.Id = 0;
                            users.Add(user);
                        }*/
                        _context.UpdateRange(root);

                        await _context.SaveChangesAsync();
                    }
                }
            }

            return Ok();
        }


        [HttpGet]
        [Route("/pdrapi/getpdr")]
        public async Task<ActionResult<List<Pdr>>> GetPdr()
        {
            var start = DateTime.Now;
            var pdrs = await _context.Pdr
                .Include(x => x.PatientNavigation).ThenInclude(x=>x.Medications).ThenInclude(x=>x.SignatureNurseNavigation)
                .Include(x => x.GuardianNavigation)
                .Include(x => x.SymptomsContacts)
                .Include(x => x.DoctorOrders).ThenInclude(x=>x.ListDocOrders)
                .Include(x => x.LabResult)
                .Include(x => x.Qdform).ThenInclude(x=>x.SignatureOfQdNavigation)
                .Include(x => x.Qnform).ThenInclude(x=>x.SignatureOfQnNavigation)
                .Include(x => x.Unusualities)
                .ToListAsync();

            

            var end = DateTime.Now;

            var time = end.Subtract(start).TotalSeconds;

            return pdrs;
        }

        [HttpPost]
        [Route("/pdrapi/savepdr")]
        public async Task<ActionResult> SavePdr(string urls)
        {
            var url = "https://"+urls+"/pdrapi/getpdr";
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    using (var content = response.Content)
                    {
                        var result = await content.ReadAsStringAsync();
                        var root = JsonConvert.DeserializeObject<List<Pdr>>(result);

                        foreach (var item in root)
                        {   
                            item.Id = 0;
                            item.Patient = 0;
                            item.PatientNavigation.Id = 0;
                            item.Guardian = 0;
                            item.GuardianNavigation.Id = 0;
                            item.InterviewedBy = null;
                            if (item.InterviewedByNavigation != null)
                                item.InterviewedByNavigation = await FindUser(item.InterviewedByNavigation);
                            item.SymptomsContactsId = null;
                            if (item.SymptomsContacts != null)
                                item.SymptomsContacts.Id = 0;
                            foreach (var meds in item.PatientNavigation.Medications)
                            {
                                meds.Id = 0;
                                meds.PatientId = 0;
                                meds.SignatureNurse = 0;
                                meds.SignatureNurseNavigation = await FindUser(meds.SignatureNurseNavigation);
                            }
                            foreach (var unusualities in item.Unusualities)
                            {
                                unusualities.Id = 0;
                                unusualities.PdrId = 0;
                            }
                            foreach (var orders in item.DoctorOrders)
                            {
                                orders.Id = 0;
                                foreach (var listorders in orders.ListDocOrders)
                                {
                                    listorders.Id = 0;
                                    listorders.DoctorOrderId = 0;
                                }
                                orders.PdrId = 0;
                                orders.Signature = null;
                                if (orders.SignatureNavigation != null)
                                {
                                    orders.SignatureNavigation = await FindUser(orders.SignatureNavigation);
                                }
                            }
                            foreach (var qd in item.Qdform)
                            {
                                qd.Id = 0;
                                qd.PdrId = 0;
                                qd.SignatureOfQd = 0;
                                qd.SignatureOfQdNavigation = await FindUser(qd.SignatureOfQdNavigation);
                            }
                            foreach (var qn in item.Qnform)
                            {
                                qn.Id = 0;
                                qn.PdrId = 0;
                                qn.SignatureOfQn = 0;
                                qn.SignatureOfQnNavigation = await FindUser(qn.SignatureOfQnNavigation);
                            }
                        }

                        _context.UpdateRange(root);

                        await _context.SaveChangesAsync();
                    }
                }
            }

            return Ok();
        }

        public async Task<Pdrusers> FindUser(Pdrusers user)
        {
            var usr = await _context.Pdrusers.SingleOrDefaultAsync(x =>
                x.Firstname.Equals(user.Firstname) &&
                x.Lastname.Equals(user.Lastname) &&
                x.Initials.Equals(user.Initials) &&
                x.Designation.Equals(user.Designation) &&
                x.Role.Equals(user.Role) &&
                x.Facility.Equals(user.Facility)
                );

            if (usr != null)
                return usr;
            else
            {
                user.Id = 0;
                return user.RemoveLists();
            }
        }
    }
}

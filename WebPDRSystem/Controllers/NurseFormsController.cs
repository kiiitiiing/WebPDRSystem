using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebPDRSystem.Data;
using WebPDRSystem.Models;
using static WebPDRSystem.Controllers.HomeController;

namespace WebPDRSystem.Controllers
{
    public class NurseFormsController : Controller
    {
        private readonly WebPDRContext _context;

        public NurseFormsController(WebPDRContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> AddOrder(int pdrId)
        {
            var pdr = await _context.Pdr
                .Include(x => x.PatientNavigation)
                .Where(x => x.Id == pdrId)
                .FirstOrDefaultAsync();

            var order = new DoctorOrders
            {
                Pdr = pdr,
                PdrId = pdrId,
                DateOrdered = DateTime.Now,
                TimePosted = DateTime.Now,
            };

            ViewBag.Doctors = new SelectList(GetDoctors(), "Id", "Fullname");

            return PartialView(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrder(DoctorOrders model)
        {
            var pdr = await _context.Pdr
                .Include(x => x.PatientNavigation)
                .Where(x => x.Id == model.PdrId)
                .FirstOrDefaultAsync();
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if(ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return PartialView(model);
            }

            ViewBag.Doctors = new SelectList(GetDoctors(), "Id", "Fullname", model.AttendingDoc);

            return PartialView(model);
        }

        #region HELPERS


        public List<SelectUsers> GetDoctors()
        {
            var users = _context.Pdrusers
                .Where(x => x.Team == 1 && x.Role == "Doctor")
                .Select(x => new SelectUsers
                {
                    Id = x.Id,
                    Fullname = x.Firstname + " " + x.Lastname
                });

            return users.ToList();
        }

        #endregion
    }
}
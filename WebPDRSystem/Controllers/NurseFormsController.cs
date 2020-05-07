using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebPDRSystem.Data;
using WebPDRSystem.Models;
using WebPDRSystem.Models.ViewModels;
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

        //var errors = ModelState.Values.SelectMany(v => v.Errors);
        #region VIEW QFN OVERVIEW
        public async Task<IActionResult> QFNOverview(int pdrId)
        {
            var pdr = await _context.Pdr
                .Include(x => x.PatientNavigation)
                .FirstOrDefaultAsync(x => x.Id == pdrId);

            var qfn = await _context.Qnform
                .Include(x=>x.SignatureOfQnNavigation)
                .Where(x => x.PdrId == pdrId)
                .ToListAsync();

            return PartialView(new QFNOverviewModel { PDR = pdr, Qnforms = qfn });
        }
        #endregion

        #region VIEW DOCTORS ORDERS
        public async Task<IActionResult> ViewOrders(int pdrId)
        {
            var pdr = await _context.Pdr.FindAsync(pdrId);
            var orders = await _context.DoctorOrders
                .Include(x => x.Pdr)
                    .ThenInclude(x => x.PatientNavigation)
                .Where(x => x.PdrId == pdrId)
                .OrderByDescending(x => x.DateOrdered)
                .ToListAsync();
            ViewBag.CaseNo = pdr.CaseNumber;
            ViewBag.Nurses = new SelectList(GetNurses(), "Id", "Fullname");

            return PartialView(new ViewOrdersModel { Orders = orders });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ViewOrders(ViewOrdersModel model)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                _context.UpdateRange(model.Orders);
                await _context.SaveChangesAsync();

                return PartialView(model);
            }

            ViewBag.Nurses = new SelectList(GetNurses(), "Id", "Fullname");

            return PartialView(model);
        }
        #endregion

        #region QDFORM OVERVIEW
        
        public async Task<IActionResult> QDFormOverview(int pdrId)
        {
            var qdform = await _context.Qdform
                .Include(x => x.Pdr)
                    .ThenInclude(x => x.PatientNavigation)
                .Include(x => x.SignatureOfQdNavigation)
                .Where(x => x.PdrId == pdrId)
                .ToListAsync();



            return PartialView(qdform);
        }

        #endregion

        #region ADD ORDERS
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
                DateOrdered = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0),
                TimePosted = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0)
            };

            ViewBag.Nurses = new SelectList(GetNurses(), "Id", "Fullname");

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
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return PartialView(model);
            }

            ViewBag.Nurses = new SelectList(GetNurses(), "Id", "Fullname", model.Signature);

            return PartialView(model);
        }
        #endregion

        #region MEDICATIONS

        public async Task<IActionResult> AddMedication(int pdrId)
        {
            var pdr = await _context.Pdr
                .Include(x => x.PatientNavigation)
                .Where(x => x.Id == pdrId)
                .FirstOrDefaultAsync();

            var day = 1;
            var meds = _context.Medications.Where(x => x.PatientId == pdr.Patient);
            if (meds.Count() != 0)
            {
                var singleMed = meds.OrderByDescending(x => x.CreatedAt).FirstOrDefault();
                day = (int)singleMed.Day;
                if (singleMed.CreatedAt.Month <= DateTime.Now.Month && singleMed.CreatedAt.Day < DateTime.Now.Day)
                {
                    day = (int)singleMed.Day + 1;
                }
            }

            var medics = new Medications
            {
                Day = day,
                Patient = pdr.PatientNavigation,
                PatientId = (int)pdr.Patient,
                CreatedAt = DateTime.Now.RemoveSeconds()
            };

            ViewBag.Nurses = new SelectList(GetNurses(), "Id", "Fullname");

            return PartialView(medics);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMedication(Medications model)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                model.MedName = model.MedName.ToUpper();
                _context.Add(model);
                await _context.SaveChangesAsync();

                return PartialView(model);
            }
            ViewBag.Nurses = new SelectList(GetNurses(), "Id", "Fullname", model.SignatureNurse);
            ViewBag.Errors = errors;
            return PartialView(model);
        }

        public async Task<IActionResult> MedicationOverview(int pdrId)
        {
            var meds = await _context.Pdr
                .Include(x => x.PatientNavigation)
                    .ThenInclude(x => x.Medications)
                .Where(x => x.Id == pdrId)
                .FirstOrDefaultAsync();

            var allMeds = await _context.Medications
                .Include(x => x.SignatureNurseNavigation)
                .Where(x => x.PatientId == meds.Patient)
                .Select(x => new MedOverviewModel
                {
                    MedName = x.MedName + x.Dosage.CheckMedParams(":") + x.Route.CheckMedParams(" ") + x.Frequency.CheckMedParams(" "),
                    CreatedAt = x.CreatedAt,
                    Day = x.Day,
                    Comments = x.Comments,
                    Nurse = x.SignatureNurseNavigation.Lastname
                })
                .ToListAsync();

            ViewBag.Patient = meds.PatientNavigation.GetFullName();

            return PartialView(allMeds);
        }

        #endregion

        #region HELPERS


        public List<SelectUsers> GetNurses()
        {
            var users = _context.Pdrusers
                .Where(x => x.Team == 1 && x.Role == "Nurse")
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
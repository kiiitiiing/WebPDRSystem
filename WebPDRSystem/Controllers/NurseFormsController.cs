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
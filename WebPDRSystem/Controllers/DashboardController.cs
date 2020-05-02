using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPDRSystem.Data;
using WebPDRSystem.Models.ViewModels;
using WebPDRSystem.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using static WebPDRSystem.Controllers.HomeController;

namespace WebPDRSystem.Controllers
{
    public class DashboardController : Controller
    {
        private readonly WebPDRContext _context;

        public DashboardController(WebPDRContext context)
        {
            _context = context;
        }

        public IActionResult Census()
        {
            return View();
        }

        public async Task<IActionResult> CensusPartial()
        {
            var today = await _context.Census
                .Include(x => x.OdrNavigation)
                .Include(x => x.OdgNavigation)
                .Include(x => x.QdNavigation)
                .Include(x => x.NodaNavigation)
                .Include(x => x.NodbNavigation)
                .OrderByDescending(x => x.CreatedAt).FirstOrDefaultAsync();

            var census = new DashboardModel
            {
                TotalCensus = await _context.Pdr.Where(x => x.Status == "admitted").CountAsync(),
                CurrBedOccupancy = await _context.Pdr.Where(x => x.Status == "admitted").CountAsync(),
                TotalBedOccupancy = 48,
                MayGoHome = 0,
                ODR = today != null? today.OdrNavigation.GetFullName() : "",
                ODG = today != null ? today.OdgNavigation.GetFullName() : "",
                QD = today != null ? today.QdNavigation.GetFullName() : "",
                NODA = today != null ? today.NodaNavigation.GetFullName() : "",
                NODB = today != null ? today.NodbNavigation.GetFullName() : "",
            };


            return PartialView(census);
        }

        public List<SelectUsers> GetUsers()
        {
            var users = _context.Pdrusers
                .Where(x => x.Team == 1)
                .Where(x => x.Role == "Doctor" || x.Role == "Nurse")
                .Select(x => new SelectUsers
                {
                    Id = x.Id,
                    Fullname = x.Firstname + " " + x.Lastname
                });

            return users.ToList();
        }

        public IActionResult EditCensus()
        {
            ViewBag.ODR = new SelectList(GetUsers(), "Id", "Fullname");
            ViewBag.ODG = new SelectList(GetUsers(), "Id", "Fullname");
            ViewBag.QD = new SelectList(GetUsers(), "Id", "Fullname");
            ViewBag.NODA = new SelectList(GetUsers(), "Id", "Fullname");
            ViewBag.NODB = new SelectList(GetUsers(), "Id", "Fullname");
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCensus(Census model)
        {
            model.CreatedAt = DateTime.Now;
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Census), model);
            }
            ViewBag.Errors = errors;
            ViewBag.ODR = new SelectList(GetUsers(), "Id", "Fullname", model.Odr);
            ViewBag.ODG = new SelectList(GetUsers(), "Id", "Fullname", model.Odg);
            ViewBag.QD = new SelectList(GetUsers(), "Id", "Fullname", model.Qd);
            ViewBag.NODA = new SelectList(GetUsers(), "Id", "Fullname", model.Noda);
            ViewBag.NODB = new SelectList(GetUsers(), "Id", "Fullname", model.Nodb);
            return PartialView(model);
        }

        public IActionResult ImmediateDashboard()
        {
            return View();
        }

        public async Task<IActionResult> ImmediateDashboardPartial()
        {
            var pdr = await _context.Unusualities
                .Include(x => x.Pdr)
                .Where(x => x.Pdr.Attended == true && x.Attended == false)
                .ToListAsync();
            return PartialView(pdr);
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebPDRSystem.Data;
using WebPDRSystem.Models.ViewModels;

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
            var census = new DashboardModel
            {
                TotalCensus = await _context.Pdr.Where(x => x.Status == "admitted").CountAsync(),
                CurrBedOccupancy = await _context.Pdr.Where(x => x.Status == "admitted").CountAsync(),
                TotalBedOccupancy = 48,
                MayGoHome = 0,
                ODR = "Dr. Meme",
                ODG = "Dr. Not Meme",
                QOD = "Dr. Jones",
                NODA = "Mrs. You",
                NODB = "Ms. ing you so much"
            };


            return PartialView(census);
        }

        public IActionResult ImmediateDashboard()
        {
            return View();
        }

        public async Task<IActionResult> ImmediateDashboardPartial()
        {
            var pdr = await _context.Unusualities
                .Include(x => x.Pdr)
                .Where(x => x.Attended == false)
                .ToListAsync();
            return PartialView(pdr);
        }
    }
}
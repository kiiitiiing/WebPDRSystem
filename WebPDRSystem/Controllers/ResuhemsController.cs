using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebPDRSystem.Models;
using WebPDRSystem.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using RequestSizeLimitAttribute = WebPDRSystem.Helpers.RequestSizeLimitAttribute;
using Microsoft.EntityFrameworkCore;

namespace WebPDRSystem.Controllers
{
    [Authorize(Policy = "resuhems")]
    public class ResuhemsController : Controller
    {

        private const uint V = 2147483648;
        private readonly WebPDRContext _context;

        public ResuhemsController( WebPDRContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var patients = await _context.Pdr
                .Include(x => x.PatientNavigation).ThenInclude(x => x.BarangayNavigation)
                .Include(x => x.PatientNavigation).ThenInclude(x => x.MuncityNavigation)
                .Include(x => x.PatientNavigation).ThenInclude(x => x.ProvinceNavigation)
                .Where(x => x.Status == "Admitted")
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();

            return View(patients);
        }

        public IActionResult AddPatient()
        {
            ViewBag.Users = new SelectList(GetDocNurse(), "Id", "Fullname");
            ViewBag.ProvincesP = new SelectList(_context.Province, "Id", "Description", 2);
            ViewBag.MuncityP = new SelectList(_context.Muncity.Where(x => x.ProvinceId == 2), "Id", "Description");
            ViewBag.ProvincesG = new SelectList(_context.Province, "Id", "Description", 2);
            ViewBag.MuncityG = new SelectList(_context.Muncity.Where(x => x.ProvinceId == 2), "Id", "Description");
            return View(new Pdr
            {
                DateOfAdmission = DateTime.Now.RemoveSeconds()
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestSizeLimit(valueCountLimit: 1073741824)]
        public async Task<IActionResult> AddPatient(Pdr model)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            model.Status = "admitted";
            model.CreatedAt = DateTime.Now;
            model.UpdatedAt = DateTime.Now;
            model.PatientNavigation.CreatedAt = DateTime.Now;
            model.PatientNavigation.UpdatedAt = DateTime.Now;
            model.GuardianNavigation.CreatedAt = DateTime.Now;
            model.GuardianNavigation.UpdatedAt = DateTime.Now;
            model.Pdrcode = model.PatientNavigation.Lastname + model.PatientNavigation.Middlename + model.PatientNavigation.Firstname + model.CreatedAt.ToString("ddMMyyyyHHmm");
            model.GuardianNavigation.Address = "";
            //model.PatientNavigation.Picture = SavePicture(model.PatientNavigation.Firstname + model.PatientNavigation.Lastname, model.PatientNavigation.Picture);
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index),model);
            }
            ViewBag.ProvincesP = new SelectList(_context.Province, "Id", "Description", model.PatientNavigation.Province);
            ViewBag.MuncityP = new SelectList(_context.Muncity.Where(x => x.ProvinceId == 2), "Id", "Description", model.PatientNavigation.Muncity);
            ViewBag.ProvincesG = new SelectList(_context.Province, "Id", "Description", model.GuardianNavigation.Province);
            ViewBag.MuncityG = new SelectList(_context.Muncity.Where(x => x.ProvinceId == 2), "Id", "Description", model.GuardianNavigation.Muncity);
            if (model.PatientNavigation.Barangay != null)
            {
                ViewBag.BarangayP = new SelectList(_context.Barangay.Where(x => x.ProvinceId == model.PatientNavigation.Province && x.MuncityId == model.PatientNavigation.Muncity), "Id", "Description", model.PatientNavigation.Barangay);
            }

            if (model.GuardianNavigation.Barangay != null)
            {
                ViewBag.BarangayG = new SelectList(_context.Barangay.Where(x => x.ProvinceId == model.GuardianNavigation.Province && x.MuncityId == model.GuardianNavigation.Muncity), "Id", "Description", model.GuardianNavigation.Barangay);
            }
            ViewBag.Errors = errors;
            return View(model);
        }


        public partial class SelectUsers
        {
            public int Id { get; set; }
            public string Fullname { get; set; }
        }
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

        public List<SelectUsers> Gethcb()
        {
            var users = _context.Pdrusers
                .Where(x => x.Team == 1 && x.Role == "Healthcare Buddy")
                .Select(x => new SelectUsers
                {
                    Id = x.Id,
                    Fullname = x.Firstname + " " + x.Lastname
                });

            return users.ToList();
        }
        public List<SelectUsers> GetDocNurse()
        {
            var users = _context.Pdrusers
                .Where(x => x.Team == 1 && x.Role != "Healthcare Buddy")
                .Select(x => new SelectUsers
                {
                    Id = x.Id,
                    Fullname = x.Role == "Doctor" ? "Dr. " + x.Firstname + " " + x.Lastname : x.Firstname + " " + x.Lastname
                });

            return users.ToList();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebPDRSystem.Models;
using WebPDRSystem.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Drawing;
using Microsoft.EntityFrameworkCore;

namespace WebPDRSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WebPDRContext _context;

        public HomeController(ILogger<HomeController> logger, WebPDRContext context)
        {
            _context = context;
            _logger = logger;
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }

        public async Task<IActionResult> DashboardPartial( string search)
        {
            var pdrs = _context.Pdr
                .Include(x => x.PatientNavigation).ThenInclude(x => x.MuncityNavigation)
                .Include(x => x.SymptomsContacts);
            ViewBag.Total = pdrs.Count();

            return PartialView(await pdrs.ToListAsync());
        }

        public IActionResult QNForm()
        {
            return PartialView("~/Views/Home/_QNForm.cshtml");
        }
        public IActionResult QDForm()
        {
            return PartialView("~/Views/Home/_QDForm.cshtml");
        }

        public partial class SelectUsers
        {
            public int Id { get; set; }
            public String Fullname { get; set; }
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

        public async Task<IActionResult> PDRModal(int id)
        {
            var pdr = await _context.Pdr
                .Include(x => x.PatientNavigation)
                .Include(x => x.GuardianNavigation)
                .Include(x => x.SymptomsContacts).SingleOrDefaultAsync(x=>x.Id == id);


            ViewBag.ProvincesP = new SelectList(_context.Province, "Id", "Description", pdr.PatientNavigation.Province);
            ViewBag.MuncityP = new SelectList(_context.Muncity.Where(x => x.ProvinceId == pdr.PatientNavigation.Province), "Id", "Description", pdr.PatientNavigation.Muncity);
            ViewBag.BarangayP = new SelectList(_context.Barangay.Where(x => x.ProvinceId == pdr.PatientNavigation.Province && x.MuncityId == pdr.PatientNavigation.Muncity), "Id", "Description", pdr.PatientNavigation.Barangay);
            ViewBag.ProvincesG = new SelectList(_context.Province, "Id", "Description", pdr.GuardianNavigation.Province);
            ViewBag.MuncityG = new SelectList(_context.Muncity.Where(x => x.ProvinceId == pdr.GuardianNavigation.Province), "Id", "Description", pdr.GuardianNavigation.Muncity);
            ViewBag.BarangayG = new SelectList(_context.Barangay.Where(x => x.ProvinceId == pdr.GuardianNavigation.Province && x.MuncityId == pdr.GuardianNavigation.Muncity), "Id", "Description", pdr.GuardianNavigation.Barangay);


            return PartialView(pdr);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PDRModal(Pdr model)
        {
            var user = _context.Patient.Find(model.PatientNavigation.Id);
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                if (user.Picture != model.PatientNavigation.Picture)
                    model.PatientNavigation.Picture = SavePicture(model.PatientNavigation.Firstname + model.PatientNavigation.Lastname, model.PatientNavigation.Picture);
                model.Pdrcode = model.PatientNavigation.Lastname + model.PatientNavigation.Middlename + model.PatientNavigation.Firstname + model.DateOfAdmission.ToString();
                model.UpdatedAt = DateTime.Now;
                model.PatientNavigation.UpdatedAt = DateTime.Now;
                model.GuardianNavigation.UpdatedAt = DateTime.Now;
                try
                {
                    var entity = _context.Pdr.FirstOrDefault(x=>x.Id==model.Id);
                    _context.Entry(entity).CurrentValues.SetValues(model);
                    await _context.SaveChangesAsync();
                }
                catch(Exception e)
                {
                    var sqlErrors = e;
                }

                return RedirectToAction(nameof(Dashboard));
            }

            ViewBag.ProvincesP = new SelectList(_context.Province, "Id", "Description", model.PatientNavigation.Province);
            ViewBag.MuncityP = new SelectList(_context.Muncity.Where(x => x.ProvinceId == model.PatientNavigation.Province), "Id", "Description", model.PatientNavigation.Muncity);
            ViewBag.BarangayP = new SelectList(_context.Barangay.Where(x => x.ProvinceId == model.PatientNavigation.Province && x.MuncityId == model.PatientNavigation.Muncity), "Id", "Description", model.PatientNavigation.Barangay);
            ViewBag.ProvincesG = new SelectList(_context.Province, "Id", "Description", model.GuardianNavigation.Province);
            ViewBag.MuncityG = new SelectList(_context.Muncity.Where(x => x.ProvinceId == model.GuardianNavigation.Province), "Id", "Description", model.GuardianNavigation.Muncity);
            ViewBag.BarangayG = new SelectList(_context.Barangay.Where(x => x.ProvinceId == model.GuardianNavigation.Province && x.MuncityId == model.GuardianNavigation.Muncity), "Id", "Description", model.GuardianNavigation.Barangay);

            return PartialView(model);
        }


        public IActionResult AddPatient()
        {
            ViewBag.Users = new SelectList(GetDocNurse(), "Id", "Fullname");
            ViewBag.ProvincesP = new SelectList(_context.Province, "Id", "Description", 2);
            ViewBag.MuncityP = new SelectList(_context.Muncity.Where(x => x.ProvinceId == 2), "Id", "Description");
            ViewBag.ProvincesG = new SelectList(_context.Province, "Id", "Description", 2);
            ViewBag.MuncityG = new SelectList(_context.Muncity.Where(x => x.ProvinceId == 2), "Id", "Description");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPatient( Pdr model)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            model.Pdrcode = model.PatientNavigation.Lastname + model.PatientNavigation.Middlename + model.PatientNavigation.Firstname + model.DateOfAdmission.ToString();
            model.CreatedAt = DateTime.Now;
            model.UpdatedAt = DateTime.Now;
            model.PatientNavigation.CreatedAt = DateTime.Now;
            model.PatientNavigation.UpdatedAt = DateTime.Now;
            model.GuardianNavigation.CreatedAt = DateTime.Now;
            model.GuardianNavigation.UpdatedAt = DateTime.Now;
            model.GuardianNavigation.Address = "";
            model.PatientNavigation.Picture = SavePicture(model.PatientNavigation.Firstname + model.PatientNavigation.Lastname, model.PatientNavigation.Picture);
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
            }
            ViewBag.ProvincesP = new SelectList(_context.Province, "Id", "Description", model.PatientNavigation.Province);
            ViewBag.MuncityP = new SelectList(_context.Muncity.Where(x => x.ProvinceId == 2), "Id", "Description", model.PatientNavigation.Muncity);
            ViewBag.ProvincesG = new SelectList(_context.Province, "Id", "Description", model.GuardianNavigation.Province);
            ViewBag.MuncityG = new SelectList(_context.Muncity.Where(x => x.ProvinceId == 2), "Id", "Description", model.GuardianNavigation.Muncity);

            return RedirectToAction(nameof(Dashboard));
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region HELPERS
        public string SavePicture(string name, string base64)
        {
            string imageName = Guid.NewGuid() + name + ".jpg";
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", imageName);

            string cleanData = base64.Replace("data:image/jpeg;base64,", "");
            try
            {
                byte[] data = Convert.FromBase64String(cleanData);
                MemoryStream ms = new MemoryStream(data);
                Image img = Image.FromStream(ms);
                img.Save(imagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                return imageName;
            }
            catch
            {
                return base64;
            }
        }
        #endregion
    }
}

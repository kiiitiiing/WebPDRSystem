using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebPDRSystem;
using WebPDRSystem.Models;
using WebPDRSystem.Data;
using WebPDRSystem.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System.Drawing;
using Microsoft.EntityFrameworkCore;
using RequestSizeLimitAttribute = WebPDRSystem.Helpers.RequestSizeLimitAttribute;
using WebPDRSystem.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace WebPDRSystem.Controllers
{
    [Authorize(Policy = "nursedoc")]
    public class HomeController : Controller
    {
        private const uint V = 2147483648;
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

        public async Task<IActionResult> Attention(int id)
        {
            var pdr = await _context.Pdr
                .Include(x => x.PatientNavigation)
                .Where(x => x.Id == id).FirstOrDefaultAsync();

            var attention = new Unusualities
            {
                Pdr = pdr,
                PdrId = id
            };
            return PartialView(attention);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Attention(Unusualities model)
        {
            model.Pdr = await _context.Pdr.FindAsync(model.PdrId);
            model.CreatedAt = DateTime.Now;
            model.UpdatedAt = DateTime.Now;
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return PartialView(model);
            }


            ViewBag.Errors = errors;
            return PartialView(model);
        }

        public async Task<IActionResult> DashboardPartial( string search)
        {
            var pdrs = _context.Pdr
                .Where(x => x.Status == "admitted")
                .Include(x => x.PatientNavigation).ThenInclude(x => x.MuncityNavigation)
                .Include(x => x.SymptomsContacts)
                .Include(x => x.Qnform)
                .Include(x => x.Qdform)
                .AsQueryable();

            if(!string.IsNullOrEmpty(search))
            {
                pdrs = pdrs.Where(x => x.PatientNavigation.Firstname.Contains(search) || x.PatientNavigation.Lastname.Contains(search));
            }

            ViewBag.Total = pdrs.Count();

            return PartialView(await pdrs.ToListAsync());
        }

        #region QN FORM

        public async Task<IActionResult> UpdateQnForm(int id)
        {
            var form = await _context.Qnform
                .Include(x => x.Pdr)
                    .ThenInclude(x => x.PatientNavigation)
                .FirstOrDefaultAsync(x => x.Id == id);

            ViewBag.Nurses = new SelectList(GetNurses(), "Id", "Fullname",form.SignatureOfQn);
            return PartialView(form);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateQnForm(Qnform model)
        {

            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                var form = await _context.Qnform
                    .FirstOrDefaultAsync(x => x.Id == model.Id);

                _context.Entry(form).CurrentValues.SetValues(model);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Dashboard));
            }

            ViewBag.Nurses = new SelectList(GetNurses(), "Id", "Fullname", model.SignatureOfQn);
            return PartialView(model);
        }


        public IActionResult QNForm(int id)
        {
            var pdr = _context.Pdr
                .Include(x => x.PatientNavigation)
                    .ThenInclude(x=>x.Medications)
                .SingleOrDefault(x => x.Id == id);
            ViewBag.Nurses = new SelectList(GetNurses(), "Id", "Fullname");

            var form = new QnformModel
            {
                PdrId = pdr.Id,
                PatientCode = pdr.Pdrcode,
                Patientname = pdr.PatientNavigation.Firstname+" "+ pdr.PatientNavigation.Middlename + " " + pdr.PatientNavigation.Lastname,
                DateChecked = DateTime.Now,
                Medications = new List<Medications>(),
                PatientId = (int)pdr.Patient
            };

            return PartialView(form);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QNForm(QnformModel model)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                var pdr = _context.Pdr.Find(model.PdrId);
                if(model.Medications != null)
                {
                    _context.AddRange(AddMedication(model));
                }
                pdr.UpdatedAt = DateTime.Now;
                var qnform = SetQNForm(model);
                _context.UpdateRange(pdr, qnform);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Dashboard));
            }

            ViewBag.Nurses = new SelectList(GetNurses(), "Id", "Fullname",model.SignatureOfQn);
            ViewBag.Errors = errors;
            return PartialView(model);
        }

        public List<Medications> AddMedication(QnformModel model)
        {
            foreach(var item in model.Medications)
            {
                item.PatientId = model.PatientId;
                item.CreatedAt = model.DateChecked;
            }

            return model.Medications;
        }

        public Qnform SetQNForm(QnformModel model)
        {
            var qnform = new Qnform
            {
                DateChecked = model.DateChecked,
                Bp = model.Bp,
                Hr = model.Hr,
                Rr = model.Rr,
                O2sat = model.O2sat,
                Ivrate = model.Ivrate,
                TypeOfFluid = model.TypeOfFluid,
                TimeFluidStarted = model.TimeFluidStarted,
                TimeFluidChanged = model.TimeFluidChanged,
                UrineOutput = model.UrineOutput,
                Meds = model.Meds,
                Enumerate = model.Enumerate,
                PdrId = model.PdrId,
                OtherDetails = model.OtherDetails,
                SignatureOfQn = model.SignatureOfQn,
                PatientCode = model.PatientCode,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            return qnform;
        }
        #endregion
        #region QD FORM
        public IActionResult QDForm(int id)
        {
            var pdr = _context.Pdr.Include(x=>x.PatientNavigation).SingleOrDefault(x => x.Id == id);
            ViewBag.HCBuddies = new SelectList(Gethcb(), "Id", "Fullname");
            ViewBag.Doctors = new SelectList(GetDoctors(), "Id", "Fullname");

            var form = new QdformModel
            {
                PdrId = pdr.Id,
                PatientName = pdr.PatientNavigation.Firstname + " " + pdr.PatientNavigation.Middlename + " " + pdr.PatientNavigation.Lastname,
                Pdrcode = pdr.Pdrcode,
                DateChecked = DateTime.Now
            };

            return PartialView(form);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QDForm(QdformModel model)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if(ModelState.IsValid)
            {
                /*var pdr = _context.Pdr.Find(model.PdrId);
                pdr.Qdform.Add(AddQdForm(model));
                pdr.UpdatedAt = DateTime.Now;*/
                //var form = AddQdForm(model);
                //_context.Update(pdr);
                _context.Add(AddQdForm(model));
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Dashboard));
            }
            ViewBag.HCBuddies = new SelectList(Gethcb(), "Id", "Fullname", model.HealthCareBuddy);
            ViewBag.Doctors = new SelectList(GetDoctors(), "Id", "Fullname",model.SignatureOfQd);
            ViewBag.Errors = errors;
            return PartialView(model);
        }

        public Qdform AddQdForm(QdformModel model)
        {
            var form = new Qdform
            {
                Pdrcode = model.Pdrcode,
                HealthCareBuddy = model.HealthCareBuddy,
                Fever = model.Fever,
                DateChecked = model.DateChecked,
                Temperature = model.Temperature,
                Cough = model.Cough,
                Colds = model.Colds,
                Breathing = model.Breathing,
                BodyMuscleJointPain = model.BodyMuscleJointPain,
                Headache = model.Headache,
                ChestPain = model.ChestPain,
                Confusion = model.Confusion,
                BluishLips = model.BluishLips,
                BluishFingers = model.BluishFingers,
                Maintenance = model.Maintenance,
                MedsTaken = model.MedsTaken,
                MentalDistress = model.MentalDistress,
                SoreThroat = model.SoreThroat,
                Diarrhea = model.Diarrhea,
                OtherDetails = model.OtherDetails,
                SignatureOfQd = model.SignatureOfQd,
                PdrId = model.PdrId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            return form;
        }
        #endregion


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
        [RequestSizeLimit(valueCountLimit: 1073741824)]
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
                    var patient = _context.Patient.FirstOrDefault(x => x.Id == model.Patient);
                    var guardian = _context.Guardian.FirstOrDefault(x => x.Id == model.Guardian);
                    var symptoms = _context.SymptomsContacts.FirstOrDefault(x => x.Id == model.SymptomsContactsId);
                    _context.Entry(entity).CurrentValues.SetValues(model);
                    _context.Entry(patient).CurrentValues.SetValues(model.PatientNavigation);
                    _context.Entry(guardian).CurrentValues.SetValues(model.GuardianNavigation);
                    _context.Entry(symptoms).CurrentValues.SetValues(model.SymptomsContacts);
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
            //ViewBag.BarangayP = new SelectList(_context.Barangay.Where(x => x.ProvinceId == model.PatientNavigation.Province && x.MuncityId == model.PatientNavigation.Muncity), "Id", "Description", model.PatientNavigation.Barangay);
            ViewBag.ProvincesG = new SelectList(_context.Province, "Id", "Description", model.GuardianNavigation.Province);
            ViewBag.MuncityG = new SelectList(_context.Muncity.Where(x => x.ProvinceId == model.GuardianNavigation.Province), "Id", "Description", model.GuardianNavigation.Muncity);
            //ViewBag.BarangayG = new SelectList(_context.Barangay.Where(x => x.ProvinceId == model.GuardianNavigation.Province && x.MuncityId == model.GuardianNavigation.Muncity), "Id", "Description", model.GuardianNavigation.Barangay);
            if (model.PatientNavigation.Barangay != null)
            {
                ViewBag.BarangayP = new SelectList(_context.Barangay.Where(x => x.ProvinceId == model.PatientNavigation.Province && x.MuncityId == model.PatientNavigation.Muncity), "Id", "Description", model.PatientNavigation.Barangay);
            }

            if (model.GuardianNavigation.Barangay != null)
            {
                ViewBag.BarangayG = new SelectList(_context.Barangay.Where(x => x.ProvinceId == model.GuardianNavigation.Province && x.MuncityId == model.GuardianNavigation.Muncity), "Id", "Description", model.GuardianNavigation.Barangay);
            }

            ViewBag.Errors = errors;
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
        [RequestSizeLimit(valueCountLimit: 1073741824)]
        public async Task<IActionResult> AddPatient( Pdr model)
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
                return RedirectToAction(nameof(Dashboard));
            }
            ViewBag.ProvincesP = new SelectList(_context.Province, "Id", "Description", model.PatientNavigation.Province);
            ViewBag.MuncityP = new SelectList(_context.Muncity.Where(x => x.ProvinceId == 2), "Id", "Description", model.PatientNavigation.Muncity);
            ViewBag.ProvincesG = new SelectList(_context.Province, "Id", "Description", model.GuardianNavigation.Province);
            ViewBag.MuncityG = new SelectList(_context.Muncity.Where(x => x.ProvinceId == 2), "Id", "Description", model.GuardianNavigation.Muncity);
            if(model.PatientNavigation.Barangay != null)
            {
                ViewBag.BarangayP = new SelectList(_context.Barangay.Where(x=>x.ProvinceId == model.PatientNavigation.Province && x.MuncityId == model.PatientNavigation.Muncity), "Id", "Description", model.PatientNavigation.Barangay);
            }

            if(model.GuardianNavigation.Barangay != null)
            {
                ViewBag.BarangayG = new SelectList(_context.Barangay.Where(x => x.ProvinceId == model.GuardianNavigation.Province && x.MuncityId == model.GuardianNavigation.Muncity), "Id", "Description", model.GuardianNavigation.Barangay);
            }
            ViewBag.Errors = errors;
            return View(model);
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> DischargeForm(int id)
        {
            var pdr = await _context.Pdr
                .Include(x => x.PatientNavigation).ThenInclude(x=>x.ProvinceNavigation)
                .Include(x => x.PatientNavigation).ThenInclude(x => x.MuncityNavigation)
                .Include(x => x.PatientNavigation).ThenInclude(x => x.BarangayNavigation)
                .FirstOrDefaultAsync(x => x.Id == id);



            var discharge = new Discharge
            {
                Pdr = pdr,
                Pdrid = pdr.Id,
                DateDischarged = DateTime.Now
            };

            return PartialView(discharge);
        }

        public async Task<IActionResult> ReferralForm(int id)
        {
            var pdr = await _context.Pdr
                .Include(x => x.PatientNavigation).ThenInclude(x => x.ProvinceNavigation)
                .Include(x => x.PatientNavigation).ThenInclude(x => x.MuncityNavigation)
                .Include(x => x.PatientNavigation).ThenInclude(x => x.BarangayNavigation)
                .Include(x => x.GuardianNavigation)
                .FirstOrDefaultAsync(x => x.Id == id);

            var refer = new Referral
            {
                Pdr = pdr,
                Pdrid = pdr.Id
                
            };

            return PartialView(refer);

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region HELPERS
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
        #endregion
    }
}

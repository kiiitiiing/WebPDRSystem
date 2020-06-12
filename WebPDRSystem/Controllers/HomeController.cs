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
using System.Security.Claims;

namespace WebPDRSystem.Controllers
{
    [Authorize(Policy = "nursedoc")]
    public class HomeController : Controller
    {
        private const uint V = 2147483648;
        private readonly ILogger<HomeController> _logger;
        private readonly WebPDRContext _context;
        
        //var errors = ModelState.Values.SelectMany(v => v.Errors);
        public HomeController(ILogger<HomeController> logger, WebPDRContext context)
        {
            _context = context;
            _logger = logger;
        }

        public partial class SelectDates
        {
            public int Id { get; set; }
            public string DateChecked { get; set; }
        }



        #region DASHBOARD

        [HttpGet]
        [Route("WPDRS/Home/PatientsJson")]
        [Route("WPDRS/Home/PatientsJson/{q}")]
        public async Task<ActionResult<IEnumerable<Pdr>>> PatientsJson(string q)
        {
            var pdrs = await _context.Pdr
                .Where(x => x.Status == "admitted")
                .Include(x => x.PatientNavigation).ThenInclude(x => x.MuncityNavigation)
                .Include(x => x.PatientNavigation).ThenInclude(x => x.Medications)
                .Include(x => x.SymptomsContacts)
                .Include(x => x.Qnform)
                .Include(x => x.Qdform)
                .Where(x=>x.QuarantineFacility == UserFacility)
                .OrderByDescending(x => x.CreatedAt)
                .ToListAsync();

            if (!string.IsNullOrEmpty(q))
            {
                pdrs = pdrs.Where(x => x.PatientNavigation.Firstname.Contains(q, StringComparison.OrdinalIgnoreCase) || x.PatientNavigation.Lastname.Contains(q, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return pdrs;
        }

        public IActionResult Dashboard()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DashboardPartial([FromBody] IEnumerable<Pdr> model)
        {
            return PartialView(model);
        }

        #endregion

        #region ATTENDED

        public void Attended(int id)
        {
            var pdr = _context.Pdr.Find(id);
            var unus = _context.Unusualities.Where(x => x.PdrId == id).OrderByDescending(x => x.CreatedAt).FirstOrDefault();
            pdr.Attended = false;
            unus.Attended = true;
            _context.UpdateRange(pdr, unus);
            _context.SaveChanges();
        }

        #endregion

        #region ATTENTION

        public async Task<IActionResult> Attention(int pdrId)
        {
            var pdr = await _context.Pdr
                .Include(x => x.PatientNavigation)
                .Where(x => x.Id == pdrId).FirstOrDefaultAsync();

            Unusualities attention = null;

            if (pdr.Attended)
            {
                attention = await _context.Unusualities.Where(x => x.PdrId == pdr.Id).OrderByDescending(x => x.CreatedAt).FirstOrDefaultAsync();
            }
            else
            {
                attention = new Unusualities
                {
                    Pdr = pdr,
                    PdrId = pdrId
                };
            }
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
                model.Pdr.Attended = true;
                model.Attended = false;
                _context.Update(model);
                await _context.SaveChangesAsync();
                return PartialView(model);
            }


            ViewBag.Errors = errors;
            return PartialView(model);
        }


        #endregion

        #region QN FORM

        public async Task<IActionResult> UpdateQnForm(int pisti, int? formId)
        {
            if (formId == null)
            {
                var form = await _context.Qnform
                    .Include(x => x.Pdr)
                        .ThenInclude(x => x.PatientNavigation)
                    .FirstOrDefaultAsync(x => x.Id == pisti);
                ViewBag.Patient = form.Pdr.PatientNavigation.GetFullName();
                var dates = _context.Qnform
                    .Where(x => x.PdrId == form.PdrId)
                    .Select(x => new SelectDates
                    {
                        Id = x.Id,
                        DateChecked = x.DateChecked.ToString("dd/MM/yyyy hh:mm tt", System.Globalization.CultureInfo.InvariantCulture)
                    });

                ViewBag.Dates = new SelectList(dates, "Id", "DateChecked", form.Id);
                ViewBag.Nurses = new SelectList(GetNurses(), "Id", "Fullname", form.SignatureOfQn);
                return PartialView(form);
            }
            else
            {
                var form = await _context.Qnform
                    .Include(x => x.Pdr)
                        .ThenInclude(x => x.PatientNavigation)
                    .FirstOrDefaultAsync(x => x.Id == formId);
                ViewBag.Patient = form.Pdr.PatientNavigation.GetFullName();
                var dates = _context.Qnform
                    .Where(x => x.PdrId == form.PdrId)
                    .Select(x => new SelectDates
                    {
                        Id = x.Id,
                        DateChecked = x.DateChecked.ToString("dd/MM/yyyy hh:mm tt", System.Globalization.CultureInfo.InvariantCulture)
                    });

                ViewBag.Dates = new SelectList(dates, "Id", "DateChecked", form.Id);
                ViewBag.Nurses = new SelectList(GetNurses(), "Id", "Fullname", form.SignatureOfQn);
                return PartialView(form);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateQnForm(Qnform model)
        {
            ViewBag.Patient = _context.Pdr.Include(x => x.PatientNavigation).FirstOrDefault(x => x.Id == model.PdrId).PatientNavigation.GetFullName();
            if (ModelState.IsValid)
            {
                _context.Update(model);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Dashboard));
            }

            ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors);
            ViewBag.Nurses = new SelectList(GetNurses(), "Id", "Fullname", model.SignatureOfQn);
            return PartialView(model);
        }


        public IActionResult QNForm(int pdrId)
        {
            var pdr = _context.Pdr
                .Include(x => x.PatientNavigation)
                .SingleOrDefault(x => x.Id == pdrId);
            ViewBag.Nurses = new SelectList(GetNurses(), "Id", "Fullname");

            var qnforms = _context.Qnform
                .Where(x => x.PdrId == pdrId);

            var day = 1;

            if (qnforms.Count() != 0)
            {
                var latest = qnforms.OrderByDescending(x => x.DateChecked).FirstOrDefault();
                if (latest.DateChecked.Hour > 16 && latest.DateChecked.Hour <= 23)
                    day = (int)latest.Day + 1;
                else
                    day = (int)latest.Day;
            }

            ViewBag.Patientname = pdr.PatientNavigation.GetFullName();

            var form = new Qnform
            {
                PdrId = pdrId,
                PatientCode = pdr.Pdrcode,
                DateChecked = DateTime.Now.RemoveSeconds(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Day = day
        }   ;

            return PartialView(form);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QNForm(Qnform model)
        {
            var pdr = await _context.Pdr.Include(x => x.PatientNavigation).FirstOrDefaultAsync(x => x.Id == model.PdrId);

            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                _context.Update(model);
                await _context.SaveChangesAsync();
                return PartialView(model);
            }
            ViewBag.Errors = errors;
            ViewBag.Patientname = pdr.PatientNavigation.GetFullName();
            ViewBag.Nurses = new SelectList(GetNurses(), "Id", "Fullname", model.SignatureOfQn);
            return PartialView(model);
        }

        #endregion

        #region QD FORM
        public IActionResult QDForm(int pdrId)
        {
            var pdr = _context.Pdr.Include(x => x.PatientNavigation).SingleOrDefault(x => x.Id == pdrId);
            //ViewBag.HCBuddies = new SelectList(Gethcb(), "Id", "Fullname");
            ViewBag.Doctors = new SelectList(GetDoctors(), "Id", "Fullname");

            var form = new Qdform
            {
                Pdr = pdr,
                PdrId = pdr.Id,
                Day = 1,
                Pdrcode = pdr.Pdrcode,
                DateChecked = DateTime.Now.RemoveSeconds()
            };

            return PartialView(form);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QDForm(Qdform model)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                var pdr = _context.Pdr.Find(model.PdrId);
                pdr.UpdatedAt = DateTime.Now;
                _context.UpdateRange(model,pdr);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Dashboard));
            }
            ViewBag.HCBuddies = new SelectList(Gethcb(), "Id", "Fullname", model.HealthCareBuddy);
            ViewBag.Doctors = new SelectList(GetDoctors(), "Id", "Fullname", model.SignatureOfQd);
            ViewBag.Errors = errors;
            return PartialView(model);
        }

        public Qdform AddQdForm(QdformModel model)
        {
            var form = new Qdform
            {
                Pdrcode = model.Pdrcode,
                //HealthCareBuddy = model.HealthCareBuddy,
                Fever = model.Fever,
                DateChecked = model.DateChecked,
                Temperature = model.Temperature,
                Cough = model.Cough,
                Breathing = model.Breathing,
                BodyPain = model.BodyMuscleJointPain,
                MuscleJointPain = model.BodyMuscleJointPain,
                Headache = model.Headache,
                ChestPain = model.ChestPain,
                Confusion = model.Confusion,
                MedsTaken = model.MedsTaken,
                MentalDistress = model.MentalDistress,
                OtherDetails = model.OtherDetails,
                //SignatureOfQd = model.SignatureOfQd,
                PdrId = model.PdrId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            return form;
        }
        #endregion

        #region LAB RESULTS
        public async Task<IActionResult> AddLabResult(int pdrId)
        {
            var pdr = await _context.Pdr
                .Include(x => x.PatientNavigation)
                .Where(x => x.Id == pdrId).FirstOrDefaultAsync();

            var form = new LabResult
            {
                PdrId = pdrId,
                Pdr = pdr
            };

            ViewBag.Doctors = new SelectList(GetDoctors(), "Id", "Fullname");

            return PartialView(form);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequestSizeLimit(valueCountLimit: 1073741824)]
        public async Task<IActionResult> AddLabResult(LabResult model)
        {
            var pdr = await _context.Pdr
                .Include(x => x.PatientNavigation)
                .Where(x => x.Id == model.PdrId)
                .FirstOrDefaultAsync();
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                model.Pdr = pdr;
                model.ResultPic = SaveLabResult(pdr.PatientNavigation.Lastname + DateTime.Now.ToString("ddMMyyyy"), model.ResultPic);
                _context.Update(model);
                await _context.SaveChangesAsync();
                return PartialView(model);
            }

            ViewBag.Doctors = new SelectList(GetDoctors(), "Id", "Fullname", model.AttendingPhysician);
            return PartialView(model);
        }
        #endregion

        #region PDR MODAL

        public async Task<IActionResult> PDRModal(int pdrId)
        {
            var pdr = await _context.Pdr
                .Include(x => x.PatientNavigation)
                .Include(x => x.GuardianNavigation)
                .Include(x => x.SymptomsContacts).SingleOrDefaultAsync(x => x.Id == pdrId);


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
                    var entity = _context.Pdr.FirstOrDefault(x => x.Id == model.Id);
                    var patient = _context.Patient.FirstOrDefault(x => x.Id == model.Patient);
                    var guardian = _context.Guardian.FirstOrDefault(x => x.Id == model.Guardian);
                    var symptoms = _context.SymptomsContacts.FirstOrDefault(x => x.Id == model.SymptomsContactsId);
                    _context.Entry(entity).CurrentValues.SetValues(model);
                    _context.Entry(patient).CurrentValues.SetValues(model.PatientNavigation);
                    _context.Entry(guardian).CurrentValues.SetValues(model.GuardianNavigation);
                    _context.Entry(symptoms).CurrentValues.SetValues(model.SymptomsContacts);
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
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

        #endregion

        #region ADD PATIENT

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
                return RedirectToAction(nameof(Dashboard));
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

        #endregion

        #region DISCHARGE FORM

        public async Task<IActionResult> DischargeForm(int pdrId)
        {
            var pdr = await _context.Pdr
                .Include(x => x.PatientNavigation)
                .FirstOrDefaultAsync(x => x.Id == pdrId);

            ViewBag.Patient = pdr.PatientNavigation.GetFullName();
            /*ViewBag.PdrId = pdrId;
            ViewBag.Doctors = new SelectList(GetDoctors(), "Id", "Fullname");

            var discharge = new Discharge
            {
                Pdr = pdr,
                Pdrid = pdr.Id,
                DateDischarged = DateTime.Now
            };*/

            var model = new DischargeModel
            {
                PdrId = pdrId,
                Name = pdr.PatientNavigation.GetFullName(),
                Discharge = true,
                DischargeDate = DateTime.Now.RemoveSeconds()
            };

            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DischargeForm(DischargeModel model)
        {
            var pdr = await _context.Pdr.FindAsync(model.PdrId);
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                pdr.Status = "discharged";
                pdr.UpdatedAt = model.DischargeDate;
                _context.Update(pdr);
                await _context.SaveChangesAsync();
                return PartialView(model);
            }

            return PartialView(model);
        }

        public async Task<IActionResult> Discharged(string search)
        {
            var patients = await _context.Pdr
                .Include(x => x.PatientNavigation).ThenInclude(x => x.BarangayNavigation)
                .Include(x => x.PatientNavigation).ThenInclude(x => x.MuncityNavigation)
                .Include(x => x.PatientNavigation).ThenInclude(x => x.ProvinceNavigation)
                .Where(x => x.Status == "discharged")
                .OrderByDescending(x => x.UpdatedAt)
                .ToListAsync();

            return View(patients);
        }

        #endregion

        #region REFERRED FORM

        public async Task<IActionResult> Referred(string search)
        {
            var patients = await _context.Referral
                .OrderByDescending(x => x.DateOfReferral)
                .ToListAsync();

            return View(patients);
        }

        public async Task<IActionResult> ReferralForm(int pdrId)
        {
            var pdr = await _context.Pdr
                .Include(x => x.PatientNavigation).ThenInclude(x => x.ProvinceNavigation)
                .Include(x => x.PatientNavigation).ThenInclude(x => x.MuncityNavigation)
                .Include(x => x.PatientNavigation).ThenInclude(x => x.BarangayNavigation)
                .Include(x => x.GuardianNavigation).ThenInclude(x => x.ProvinceNavigation)
                .Include(x => x.GuardianNavigation).ThenInclude(x => x.MuncityNavigation)
                .Include(x => x.GuardianNavigation).ThenInclude(x => x.BarangayNavigation)
                .FirstOrDefaultAsync(x => x.Id == pdrId);

            ViewBag.Doctors = new SelectList(GetDoctors(), "Id", "Fullname");

            var refer = new Referral
            {
                DateOfReferral = DateTime.Now,
                Pdr = pdr,
                Pdrid = pdr.Id
            };

            return PartialView(refer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ReferralForm(Referral model)
        {
            model.Pdr = await _context.Pdr.FindAsync(model.Pdrid);
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                model.Pdr.Status = "referred";
                _context.Update(model);
                await _context.SaveChangesAsync();
                return PartialView(model);
            }

            return PartialView(model);
        }

        #endregion



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
                .Where(x => x.Facility == UserFacility)
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
                .Where(x => x.Facility == UserFacility)
                .Where(x => x.Team == 1 && x.Role == "Healthcare Buddy")
                .Select(x => new SelectUsers
                {
                    Id = x.Id,
                    Fullname = x.Firstname + " " + x.Lastname
                });

            return users.ToList();
        }

        public string SaveLabResult(string name, string base64)
        {
            string imageName = name + ".jpg";
            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "LabResults", imageName);

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
                .Where(x => x.Facility == UserFacility)
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
                .Where(x=>x.Facility == UserFacility)
                .Where(x => x.Team == 1 && x.Role != "Healthcare Buddy")
                .Select(x => new SelectUsers
                {
                    Id = x.Id,
                    Fullname = x.Role == "Doctor" ? "Dr. " + x.Firstname + " " + x.Lastname : x.Firstname + " " + x.Lastname
                });

            return users.ToList();
        }


        public string UserFacility => User.FindFirstValue("Facility");
        #endregion
    }
}

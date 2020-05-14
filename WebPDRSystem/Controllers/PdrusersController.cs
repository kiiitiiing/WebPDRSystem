using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebPDRSystem.Data;
using WebPDRSystem.Models;
using WebPDRSystem.Models.ViewModels;
using static WebPDRSystem.Controllers.HomeController;

namespace WebPDRSystem.Controllers
{
    [Authorize(Policy = "Administrator")]
    public class PDRUsersController : Controller
    {
        private readonly WebPDRContext _context;
            
        public PDRUsersController(WebPDRContext context)
        {
            _context = context;
        }

        public List<string> Roles = new List<string>
        {
            "Doctor", "Nurse", "Healthcare Buddy"
        };

        #region EDITS

        public IActionResult ChangeMedname(int patientId, string medName)
        {
            var model = new ChangeMedModel
            {
                PatientId = patientId,
                MedName = medName,
                NewName = medName
            };
            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeMedname(ChangeMedModel model)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            var patient = await _context.Patient
                .Include(x => x.Medications)
                .FirstOrDefaultAsync(x => x.Id == model.PatientId);

            var meds = patient.Medications
                .Where(x => x.MedName == model.MedName);

            if(ModelState.IsValid)
            {
                foreach(var med in meds)
                {
                    med.MedName = model.NewName;
                }

                _context.UpdateRange(meds);
                await _context.SaveChangesAsync();

                return PartialView(model);
            }

            return PartialView(model);
        }

        public IActionResult MedHistory()
        {
            return View();
        }

        public async Task<IActionResult> MedHistoryPartial()
        {
            var meds = await _context.Pdr
                .Include(x => x.PatientNavigation)
                    .ThenInclude(x => x.Medications)
                .Where(x => x.Status == "Admitted")
                .OrderByDescending(x => x.DateOfAdmission)
                .ToListAsync();


            return PartialView(meds);
        }

        public async Task<IActionResult> EditMed(int medHistoryId)
        {
            var medsHistory = await _context.Medications
                .Include(x => x.Patient)
                .Include(x => x.SignatureNurseNavigation)
                .FirstOrDefaultAsync(x => x.Id == medHistoryId);

            ViewBag.Nurses = new SelectList(GetNurses(), "Id", "Fullname", medsHistory.SignatureNurse);

            return PartialView(medsHistory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMed(Medications model)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if(ModelState.IsValid)
            {
                _context.Update(model);
                await _context.SaveChangesAsync();
            }

            ViewBag.Nurses = new SelectList(GetNurses(), "Id", "Fullname", model.SignatureNurse);
            return PartialView(model);
        }

        #endregion

        #region INDEX
        // GET: Pdrusers
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> PartialIndex(string search)
        {
            var pdrusers = _context.Pdrusers.Include(p => p.TeamNavigation).Where(x => x.Team == 1);

            if (!string.IsNullOrEmpty(search))
            {
                pdrusers = pdrusers.Where(x => x.Firstname.Contains(search) || x.Middlename.Contains(search) || x.Lastname.Contains(search));
            }
            return PartialView(await pdrusers.ToListAsync());
        }

        #endregion

        #region ADD USER
        public async Task<IActionResult> AddUsers(int? id)
        {
            if (id != null)
            {
                var user = _context.Pdrusers.Find(id);

                user.Team = 1;
                _context.Update(user);
                await _context.SaveChangesAsync();
            }
            var pdrusers = _context.Pdrusers.Where(x => x.Team == null);
            return PartialView(await pdrusers.ToListAsync());
        }
        public IActionResult NewUser()
        {
            ViewData["Role"] = new SelectList(Roles);
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewUser([Bind("Id,Username,Password,Firstname,Middlename,Lastname,Role,PhotoString,PhotoFilePath")] AddUser newUser)
        {
            newUser.Username = newUser.Firstname + newUser.Lastname + DateTime.Now.ToString("ddMMyyyyHHmmss");
            newUser.Password = newUser.Firstname + newUser.Lastname + DateTime.Now.ToString("ddMMyyyyHHmmss");
            if (ModelState.IsValid)
            {
                var user = SetUser(newUser);
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Role"] = new SelectList(Roles, newUser.Role);
            return PartialView(newUser);
        }


        // GET: Pdrusers/Create
        public IActionResult Create()
        {
            ViewData["Role"] = new SelectList(Roles);
            return View();
        }

        // POST: Pdrusers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Password,Firstname,Middlename,Lastname,Role,PhotoString,PhotoFilePath")] AddUser newUser)
        {
            if (ModelState.IsValid)
            {
                var user = SetUser(newUser);
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Role"] = new SelectList(Roles, newUser.Role);
            return View(newUser);
        }
        #endregion

        #region USER DETAILS
        // GET: Pdrusers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pdrusers = await _context.Pdrusers
                .Include(p => p.TeamNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pdrusers == null)
            {
                return NotFound();
            }

            return View(pdrusers);
        }
        #endregion

        #region API
        public void AddTeam([FromQuery]int user)
        {
            var pdruser = _context.Pdrusers.Find(user);

            pdruser.Team = 1;
            _context.Update(pdruser);
            _context.SaveChanges();
        }
        public void RemoveToTeam([FromQuery]int user)
        {
            var pdruser = _context.Pdrusers.Find(user);

            pdruser.Team = null;
            _context.Update(pdruser);
            _context.SaveChanges();
        }
        #endregion

        #region EDIT USER


        public async Task<IActionResult> ViewUser(int id)
        {
            var user = await _context.Pdrusers.FindAsync(id);


            ViewData["Role"] = new SelectList(Roles);
            return PartialView(SetUser(user));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ViewUser( [Bind("Id,Firstname,Middlename,Lastname,Initials,Role,PhotoString,PhotoFilePath")]AddUser pdrusers)
        {
            if (ModelState.IsValid)
            {
                var user = UpdateUser(pdrusers);

                _context.Update(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Role"] = new SelectList(Roles);
            return PartialView(pdrusers);
        }
        #endregion

        #region DELETE USER
        // GET: Pdrusers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pdrusers = await _context.Pdrusers
                .Include(p => p.TeamNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pdrusers == null)
            {
                return NotFound();
            }

            return View(pdrusers);
        }

        // POST: Pdrusers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pdrusers = await _context.Pdrusers.FindAsync(id);
            _context.Pdrusers.Remove(pdrusers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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

        public AddUser SetUser(Pdrusers model)
        {
            var user = new AddUser
            {
                Id = model.Id,
                Firstname = model.Firstname,
                Middlename = model.Middlename,
                Lastname = model.Lastname,
                Initials = model.Initials,
                PhotoString = model.Picture,
                Role = model.Role,
            };

            return user;
        }

        public Pdrusers UpdateUser(AddUser model)
        {
            var user = _context.Pdrusers.Find(model.Id);

            user.Firstname = model.Firstname;
            user.Middlename = model.Middlename;
            user.Lastname = model.Lastname;
            user.Initials = model.Initials;
            user.Picture = SavePicture(model.Firstname + model.Lastname, model.PhotoString);
            user.Role = model.Role;
            user.Designation = SetDesignation(model.Role);
            user.UpdatedAt = DateTime.Now;

            return user;
        }

        public string SetDesignation( string role)
        {
            string designation = "";
            if (role == "Nurse" || role == "Doctor")
            {
                designation = "nursedoc";
            }
            else if (role == "Admin")
            {
                designation = role;
            }
            else if (role == "resuhems")
            {
                designation = role;
            }

            return designation;
        }


        public Pdrusers SetUser(AddUser model)
        {
            
            var user = new Pdrusers
            {
                Username = model.Username,
                Password = model.Password,
                Firstname = model.Firstname,
                Middlename = model.Middlename,
                Lastname = model.Lastname,
                Initials = model.Initials,
                Picture = SavePicture(model.Firstname + model.Lastname, model.PhotoString),
                Team = null,
                Role = model.Role,
                Designation = SetDesignation(model.Role),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            return user;
        }

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
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

            ViewBag.CaseNumber = pdr.CaseNumber;

            return PartialView(qfn);
        }
        #endregion

        #region VIEW DOCTORS ORDERS
        public async Task<IActionResult> ViewOrders(int pdrId)
        {
            var pdr = await _context.Pdr.FindAsync(pdrId);
            var orders = await _context.DoctorOrders
                .Include(x => x.ListDocOrders)
                .Include(x => x.Pdr)
                    .ThenInclude(x => x.PatientNavigation)
                .Where(x => x.PdrId == pdrId)
                .OrderBy(x => x.DateOrdered)
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

            ViewBag.Patient = _context.Pdr.Include(x => x.PatientNavigation).FirstOrDefault(x => x.Id == pdrId).PatientNavigation.GetFullName();

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

            var order = new AddOrderModel
            {
                CaseNumber = pdr.CaseNumber,
                PdrId = pdrId,
                DateOrdered = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0),
                TimePosted = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0)
            };

            ViewBag.Nurses = new SelectList(GetNurses(), "Id", "Fullname");

            return PartialView(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrder(AddOrderModel model)
        {
            var pdr = await _context.Pdr
                .Include(x => x.PatientNavigation)
                .Where(x => x.Id == model.PdrId)
                .FirstOrDefaultAsync();
            var errors = ModelState.Values.SelectMany(v => v.Errors);

            if (ModelState.IsValid)
            {
                var order = SetOrder(model);
                _context.Add(order);
                await _context.SaveChangesAsync();
                return PartialView(model);
            }


            return PartialView(model);
        }
        #endregion

        #region MEDICATIONS

        public partial class GroupMed
        {
            public string Medname { get; set; }
            public bool Discontinued { get; set; }
        }

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

            var groupMeds = await meds
                .GroupBy(x => x.MedName)
                .Select(x => new GroupMed
                {
                    Medname = x.Key,
                })
                .ToListAsync();

            ViewBag.MedCounts = groupMeds.Count();
            ViewBag.Medications = new SelectList(groupMeds, "Medname", "Medname");
            var medics = new List<MedModel>();

            medics.Add(new MedModel
            {
                PatientId = (int)pdr.Patient,
                TimeTaken = DateTime.Now.RemoveSeconds()
            });

            ViewBag.Nurses = new SelectList(GetNurses(), "Id", "Fullname");

            var model = new ListMeds
            {
                PatientName = pdr.PatientNavigation.GetFullName(),
                Meds = medics,
                DateTaken = DateTime.Now,
                Day = day
            };
            return PartialView(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMedication(ListMeds model)
        {
            var meds = await _context.Medications.Where(x => x.PatientId == model.Meds.First().PatientId).ToListAsync();

            var groupMeds = meds
                .Where(x => x.Discontinued != true)
                .GroupBy(x => x.MedName)
                .Select(x => new GroupMed
                {
                    Medname = x.Key
                });

            ViewBag.MedCounts = groupMeds.Count();
            ViewBag.Medications = new SelectList(groupMeds, "Medname", "Medname");
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                await SaveListMeds(model);
                return PartialView(model);
            }
            ViewBag.Nurses = new SelectList(GetNurses(), "Id", "Fullname");
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
                .ToListAsync();


            ViewBag.Patient = meds.PatientNavigation.GetFullName();

            return PartialView(allMeds);
        }

        #endregion



        #region HELPERS

        public async Task SaveListMeds(ListMeds model)
        {
            var meds = new List<Medications>();

            foreach(var med in model.Meds)
            {
                var date = model.DateTaken;
                var time = med.TimeTaken;
                var datetime = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
                meds.Add(new Medications
                {
                    PatientId = med.PatientId,
                    MedName = med.MedName,
                    Discontinued = med.Discontinued,
                    Day = model.Day,
                    SignatureNurse = med.NurseId,
                    Comments = med.Comments,
                    CreatedAt = datetime
                });
            }

            _context.UpdateRange(meds);
            await _context.SaveChangesAsync();
        }


        public ActionResult AppendCard(int index, int patientId)
        {
            var meds = _context.Medications.Where(x => x.PatientId == patientId);

            var groupMeds = meds
                .GroupBy(x => x.MedName)
                .Select(x => new GroupMed
                {
                    Medname = x.Key,
                })
                .ToList();

            var nurses = GetNurses();
            var time = DateTime.Now.ToString("HH:mm");
            var sb = new StringBuilder();

            sb.Append("<div class='card card-outline' style='margin-top:10px; margin-bottom: 0px!important;'>");// start card
            sb.Append("<div class='card-body'>");//start card body
            sb.Append("<input hidden='' type='number' data-val='true' data-val-required='The PatientId field is required.' id='Meds_" + index + "__PatientId' name='Meds[" + index + "].PatientId' value='" + patientId + "'>");
            
            //LABEL ROWS
            sb.Append("<div class='row'>");//start 1st row
            sb.Append("<div class='col-md-7'>");//start collmd7
            sb.Append("<label>Medication:</label>");
            sb.Append("<button type='button' class='btn btn-xs btn-primary fa-pull-right' id='add_button' style='float:right !important;' onclick='ToggleInput();'>new</button>");
            sb.Append("</div>");//end collmd7
            sb.Append("<div class='col-md-3'>");//start collmd3
            sb.Append("<label>Time Taken:</label>");
            sb.Append("</div>");//end collmd3
            sb.Append("<div class='col-md-2'>");//start collmd2
            sb.Append("<label>Discontinue:</label>");
            sb.Append("</div>");//end collmd2
            sb.Append("</div>");//end 1st row

            //MEDS | TIME TAKEN | DISCONTINUED
            sb.Append("<div class='row'>");//start 2nd row
            sb.Append("<div class='col-md-7' id='med_row'>");//start collmd7
            if (groupMeds.Count() != 0)
            {
                sb.AppendFormat("<select class='form-control select2' data-val='true' data-val-required='The MedName field is required.' id='Meds_{0}__MedName' name='Meds[{1}].MedName'>",index,index);
                sb.Append(@"<option disabled='' selected='' hidden=''>Select Meds</option> ");
                for(int x = 0; x < groupMeds.Count(); x++)
                {
                    sb.AppendFormat(@"<option value='{0}'>{1}</option> ", groupMeds[x].Medname, groupMeds[x].Medname);
                }
                sb.Append("</select>");
            }
            else
            {
                sb.AppendFormat(@"<input class='form-control text-sm' placeholder='Medname / Dosage / Route / Frequency' type='text' data-val='true' data-val-required='The MedName field is required.' id='Meds_{0}__MedName' name='Meds[{1}].MedName' value=''>", index, index);
                
            }
            sb.Append("</div>");//end collmd7
            sb.Append("<div class='col-md-3'>");
            sb.AppendFormat("<input type='time' class='form-control' id='wtf' data-val='true' data-val-required='The TimeTaken field is required.' id='Meds_{0}__TimeTaken' name='Meds[{1}].TimeTaken' value='{2}'>", index, index, time);
            sb.Append("</div>");//end collmd3
            sb.Append("<div class='col-md-2'>");//start colmd2
            sb.Append("<input type='radio' id='Yes' value='true' checked='' data-val='true' data-val-required='The Discontinued field is required.' name='Meds[" + index + "].Discontinued'>");
            sb.Append("<label for='male'>Yes</label>");
            sb.Append("<input type='radio' id='No' value='false' checked='checked' name='Meds[" + index + "].Discontinued'>");
            sb.Append("<label for='male'>No</label>");
            sb.Append("</div>");//end colmd2
            sb.Append("</div>");//end 2nd row

            //COMMENTS | ATTENDING NURSE
            sb.Append("<div class='row'>");//start 3rd row
            sb.Append("<div class='col-md-6'>");//start collmd6
            sb.Append("<label>Comments:</label>");
            sb.Append("<input type='text' class='form-control' id='Meds_" + index + "__Comments' name='Meds[" + index + "].Comments' value=''>");
            sb.Append("</div>");//end collmd6
            sb.Append("<div class='col-md-6'>");//start collmd6
            sb.Append("<label>Attending Nurse:</label>");
            sb.AppendFormat(@"<select class='form-control' data-val='true' data-val-required='The NurseId field is required.' id='Meds_{0}__NurseId' name='Meds[{0}].NurseId'>",index,index);
            sb.Append("<option value='' selected hidden >Select Nurse</option>");
            foreach (var nurse in nurses)
            {
                sb.AppendFormat(@"<option value='{0}'>{1}</option>", nurse.Id, nurse.Fullname);
            }
            sb.Append("</select>");
            sb.Append("</div>");//end collmd6
            sb.Append("</div>");//end 3rd row
            sb.Append("</div>");//end card body
            sb.Append("</div>");//end card

            return Content(sb.ToString());
        }

        public DoctorOrders SetOrder(AddOrderModel model)
        {
            var order = new DoctorOrders();

            var listOrder = new List<ListDocOrders>();

            var orders = model.Order.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach(var item in orders)
            {
                listOrder.Add(new ListDocOrders 
                {
                    DoctorsOrder = item,
                    Carried = false,
                    Administered = false,
                    RequestMade = false,
                    Endorsed = false,
                    Discontinued = false,
                    CreatedAt = DateTime.Now
                });
            }

            order.PdrId = model.PdrId;
            order.Comments = model.Comments;
            order.ListDocOrders = listOrder;
            order.TimePosted = model.TimePosted;
            order.DateOrdered = model.DateOrdered;

            return order;
        }

        public List<SelectUsers> GetNurses()
        {
            var users = _context.Pdrusers
                .Where(x=>x.Facility == UserFacility)
                .Where(x => x.Team == 1 && x.Role == "Nurse")
                .Select(x => new SelectUsers
                {
                    Id = x.Id,
                    Fullname = x.Firstname + " " + x.Lastname
                });

            return users.ToList();
        }



        public string UserFacility => User.FindFirstValue("Facility");
        #endregion
    }
}
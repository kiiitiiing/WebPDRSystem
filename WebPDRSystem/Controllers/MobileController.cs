using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebPDRSystem.Data;
using WebPDRSystem.Models;
using WebPDRSystem.Models.MobileModels;
using WebPDRSystem.Services;

namespace WebPDRSystem.Controllers
{
    [ApiController]
    public class MobileController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly IConfiguration _configuration;

        private readonly WebPDRContext _context;

        public MobileController(IUserService userService, IConfiguration configuration, WebPDRContext context)
        {
            _userService = userService;
            _configuration = configuration;
            _context = context;
        }

        [Route("mobileapi/login")]
        [HttpPost]
        public async Task<MainUserModel> Login(LoginModel usercredentials)
        {
            //LoginModel usercredentials
            var (isValid, user) = await _userService.ValidateUserCredentialsAsync(usercredentials.Username, usercredentials.Password);
            if (isValid)
            {
                var getUser = await _context.Pdrusers.FirstOrDefaultAsync(x => x.Username == user.Username);
                return new MainUserModel
                {
                    Firstname = getUser.Firstname,
                    Middlename = getUser.Middlename,
                    Lastname = getUser.Lastname,
                    Role = getUser.Role,
                };
            }

            return null;
        }

        [Route("mobileapi/getallpdrforms")]
        [HttpGet]
        public async Task<List<Pdr>> GetAllPdrForms()
        {
            return await _context.Pdr
                .Take(5)
                .Include(x => x.PatientNavigation)
                .Include(x => x.GuardianNavigation)
                .Include(x => x.InterviewedByNavigation)
                .Include(x => x.SymptomsContacts)
                .ToListAsync();
        }

        [Route("mobileapi/submitpdr")]
        [HttpPost]
        public async Task<ResultPdrBundle> SavePdr(Pdr form)
        {
            if (_context.Patient.Any(x =>
                     x.Firstname.ToUpper().Equals(form.PatientNavigation.Firstname.ToUpper()) &&
                     (x.Middlename ?? "").ToUpper().Equals((form.PatientNavigation.Middlename ?? "").ToUpper()) &&
                     x.Lastname.ToUpper().Equals(form.PatientNavigation.Lastname.ToUpper()) &&
                     x.Gender == form.PatientNavigation.Gender &&
                     x.DateOfBirth == form.PatientNavigation.DateOfBirth))
            {
                var patient = _context.Patient.SingleOrDefault(x =>
                    x.Firstname.ToUpper().Equals(form.PatientNavigation.Firstname.ToUpper()) &&
                    (x.Middlename ?? "").ToUpper().Equals((form.PatientNavigation.Middlename.ToUpper() ?? "").ToUpper()) &&
                    x.Lastname.ToUpper().Equals(form.PatientNavigation.Lastname.ToUpper()) &&
                    x.Gender == form.PatientNavigation.Gender &&
                    x.DateOfBirth == form.PatientNavigation.DateOfBirth);
            }
            form.CreatedAt = DateTime.Now;
            form.UpdatedAt = DateTime.Now;
            _context.Add(form);

            var result = await _context.SaveChangesAsync() == 1;
            var savedForm = await _context.Patient.SingleOrDefaultAsync(x => x.CreatedAt.Equals(form.CreatedAt));
            return new ResultPdrBundle
            {
                Result = await _context.SaveChangesAsync() == 1,
            };
        }

        [Route("mobileapi/barangays")]
        [HttpGet]
        public async Task<List<Barangay>> GetAllBarangasy()
        {
            return await _context.Barangay.ToListAsync();
        }

        [Route("mobileapi/muncities")]
        [HttpGet]
        public async Task<List<Muncity>> GetAllMuncitiesAsync()
        {
            return await _context.Muncity.ToListAsync();
        }

        [Route("mobileapi/provinces")]
        [HttpGet]
        public async Task<List<Province>> GetAllProvincesAsync()
        {
            return await _context.Province.ToListAsync();
        }

        [Route("mobileapi/getusers")]
        [HttpGet]
        public async Task<List<Pdrusers>> GetAllUsers()
        {
            return await _context.Pdrusers.Where(x => x.Team == 1 && !x.Role.Equals("Healthcare Buddy")).ToListAsync();
        }

    }
}

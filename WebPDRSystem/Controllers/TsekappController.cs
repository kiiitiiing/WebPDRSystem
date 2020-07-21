using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebPDRSystem.Data;
using WebPDRSystem.Data.ReferralDBContext;
using WebPDRSystem.Models.Tsekapp;
using WebPDRSystem.Services;

namespace WebPDRSystem.Controllers
{
    [ApiController]
    public class TsekappController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly IConfiguration _configuration;

        private readonly WebPDRContext _context;
        private readonly tsekap_mainContext _tsekappcontext;
        private readonly doh_referralContext _referral;

        public TsekappController(IUserService userService, IConfiguration configuration, WebPDRContext context, tsekap_mainContext tsekapcontext, doh_referralContext referral)
        {
            _userService = userService;
            _configuration = configuration;
            _context = context;
            _tsekappcontext = tsekapcontext;
            _referral = referral;
        }

        [Route("tsekapp/getusers")]
        [HttpGet]
        public List<Users> GetAllUsers()
        {
            return _tsekappcontext.Users.ToList();
        }
    }
}

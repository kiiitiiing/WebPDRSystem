
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebPDRSystem.Data;
using WebPDRSystem.Services;
using WebPDRSystem.Models;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebPDRSystem.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using WebPDRSystem.Models.ViewModels;
using System.Net;

namespace WebPDRSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        private readonly IConfiguration _configuration;

        private readonly WebPDRContext _context;


        public AccountController(IUserService userService, IConfiguration configuration, WebPDRContext context)
        {
            _userService = userService;
            _configuration = configuration;
            _context = context;
        }
        public async Task<IActionResult> Resu()
        {
            var admin = new Pdrusers
            {
                Username = "doh_resuhems",
                Password = "D0h7_r3suh3m5",
                Firstname = "RESU",
                Middlename = "covid",
                Lastname = "HEMS",
                Role = "resuhems",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            if (await _userService.RegisterDoctorAsync(admin))
            {
                return View(true);
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> NewDoc()
        {
            var nurse = new Pdrusers
            {
                Username = "covidcenter_doctor",
                Password = "covid19_docpassword",
                Firstname = "Covid Center",
                Middlename = "19",
                Lastname = "Doctor",
                Role = "Nurse",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            if (await _userService.RegisterDoctorAsync(nurse))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }


        public async Task<IActionResult> NewNurseDoc()
        {
            var nurse = new Pdrusers
            {
                Username = "covidcenter_nurse",
                Password = "cc_nursepassword",
                Firstname = "Covid Center",
                Middlename = "19",
                Lastname = "Nurse",
                Role = "Nurse",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            if(await _userService.RegisterDoctorAsync(nurse))
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }

        }

        public async Task<IActionResult> NewUser()
        {
            var admin = new Pdrusers
            {
                Username = "covidcenter_admin",
                Password = "covid19_admin",
                Firstname = "Covid Center",
                Middlename = "19",
                Lastname = "Admin",
                Role = "Admin",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            if(await _userService.RegisterDoctorAsync(admin))
            {
                return View(true);
            }
            else
            {
                return NotFound();
            }

        }

        // GET
        [HttpGet]
        public IActionResult Login()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View(new LoginViewModel());
            }
            else
            {
                if (User.FindFirstValue(ClaimTypes.Role).Equals("Admin"))
                    return RedirectToAction("Dashboard", "Home");
                else if (User.FindFirstValue(ClaimTypes.Role).Equals("Doctor"))
                {
                    return RedirectToAction("Dashboard", "Home");
                }
                else if (User.FindFirstValue(ClaimTypes.Role).Equals("Nurse"))
                {
                    return RedirectToAction("Dashboard", "Home");
                }
                else if (User.FindFirstValue(ClaimTypes.Role).Equals("resuhems"))
                {
                    return RedirectToAction("AddPatient", "Resuhems");
                }
                else
                    return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var (isValid, user) = await _userService.ValidateUserCredentialsAsync(model.Username, model.Password);

                if (isValid)
                {
                    await LoginAsync(user, true);
                    await _context.SaveChangesAsync();
                    if (user.Role.Equals("Admin"))
                        return RedirectToAction("Dashboard", "Home");
                    else if (user.Role.Equals("Doctor"))
                    {
                        return RedirectToAction("Dashboard", "Home");
                    }
                    else if (user.Role.Equals("Nurse"))
                    {
                        return RedirectToAction("Dashboard", "Home");
                    }
                    else if (user.Role.Equals("resuhems"))
                    {
                        return RedirectToAction("AddPatient", "Resuhems");
                    }
                }
                else
                {
                    if (user == null)
                    {
                        ModelState.AddModelError("Username", "User does not exists");
                        ViewBag.Username = "invalid";
                    }
                    else
                    {
                        ModelState.AddModelError("Username", "Wrong Password");
                        ViewBag.Password = "invalid";
                    }
                }
            }
            ViewBag.Result = false;
            return View(model);
        }

        public async Task<IActionResult> Logout(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            if (!_configuration.GetValue<bool>("Account:ShowLogoutPrompt"))
            {
                return await Logout();
            }

            return View();
        }
        public IActionResult AccessDenied(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        
        public IActionResult NotFound()
        {
            return View();
        }

        public IActionResult Cancel(string returnUrl)
        {
            if (isUrlValid(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }

            return RedirectToAction("Login", "Account");
        }


        #region Helpers
        private bool isUrlValid(string returnUrl)
        {
            return !string.IsNullOrWhiteSpace(returnUrl) && Uri.IsWellFormedUriString(returnUrl, UriKind.Relative);
        }

        private async Task LoginAsAsync(int facilityId, string level)
        {
            var user = await _context.Pdrusers
                .FirstOrDefaultAsync(x => x.Id == UserId);
            var properties = new AuthenticationProperties
            {
                AllowRefresh = false,
                IsPersistent = false
            };

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.GivenName, user.Firstname),
                new Claim(ClaimTypes.Surname, user.Lastname),
                new Claim(ClaimTypes.Role, level)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal, properties);
        }


        private async Task LoginAsync(Pdrusers user, bool rememberMe)
        {
            var properties = new AuthenticationProperties
            {
                AllowRefresh = false,
                IsPersistent = rememberMe
            };

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.GivenName, user.Firstname),
                new Claim(ClaimTypes.Surname, user.Lastname),
                new Claim(ClaimTypes.Role, user.Designation)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal, properties);
        }

        public int UserId => int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        public string UserName => "Dr. " + User.FindFirstValue(ClaimTypes.GivenName) + " " + User.FindFirstValue(ClaimTypes.Surname);
        #endregion
    }
}
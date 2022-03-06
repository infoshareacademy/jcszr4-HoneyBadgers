using System;
using System.Linq;
using System.Threading.Tasks;
using HoneyBadgers.Entity.Models;
using HoneyBadgers.Logic.Models;
using Microsoft.AspNetCore.Mvc;
using HoneyBadgers.Logic.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace HoneyBadgers.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthService _authService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        public AccountController(
            AuthService authService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<AccountController> logger
        ) {
            _authService = authService;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.Email,
                    Email = model.Email

                };
                LogContext.PushProperty("UserName", model.Email);
                Serilog.Log.Information("Trying to register new user - {userName} at {registrationDate}", model.Email, DateTime.Now);
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);
                    LogContext.PushProperty("UserName", model.Email);
                    Serilog.Log.Information("User {userName} has been registered successfully at {registrationDate}", model.Email, DateTime.Now);
                    return RedirectToAction("Index", "Home");

                }
            }

            LogContext.PushProperty("UserName", model.Email);
            Serilog.Log.Information("Registration of the user - {userName} failed at {registrationDate}", model.Email, DateTime.Now);
            ModelState.AddModelError("", "Invalid Register.");
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(model.Email);
                    LogContext.PushProperty("UserName", model.Email);
                    Serilog.Log.Information("User {userName} logged in successfully at {loginDate}", model.Email, DateTime.Now);
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Invalid ID or Password");
            LogContext.PushProperty("UserName", model.Email);
            Serilog.Log.Information("login attempt failed for the user - {userName} at {loginDate}", model.Email, DateTime.Now);
            return View(model);
        }
    }
}

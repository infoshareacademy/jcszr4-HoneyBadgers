using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using HoneyBadgers.Entity.Context;
using HoneyBadgers.Entity.Models;
using HoneyBadgers.Logic.Models;
using HoneyBadgers.Logic.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace HoneyBadgers.WebApp.Controllers
{
    public class ManageController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly HbContext _context;
        private readonly IMovieService _movieService;
        public ManageController(UserManager<ApplicationUser> userManager, HbContext context, IMovieService movieService)
        {
            _userManager = userManager;
            _context = context;
            _movieService = movieService;
        }
        public IActionResult Index()
        {
            if (!User.IsInRole("Admin"))
            {
                return StatusCode(403);
            }
                
            return View();
            
        }
        public IActionResult Users()
        {
            if (!User.IsInRole("Admin"))
            {
                return StatusCode(403);
            }
            var model = _userManager.Users.ToList();
            return View(model);
        }

        public async Task<IActionResult> Movies()
        {
            if (!User.IsInRole("Admin"))
            {
                return StatusCode(403);
            }
            var model = await _movieService.GetAll();
            return View(model);
        }

        public IActionResult CreateUser()
        {
            if (!User.IsInRole("Admin"))
            {
                return StatusCode(403);
            }
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(UserCreateViewModel model)
        {
            if (!User.IsInRole("Admin"))
            {
                return StatusCode(403);
            }
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.Email,
                    Email = model.Email

                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.Role);
                    return RedirectToAction("Users");
                }
            }
            ModelState.AddModelError("", "Invalid Register.");
            return View(model);
        }

        public async Task<IActionResult> EditUser(string id)
        {
            if (!User.IsInRole("Admin"))
            {
                return StatusCode(403);
            }
            var user = await _userManager.FindByIdAsync(id);
            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> EditUser(ApplicationUser form)
        {
            if (!User.IsInRole("Admin"))
            {
                return StatusCode(403);
            }
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(form.Id);
            }
            return RedirectToAction("Users");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (!User.IsInRole("Admin"))
            {
                return StatusCode(403);
            }
            var user = await _userManager.FindByIdAsync(id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteUser(ApplicationUser model)
        {
            if (!User.IsInRole("Admin"))
            {
                return StatusCode(403);
            }
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id);
                var rolesForUser = await _userManager.GetRolesAsync(user);
        
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
        
                    if (rolesForUser.Count() > 0)
                    {
                        foreach (var item in rolesForUser.ToList())
                        {
                            // item should be the name of the role
                            var result = await _userManager.RemoveFromRoleAsync(user, item);
                        }
                    }
        
                    await _userManager.DeleteAsync(user);
                    await transaction.CommitAsync();
                }
        
                return RedirectToAction("Users");
            }
            else
            {
                return RedirectToAction("Users");
            }
        }
    }
}

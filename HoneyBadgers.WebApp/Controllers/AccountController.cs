using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HoneyBadgers.Logic.Services;
using Microsoft.AspNetCore.Http;

namespace HoneyBadgers.WebApp.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        private readonly AuthService _authService;
        public AccountController(AuthService authService)
        {
            _authService = authService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var logged = await _authService.Login(email, password);
                if (logged != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ViewBag.error = "Login failed";
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Remove("FullName");
            HttpContext.Session.Remove("Email");
            HttpContext.Session.Remove("UserId");
            return RedirectToAction("Login");
        }
    }
}

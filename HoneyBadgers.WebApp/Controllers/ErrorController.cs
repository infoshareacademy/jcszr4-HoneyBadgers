using Microsoft.AspNetCore.Mvc;

namespace HoneyBadgers.WebApp.Controllers
{
    [Route("error")]
    public class ErrorController : Controller
    {
        [Route("404")]
        public IActionResult PageNotFound()
        {
            return View();
        }
    }
}

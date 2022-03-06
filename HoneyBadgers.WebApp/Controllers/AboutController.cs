using HoneyBadgers.Logic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Context;

namespace HoneyBadgers.WebApp.Controllers
{
    public class AboutController : Controller
    {
        private readonly ILogger<AboutController> _logger;

        public AboutController(ILogger<AboutController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            
            Log.Information("Section 'About' has been displayed.");
            return View();
        }
    }
}

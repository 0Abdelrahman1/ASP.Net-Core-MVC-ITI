using Microsoft.AspNetCore.Mvc;
using MVC_WebAppEF_ValidationAnnotations.Models;
using System.Configuration;
using System.Diagnostics;

namespace MVC_WebAppEF_ValidationAnnotations.Controllers
{
    public class HomeController : Controller
    {
        public IWebHostEnvironment Environment { get; }

        public HomeController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }
        public IActionResult Index()
        {
            ViewBag.Env = Environment;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

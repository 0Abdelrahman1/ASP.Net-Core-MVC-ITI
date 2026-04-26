using Microsoft.AspNetCore.Mvc;
using MVC_WebApp_EF_Repo_Injection_Environment_Partial_Validation_Bundling.Models;
using System.Diagnostics;

namespace MVC_WebApp_EF_Repo_Injection_Environment_Partial_Validation_Bundling.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
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

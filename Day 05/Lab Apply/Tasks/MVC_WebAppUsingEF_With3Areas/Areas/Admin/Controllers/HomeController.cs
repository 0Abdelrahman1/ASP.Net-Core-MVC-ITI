using Microsoft.AspNetCore.Mvc;
using MVC_WebAppUsingEF_With3Areas.Models;
using System.Diagnostics;

namespace MVC_WebAppUsingEF_With3Areas.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Admin Home Index");
        }
    }
}

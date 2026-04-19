using Microsoft.AspNetCore.Mvc;
using MVC_WebAppUsingEF_With3Areas.Models;
using System.Diagnostics;

namespace MVC_WebAppUsingEF_With3Areas.Areas.Finance.Controllers
{
    [Area("Finance")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content("Finance Home Index");
        }
    }
}

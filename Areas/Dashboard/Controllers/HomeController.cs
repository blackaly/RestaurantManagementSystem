using Microsoft.AspNetCore.Mvc;
using OrderingSystemDashboard.Models;
using System.Diagnostics;

namespace OrderingSystem.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

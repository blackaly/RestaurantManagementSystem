using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OrderingSystem.Models.DbContext;
using OrderingSystem.Models.DbModels;
using OrderingSystem.Models.ViewModel;

namespace OrderingSystem.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ReservationsController : Controller
    {

        private readonly OrderDbContext dbContext;

        public ReservationsController(OrderDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult PenddingReservations(int id)
        {
            return View();
        }

        
        public IActionResult Details(int id)
        {
            return View();
        }
        public IActionResult Reject(int id)
        {
            return View();
        }
        public IActionResult Delete(int id)
        {
            return View();
        }
    }
}

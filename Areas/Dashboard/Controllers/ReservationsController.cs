using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OrderingSystem.Models.DbContext;
using OrderingSystem.Models.DbModels;
using OrderingSystem.Models.Enums;
using OrderingSystem.Areas.Dashboard.Models.ViewModels.Shared;

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
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PenddingReservations()
        {

            var pendding = dbContext.Reservations.GroupBy(x => new { x.ReservationDate, x.PhoneNumber, x.Email, x.GuestName, x.ReservationStatus, x.NumberOfPeople } )
                .Select(y => new ReservationViewModel
                {
                    id = y.FirstOrDefault().Id,
                    ReservationDate = $"{y.Key.ReservationDate.Day}/{y.Key.ReservationDate.Month}/{y.Key.ReservationDate.Year}",
                    ReservationTime = $"{y.Key.ReservationDate.Hour}:{y.Key.ReservationDate.Minute}",
                    NumberOfPeople = y.Key.NumberOfPeople,
                    GuestName = y.Key.GuestName,
                    PhoneNumber = y.Key.PhoneNumber,
                    Email = y.Key.Email,
                    NumberOfTablesInSameDateTime = y.Count(),
                    ReservationStatus = y.Key.ReservationStatus
                }).Where(z => z.ReservationStatus == ReservationStatus.Pendding).ToList();

            return View(pendding);
        }

        [HttpGet]
        public IActionResult AssignTable(int id)
        {
            var data = dbContext.Reservations.Find(id);
            if(data != null)
            {

                return View(new ReservationViewModel
                {
                    id = id,
                    GuestName = data.GuestName,
                    Email = data.Email,
                    NumberOfPeople = data.NumberOfPeople,
                    PhoneNumber = data.PhoneNumber,
                    ReservationDate = $"{data.ReservationDate.Day}/{data.ReservationDate.Month}/{data.ReservationDate.Year}",
                    ReservationTime = $"{data.ReservationDate.Hour}:{data.ReservationDate.Minute}",

                });
            }

            return View();
        }

        [HttpPost]
        public IActionResult AssignTablePost(int id)
        {
            var data = dbContext.Reservations.Find(id);
            if (data != null)
            {

                return View(new ReservationViewModel
                {
                    id = id,
                    GuestName = data.GuestName,
                    Email = data.Email,
                    NumberOfPeople = data.NumberOfPeople,
                    PhoneNumber = data.PhoneNumber,
                    ReservationDate = $"{data.ReservationDate.Day}/{data.ReservationDate.Month}/{data.ReservationDate.Year}",
                    ReservationTime = $"{data.ReservationDate.Hour}:{data.ReservationDate.Minute}",

                });
            }

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

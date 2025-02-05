using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OrderingSystem.Models.DbContext;
using OrderingSystem.Models.DbModels;
using OrderingSystem.Models.Enums;
using OrderingSystem.Models.ViewModel;

namespace OrderingSystem.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly OrderDbContext dbContext;

        public ReservationsController(OrderDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]ReservationViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                Reservations reservations = new Reservations();
                reservations.Email = rvm.Email;
                reservations.PhoneNumber = rvm.PhoneNumber;
                reservations.GuestName = rvm.GuestName;
                reservations.NumberOfPeople = rvm.NumberOfPeople;
                reservations.ReservationDate = new DateTime(rvm.ReservationDate, TimeOnly.Parse(rvm.ReservationTime));
                reservations.ReservationStatus = ReservationStatus.Pendding;

                reservations.TableId = 6;
                if (!rvm.Comment.IsNullOrEmpty())
                {
                    dbContext.GuestSpecialRequest.Add(new GuestSpecialRequest()
                    {
                        Email = rvm.Email,
                        commment = rvm.Comment
                    });
                }

                await dbContext.Reservations.AddAsync(reservations);
                await dbContext.SaveChangesAsync();

                return Json(new { success = true, message = "Reservation successful!" });

            }
            else return Json(new { success = false, message = ModelState.Values});
        }
    }
}

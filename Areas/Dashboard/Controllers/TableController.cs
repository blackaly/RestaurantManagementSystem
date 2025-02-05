using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderingSystem.Areas.Dashboard.Models.ViewModels;
using OrderingSystem.Models.DbContext;
using OrderingSystem.Models.DbModels;
using OrderingSystem.Models.Enums;
namespace OrderingSystem.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class TableController : Controller
    {
        private readonly OrderDbContext dbContext;
        public TableController(OrderDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var tables = dbContext.Table.Select(x => new TableViewModel
            {
                SeatingCapacity = x.SeatingCapacity,
                TableNumber = x.TableNumber,
                TableAvabilityStatus = x.AvabilityStatus
            }).ToList();
            return View(tables);
        }

        [HttpGet]
        public IActionResult Details(int tableNumber)
        {

            bool isExist = dbContext.Table.Any(x => x.TableNumber == tableNumber);

            if (!isExist)
            {
                ModelState.AddModelError("", "There is no table with this number");
                return View();
            }
            var table = dbContext.Table.Where(x => x.TableNumber == tableNumber).Include(x => x.Reservations);

            return View(table);
        }

        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Add(TableViewModel tablevm)
        {
            if (ModelState.IsValid)
            {
                Table table = new Table();
                table.TableNumber = tablevm.TableNumber;
                table.AvabilityStatus = TableAvabilityStatus.Available;
                table.SeatingCapacity = tablevm.SeatingCapacity;

                dbContext.Table.Add(table);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tablevm);
        }
        [HttpGet]
        public IActionResult Update(int tableNumber)
        {

            var table = dbContext.Table.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (table is null)
            {
                ModelState.AddModelError("", "There is no table with this number");
                return View();
            }



            return View(new TableViewModel 
            { SeatingCapacity = table.SeatingCapacity, 
                TableAvabilityStatus = table.AvabilityStatus,
            TableNumber = table.TableNumber});
        }

        [HttpPost]
        public IActionResult Update(int tableNumber, TableViewModel tablevm)
        {
            if (ModelState.IsValid)
            {
                var table = dbContext.Table.FirstOrDefault(x => x.TableNumber == tableNumber);
                if (table is null) return View();
                table.SeatingCapacity = tablevm.SeatingCapacity;
                table.AvabilityStatus = tablevm.TableAvabilityStatus;

                dbContext.Entry(table).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int tableNumber)
        {
            var table = dbContext.Table.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (table is null)
            {
                ModelState.AddModelError("", "There is no table with this number");
                return View();
            }



            return View(new TableViewModel
            {
                SeatingCapacity = table.SeatingCapacity,
                TableAvabilityStatus = table.AvabilityStatus,
                TableNumber=table.TableNumber
            });
        }
        public IActionResult DeleteTable(int tableNumber)
        {

            var table = dbContext.Table.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (table is null)
                return View();
            dbContext.Table.Remove(table);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}

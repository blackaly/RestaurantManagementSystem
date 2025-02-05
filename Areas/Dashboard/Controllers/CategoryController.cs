using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderingSystem.Models.DbContext;
using OrderingSystem.Models.DbModels;
using OrderingSystemDashboard.Models;
using OrderingSystemDashboard.Models.ViewModels;
using OrderingSystemDashboard.Models.ViewModels.Shared;

namespace OrderingSystem.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        OrderDbContext context;
        private readonly IWebHostEnvironment environment;
    
        public CategoryController(OrderDbContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
        }

        public IActionResult Index()
        {
            List<CategoryViewModel> model;
            model = context.Categories.Select(x => new CategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                imageUrl = x.ImageUrl,
            }).ToList();

            ViewData["Categories"] = model;
            return View();
        }

        public IActionResult AddCategory(CategoryViewModel model)
        {
            if(ModelState.IsValid)
            {
                if (model.ImageUrl != null && model.ImageUrl.Length > 0)
                {
                    var uploadsFolder = Path.Combine(environment.WebRootPath, "uploads");
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageUrl.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    try
                    {
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            model.ImageUrl.CopyTo(fileStream);
                        }
                    }
                    catch (Exception ex) 
                    {
                        ModelState.AddModelError("", ex.Message);

                        return View("Index", model);
                    }

                    context.Categories.Add(new Category
                    {
                        Name = model.Name,
                        Description = model.Description,
                        ImageUrl = uniqueFileName
                    });

                    context.SaveChanges();
                }
                return RedirectToAction("AddMenu", "Menu");
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {
            if(id > 0)
            {
                var model = context.Categories.Find(id);

                if (model == null) return RedirectToAction("Index", "Home");

                context.Categories.Remove(model);
                context.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}

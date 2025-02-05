using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrderingSystem.Models.DbModels;
using OrderingSystem.Models.Enums;
using System.Security.Claims;
using WebApplication11.Models.ViewModel;
using OrderingSystem.Externsions;
namespace OrderingSystem.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid) return View(register);

            ApplicationUser user = new ApplicationUser();
            user.FirstName = register.FirstName;
            user.LastName = register.LastName;
            user.Email = register.Email;
            user.UserName = register.UserName;
            user.Address = register.Address;
            

            IdentityResult identityResult = await userManager.CreateAsync(user, register.Password);
            if (identityResult.Succeeded)
            {
                UsersTypes Role = (UsersTypes)register.UserRole;
                await userManager.AddToRoleAsync(user, Role.GetDisplayName());
                await signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            foreach (var item in identityResult.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(register);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login, string ReturnUrl = null)
        {
            if (!ModelState.IsValid) return View(login);

            ApplicationUser user = await userManager.FindByNameAsync(login.UserName);
            if (user != null)
            {
                bool correct = await userManager.CheckPasswordAsync(user, login.Password);
                if (correct)
                {
                    List<Claim> Claims = new List<Claim>();
                    await signInManager.SignInWithClaimsAsync(user, login.RememberMe, Claims);
                    if (ReturnUrl == null) return RedirectToAction("Index", "Home");
                    return RedirectToAction(ReturnUrl);
                }

                ModelState.AddModelError("", "Username Or Password wrong");
            }

            return View(login);
        }

        public async Task<IActionResult> Signout()
        {
            await signInManager.SignOutAsync();
            return View(nameof(Login));
        }
    }
}

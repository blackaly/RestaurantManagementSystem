using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrderingSystem.Models.DbModels;
using OrderingSystem.Models.Enums;
using OrderingSystem.Models.ViewModel;
using System.Security.Claims;

namespace OrderingSystem.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager)
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
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {

            if (ModelState.IsValid)
            {
                //Mapping
                ApplicationUser user = new ApplicationUser();
                user.Email = registerModel.Email;
                user.FirstName = registerModel.FirstName;
                user.LastName = registerModel.LastName;
                user.Address = registerModel.Address;
                user.UserName = registerModel.Email;
                
                //save database
                IdentityResult result =
                    await userManager.CreateAsync(user, registerModel.Password);
                if (result.Succeeded)
                {
                    //assign to role
                        await userManager.AddToRoleAsync(user, "Customer");
                    //Cookie
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
                return View("Register", registerModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginModel, string returnUrl=null)
        {

            if (ModelState.IsValid == true)
            {
                //check found 
                ApplicationUser appUser =
                    await userManager.FindByNameAsync(loginModel.Email);
                if (appUser != null)
                {
                    bool found =
                         await userManager.CheckPasswordAsync(appUser, loginModel.Password);
                    if (found == true)
                    {
                        List<Claim> Claims = new List<Claim>();
                        Claims.Add(new Claim("FirstName", appUser.FirstName));
                        Claims.Add(new Claim("LastName", appUser.LastName));

                        await signInManager.SignInWithClaimsAsync(appUser, false, Claims);
                        return RedirectToAction("Index", "Home");
                    }

                }
                ModelState.AddModelError("", "Username OR PAssword wrong");
                //create cookie
            }
            return View("Login", loginModel);
        }

        public async Task<IActionResult> Signout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}

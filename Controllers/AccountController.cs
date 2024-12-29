using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        public SignInManager<IdentityUser> SignInManager { get; }

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            SignInManager = signInManager;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register (RegisterViewModel model)
        {
            var identityUser = new IdentityUser { UserName = model.Username, Email = model.Email };
            var userCreationResult = await userManager.CreateAsync(identityUser, model.Password);
            if (userCreationResult.Succeeded)
            {
                // seed the user with a role user
                var roleSeedingResult = await userManager.AddToRoleAsync(identityUser,  "User");
                if (roleSeedingResult.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                return View();
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await SignInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpPost]
        public async  Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

using Intro.Models;
using Intro.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Intro.Controllers
{
    public class AccoutController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccoutController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Mapping
                var applicationUser = new ApplicationUser()
                {
                    UserName = model.UserName,
                    PasswordHash = model.Password,
                    Address = model.Address
                };

                //Add User IN DB ==> first 
                var result = await _userManager.CreateAsync(applicationUser, model.Password);//123

                if (result.Succeeded)
                {
                    //Assign User to Role ===> Admin

                    await _userManager.AddToRoleAsync(applicationUser, "Admin");

                    await _signInManager.SignInAsync(applicationUser, isPersistent: false);//session
                    return RedirectToAction("Index", "Department");
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            return View(model);
        }

        /// <summary>
        /// Login Page
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel model)
        {
            //validation ==> state 
            if (ModelState.IsValid)
            {
                //check if user exists 
                var applicationUser = await _userManager.FindByNameAsync(model.UserName);
                if (applicationUser != null)
                {
                    //check user pass ==> 
                    var exists = await _userManager.CheckPasswordAsync(applicationUser, model.Password);
                    if (exists)
                    {
                        //create cookies ==> 
                        //await _signInManager.SignInAsync(applicationUser, model.RemmberMe);//(Id,Name,Role)
                        List<Claim> claims = new List<Claim>();
                        claims.Add(new Claim("userAdderss", applicationUser.Address));
                        await _signInManager.SignInWithClaimsAsync(applicationUser, model.RemmberMe, claims);//Id,Name,Role,userAddress
                        return RedirectToAction("Index", "Department");
                    }
                }
                else
                    ModelState.AddModelError("", "user name or pass is incorrect");
            }

            return View(model);
        }


        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            //return RedirectToAction("Register");
            return RedirectToAction(nameof(Register));
        }

    }
}

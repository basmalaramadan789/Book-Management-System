using assigment.Models;
using assigment.VIEWMODEL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace assigment.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController( UserManager<ApplicationUser> _UserManager,SignInManager<ApplicationUser> _SignInManager)
        {
            userManager = _UserManager;
            signInManager = _SignInManager;
        }
        [HttpGet]
        [Authorize(Roles ="admin")]
        public IActionResult AddAdmin()
        {

            return View(); 
        }
        [HttpPost ]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddAdmin(RegisterUserViewModel uservm)
        {
            if (ModelState.IsValid)
            {
                //create acount
                ApplicationUser usermodel = new ApplicationUser();
                usermodel.UserName = uservm.UserName;
                usermodel.PasswordHash = uservm.password;
                usermodel.Address = uservm.Address;

                IdentityResult result = await userManager.CreateAsync(usermodel, uservm.password);
                if (result.Succeeded == true)
                {
                    //Assign to role
                    await userManager.AddToRoleAsync(usermodel,"admin");
                    //create cookie
                    await signInManager.SignInAsync(usermodel, false);
                    return RedirectToAction("Index", "basmala");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }



            return View(uservm);
        }









        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel uservm)
        {
            if(ModelState.IsValid)
            {
                //create acount
                ApplicationUser usermodel = new ApplicationUser();
                usermodel.UserName = uservm.UserName;
                usermodel.PasswordHash = uservm.password;
                usermodel.Address = uservm.Address;

                IdentityResult result=await userManager.CreateAsync(usermodel,uservm.password);
                if(result .Succeeded==true )
                {
                    //create cookie
                   await signInManager.SignInAsync(usermodel, false);
                   return RedirectToAction("Index", "basmala");
                }
                else
                {
                    foreach(var item in result .Errors )
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }






            return View(uservm);
        }
        [HttpGet]
        public async Task<IActionResult >logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("login", "Account");
        }

        [HttpGet]
        public  IActionResult login()
        {

            return View();

        }
        [HttpPost ]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> login(Loginviwmodel userVmm)
        {
            if (ModelState.IsValid)
            {
               ApplicationUser userapp= await userManager.FindByNameAsync(userVmm.Username);
                if (userapp != null)
                {
                   bool found=await userManager.CheckPasswordAsync(userapp, userVmm.Password);
                    if (found)
                    {
                       await signInManager.SignInAsync(userapp,userVmm.RememberMe);
                        return RedirectToAction("Index", "basmala");
                    }
                }
                ModelState.AddModelError("", "username and password invalid ");
            }
            
            return View(userVmm);
        }




    }
}

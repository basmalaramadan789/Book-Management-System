using assigment.VIEWMODEL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace assigment.Controllers
{
    [Authorize(Roles ="admin")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RolesController(RoleManager<IdentityRole>roleManager )
        {
            this.roleManager = roleManager;
        }




        [HttpGet ]
        public IActionResult newrole()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> newrole(roleviewmodel newrle)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole();
                role.Name = newrle.RoleName;
               IdentityResult result= await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return View(new roleviewmodel());

                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description );  
                    }
                }
            }

            return View(newrle);
        }
    }
}

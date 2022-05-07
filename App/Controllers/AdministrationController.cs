using App.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public AdministrationController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            if (User.IsInRole("Admin"))
            {
                return View("../Administration/CreateRole");
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if(ModelState.IsValid)
            {
                IdentityRole identityRole = new()
                {
                    Name = model.RoleName,
                };

                IdentityResult result = await  roleManager.CreateAsync(identityRole);

                if (result.Succeeded){
                    return RedirectToAction("Index", "Home");
                }
                foreach(IdentityError error in result.Errors){
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult AddAdmin()
        {
            if (User.IsInRole("Admin"))
            {
                return View("../Administration/AddAdmin");
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> AddAdmin(string roleName, AddAdminViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user == null)
                {
                    ViewBag.ErrorMessage = $"user with email : {model.Email} cannot be found";
                    return View("../Administration/AddAdmin");
                }

                IdentityResult result = await userManager.AddToRoleAsync(user, roleName);

                foreach(IdentityError error in result.Errors){
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
    }
}
using App.Models;
using App.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        public AdministrationController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
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
                ApplicationRole identityRole = new()
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
        public IActionResult UserManager()
        {
            if (User.IsInRole("Admin"))
            {
                var users = userManager.GetUsersInRoleAsync("User");
                AddAdmin model = new() {Email="", UserList=users.Result, RoleName=""};
                return View("../Administration/UserManager", model);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> AddAdmin(AddAdmin model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            await userManager.RemoveFromRoleAsync(user, "User");
            IdentityResult result = await userManager.AddToRoleAsync(user, model.RoleName);
            if (result.Succeeded){
                return RedirectToAction("UserManager");
            }
            foreach(IdentityError error in result.Errors){
                ModelState.AddModelError("", error.Description);
            }
            return RedirectToAction("UserManager");
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(int Id)
        {
            var user = await userManager.FindByIdAsync(Id.ToString());
            IdentityResult result = await userManager.DeleteAsync(user);
            if (result.Succeeded){
                return RedirectToAction("UserManager");
            }
            foreach(IdentityError error in result.Errors){
                ModelState.AddModelError("", error.Description);
            }
            return RedirectToAction("UserManager");
        }
    }
}
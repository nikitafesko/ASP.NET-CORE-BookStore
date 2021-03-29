using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models.ViewModels;
using BookStore.Models.ViewModels.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class RolesController : Controller
    {
        public readonly RoleManager<IdentityRole> RoleManager;
        public readonly UserManager<IdentityUser> UserManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.RoleManager = roleManager;
            this.UserManager = userManager;
        }
        public IActionResult Index() => View(RoleManager.Roles.ToList());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (string.IsNullOrEmpty(name)) return View(name);
            var result = await RoleManager.CreateAsync(new IdentityRole(name));
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(name);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            if (role != null)
            {
                await RoleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }

        public IActionResult UserList() => View(UserManager.Users.ToList());

        public async Task<IActionResult> Edit(string userId)
        {
            var user = await UserManager.FindByIdAsync(userId);
            if (user == null) return NotFound();
            
            var userRoles = await UserManager.GetRolesAsync(user);
            var allRoles = RoleManager.Roles.ToList();
            var model = new ChangeRoleViewModel
            {
                UserId = user.Id,
                UserEmail = user.Email,
                UserRoles = userRoles,
                AllRoles = allRoles
            };
            return View(model);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            var user = await UserManager.FindByIdAsync(userId);
            if (user == null) return NotFound();
            
            var userRoles = await UserManager.GetRolesAsync(user);
            var addedRoles = roles.Except(userRoles);
            var removedRoles = userRoles.Except(roles);

            await UserManager.AddToRolesAsync(user, addedRoles);

            await UserManager.RemoveFromRolesAsync(user, removedRoles);

            return RedirectToAction("UserList");
        }
    }
}
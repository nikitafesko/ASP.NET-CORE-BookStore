using System.Linq;
using System.Threading.Tasks;
using BookStore.Models.ViewModels;
using BookStore.Models.ViewModels.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Authorize(Roles = "admin")]
    public class UsersController : Controller
    {
        public readonly UserManager<IdentityUser> UserManager;

        public UsersController(UserManager<IdentityUser> userManager)
        {
            this.UserManager = userManager;
        }

        public IActionResult Index() => View(UserManager.Users.ToList());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var user = new IdentityUser { UserName = model.Name };
            var result = await UserManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var model = new EditUserViewModel { Id = user.Id, Name = user.UserName };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await UserManager.FindByIdAsync(model.Id);

            if (user == null) return View(model);
            user.UserName = model.Name;

            var result = await UserManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            if (user != null)
            {
                var result = await UserManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ChangePassword(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var model = new ChangePasswordViewModel { Id = user.Id, Name = user.UserName };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await UserManager.FindByIdAsync(model.Id);
            if (user != null)
            {
                var passwordValidator =
                    HttpContext.RequestServices.GetService(typeof(IPasswordValidator<IdentityUser>)) as IPasswordValidator<IdentityUser>;
                var passwordHasher =
                    HttpContext.RequestServices.GetService(typeof(IPasswordHasher<IdentityUser>)) as IPasswordHasher<IdentityUser>;

                if (passwordValidator == null) return View(model);
                var result =
                    await passwordValidator.ValidateAsync(UserManager, user, model.NewPassword);
                if (result.Succeeded)
                {
                    if (passwordHasher != null)
                        user.PasswordHash = passwordHasher.HashPassword(user, model.NewPassword);
                    await UserManager.UpdateAsync(user);
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Пользователь не найден");
            }
            return View(model);
        }
    }
}


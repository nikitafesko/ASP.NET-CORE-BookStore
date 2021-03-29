using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Models.Repositories
{
    public static class IdentitySeedData
    {
        private const string AdminUser = "Admin";
        private const string AdminPassword = "Secret123$";

        private const string StoreKeeperUser = "Storekeeper";
        private const string StoreKeeperPassword = "Storekeeper123$";

        private const string UserUser = "User";
        private const string UserPassword = "User123$";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            var userManager = app.ApplicationServices.GetRequiredService<UserManager<IdentityUser>>();

            var user = await userManager.FindByIdAsync(AdminUser);
            if (user == null)
            {
                user = new IdentityUser("Admin");
                await userManager.CreateAsync(user, AdminPassword);
            }            

            user = await userManager.FindByIdAsync(StoreKeeperUser);
            if (user == null)
            {
                user = new IdentityUser("Storekeeper");
                await userManager.CreateAsync(user, StoreKeeperPassword);
            }

            user = await userManager.FindByIdAsync(UserUser);
            if (user == null)
            {
                user = new IdentityUser("User");
                await userManager.CreateAsync(user, UserPassword);
            }
        }
    }
}
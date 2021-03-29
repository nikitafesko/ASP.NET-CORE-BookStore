using BookStore.Components;
using BookStore.Models.Classes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using BookStore.Models.DbContext;
using BookStore.Models.Repositories;
using BookStore.Models.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BookStore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:BookStoreBooks:ConnectionString"]));
            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:BookStoreIdentity:ConnectionString"]));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IBookRepository, EFBookRepository>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();

            services.AddScoped(SessionCart.GetCart);
            services.AddScoped(Storage.GetLocalStorage);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddControllersWithViews();

            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: null,
                    pattern: "{category}/Page{productPage:int}",
                    defaults: new {
                        Controller = "Book", 
                        action = "List"
                    });
                endpoints.MapControllerRoute(
                    name: null,
                    pattern: "Page{productPage:int}",
                    defaults: new { 
                        Controller = "Book", 
                        action = "List", 
                        productPage = 1
                    });
                endpoints.MapControllerRoute(
                    name: "pagination",
                    pattern: "{category}",
                    defaults: new { 
                        Controller = "Book", 
                        action = "List", 
                        productPage = 1
                    });
                endpoints.MapControllerRoute(
                    name: "pagination",
                    pattern: "",
                    defaults: new
                    {
                        Controller = "Book",
                        action = "List",
                        productPage = 1
                    });
                endpoints.MapControllerRoute(
                    name: null,
                    pattern: "{Controller}/{action}/{id?}");
            });

            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PanSport.Infrastructure;
using PanSport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PanSport
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<PanSportDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("PanSportContext"))
            );
            services.AddIdentity<AppUser, IdentityRole>(
                //options=>...
                )
            .AddEntityFrameworkStores<PanSportDbContext>()
            .AddDefaultTokenProviders();


            services.AddSession();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseSession();
            app.UseRouting();


            app.UseAuthentication();
            app.UseAuthorization();




            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller}/{action=Index}/{id?}"
                );


                endpoints.MapControllerRoute(
                    "home",
                    "/",
                    defaults: new
                    {
                        controller = "Home",
                        action = "Index"
                    });
                
                endpoints.MapControllerRoute(
                    "categories",
                    "proizvodi",
                    defaults: new
                    {
                        controller = "Categories",
                        action = "Index"
                    });
                endpoints.MapControllerRoute(
                    "products",
                    "proizvodi/{category}/{product?}",
                    defaults: new
                    {
                        controller = "Products",
                        action = "GetProducts"
                    });

                endpoints.MapControllerRoute(
                     "cart-action",
                     "cart/{action=Index}/{id?}",
                    defaults: new
                    {
                        controller = "Cart"
                    }
                    );

                endpoints.MapControllerRoute(
                     "account-action",
                     "account/{action=Login}",
                    defaults: new
                    {
                        controller = "Account"
                    }
                    );

                endpoints.MapControllerRoute(
                     "notifications-action",
                     "notifications/{action=Index}",
                    defaults: new
                    {
                        controller = "Notifications"
                    }
                    );

                endpoints.MapControllerRoute(
                     "proba-action",
                     "proba/{action=Index}",
                    defaults: new
                    {
                        controller = "Proba"
                    }
                    );


            });
        }
    }
}

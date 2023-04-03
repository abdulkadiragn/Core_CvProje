using DataAccessLayer.Concrete;
using Entity.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_CvPRoje
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Context>();
            services.AddIdentity<WriterUser, WriterRole>().AddEntityFrameworkStores<Context>();
            services.AddControllersWithViews();


            //amaç authentication'u zorunlu kýlmak (admin sayfasýna herkesin eriþememesi için)
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser() //sisteme otorize olmak zorunda.
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddMvc();
            //services.AddAuthentication(
            //    CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(x =>
            //    {
            //        x.LoginPath = "/AdminLogin/Index"; //eðer admin giriþi yapýlmamýþ ise bu cookie adminlogin index'e yönlendirir.
            //    });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true; //cookie sayfa açýkken calýssýn
                options.ExpireTimeSpan = TimeSpan.FromMinutes(100); //otantike olan kullanýcýnýn ne kadar sistemde otantike kalabilecegi. (100 dakika)
                options.AccessDeniedPath = "/ErrorPage/Index"; //eriþimin reddedilmesi durumunda bu sayfaya git.
                options.LoginPath = "/Writer/Login/Index";
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404/"); //bulunmayan bir uzantý ile arama yapýldýgýnda 404 hatasý sayfasýna yönlendir.
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Default}/{action=Index}/{id?}");

            });

            //Area çalýþmasý için
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Default}/{id?}"
                );
            });

        }
    }
}

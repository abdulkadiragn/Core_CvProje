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


            //ama� authentication'u zorunlu k�lmak (admin sayfas�na herkesin eri�ememesi i�in)
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
            //        x.LoginPath = "/AdminLogin/Index"; //e�er admin giri�i yap�lmam�� ise bu cookie adminlogin index'e y�nlendirir.
            //    });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true; //cookie sayfa a��kken cal�ss�n
                options.ExpireTimeSpan = TimeSpan.FromMinutes(100); //otantike olan kullan�c�n�n ne kadar sistemde otantike kalabilecegi. (100 dakika)
                options.AccessDeniedPath = "/ErrorPage/Index"; //eri�imin reddedilmesi durumunda bu sayfaya git.
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
            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404/"); //bulunmayan bir uzant� ile arama yap�ld�g�nda 404 hatas� sayfas�na y�nlendir.
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

            //Area �al��mas� i�in
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

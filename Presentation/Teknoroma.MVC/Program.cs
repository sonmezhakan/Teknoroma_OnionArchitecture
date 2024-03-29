using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Text;
using Teknoroma.Application.Exceptions.Extensions;
using Teknoroma.Persistence.DependencyResolvers;

namespace Teknoroma.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

			builder.Services.AddAplicationServiceRegistration();
			builder.Services.AddPersistenceServiceRegistration();

			//Cookie
			builder.Services.ConfigureApplicationCookie(x =>
            {
                x.Cookie = new CookieBuilder
                {
                    Name = "Login"
                };

                x.LoginPath = new PathString("/Login");
                x.SlidingExpiration = true;
                x.ExpireTimeSpan = TimeSpan.FromDays(1);
            });

			//Session
			builder.Services.AddSession(x =>
			{
				x.Cookie.Name = "product_cart";
				x.IdleTimeout = TimeSpan.FromDays(1);
			});

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePages(async context =>
            {
                if (context.HttpContext.Response.StatusCode == (int)HttpStatusCode.Forbidden)
                {
                    context.HttpContext.Response.Redirect("/Error/Forbidden");
                }
                else if (context.HttpContext.Response.StatusCode == (int)HttpStatusCode.NotFound)
                {
                    context.HttpContext.Response.Redirect("/Error/NotFound");
                }
                else if(context.HttpContext.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
                {
                    context.HttpContext.Response.Redirect("/Login");
                }
                else if(context.HttpContext.Response.StatusCode == (int)HttpStatusCode.InternalServerError)
                {
                    context.HttpContext.Response.Redirect("Error/InternalServer");
                }
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
        

            app.UseAuthentication();
            app.UseAuthorization();

			if (app.Environment.IsProduction())
				//Exceptiom Middleware
				app.ConfigureCustomExceptionMiddleWare();

			app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                

                //custom
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                      name: "areas",
                      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                    );
                });

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                      name: "areas",
                      pattern: "{area:exists}/{controller=Category}/{action=Index}/{id?}"
                    );
                });

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                      name: "areas",
                      pattern: "{area:exists}/{controller=Product}/{action=Index}/{id?}"
                    );
                });

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                      name: "areas",
                      pattern: "{area:exists}/{controller=Customer}/{action=Index}/{id?}"
                    );
                });

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                      name: "areas",
                      pattern: "{area:exists}/{controller=Branch}/{action=Index}/{id?}"
                    );
                });

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                      name: "areas",
                      pattern: "{area:exists}/{controller=Stock}/{action=Index}/{id?}"
                    );
                });

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                      name: "areas",
                      pattern: "{area:exists}/{controller=Department}/{action=Index}/{id?}"
                    );
                });

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                      name: "areas",
                      pattern: "{area:exists}/{controller=StockInput}/{action=Index}/{id?}"
                    );
                });
				app.UseEndpoints(endpoints =>
				{
					endpoints.MapControllerRoute(
					  name: "areas",
					  pattern: "{area:exists}/{controller=Stock}/{action=Index}/{id?}"
					);
				});
				app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                      name: "areas",
                      pattern: "{area:exists}/{controller=Supplier}/{action=Index}/{id?}"
                    );
                });
				app.UseEndpoints(endpoints =>
				{
					endpoints.MapControllerRoute(
					  name: "areas",
					  pattern: "{area:exists}/{controller=AppUser}/{action=Index}/{id?}"
					);
				});
				app.UseEndpoints(endpoints =>
				{
					endpoints.MapControllerRoute(
					  name: "areas",
					  pattern: "{area:exists}/{controller=AppUserProfile}/{action=Index}/{id?}"
					);
				});
				app.UseEndpoints(endpoints =>
				{
					endpoints.MapControllerRoute(
					  name: "areas",
					  pattern: "{area:exists}/{controller=AppUserRole}/{action=Index}/{id?}"
					);
				});
				app.UseEndpoints(endpoints =>
				{
					endpoints.MapControllerRoute(
					  name: "areas",
					  pattern: "{area:exists}/{controller=Employee}/{action=Index}/{id?}"
					);
				});
				app.UseEndpoints(endpoints =>
				{
					endpoints.MapControllerRoute(
					  name: "areas",
					  pattern: "{area:exists}/{controller=Order}/{action=Index}/{id?}"
					);
				});
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                      name: "areas",
                      pattern: "{area:exists}/{controller=TechnicalProblem}/{action=Index}/{id?}"
                    );
                });
				app.UseEndpoints(endpoints =>
				{
					endpoints.MapControllerRoute(
					  name: "areas",
					  pattern: "{area:exists}/{controller=Expense}/{action=Index}/{id?}"
					);
				});


				app.MapControllerRoute(

                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            

            app.Run();
        }
    }
}

using Teknoroma.Persistence.DependencyResolvers;

namespace Teknoroma.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //todo:silme iþlemi sýrasýnda alert çýkartýlacak
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //DbContext Service
            builder.Services.AddDbContextServiceRegistration();

            //Repository  DependencyInjection
            builder.Services.AddRegisterServiceRegistration();

            //Auto Mapper Service
            builder.Services.AddAutoMapperServiceRegistration();

            //Email Service
            builder.Services.AddEmailServiceRegistration();


            //Cookie
            builder.Services.ConfigureApplicationCookie(x =>
            {
                x.Cookie = new CookieBuilder
                {
                    Name = "Login"
                };

                x.LoginPath = new PathString("/Login");
                x.SlidingExpiration = true;
                x.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            });

            builder.Services.AddSession();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
        

            app.UseAuthentication();
            app.UseAuthorization();

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
                      pattern: "{area:exists}/{controller=BranchProduct}/{action=Index}/{id?}"
                    );
                });

                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                      name: "areas",
                      pattern: "{area:exists}/{controller=Department}/{action=Index}/{id?}"
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

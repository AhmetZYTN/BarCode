using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using EFTest02.Data;
using EFTest02.Areas.Identity.Data;

namespace EFTest02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                        var connectionString = builder.Configuration.GetConnectionString("EFTest02ContextConnection") ?? throw new InvalidOperationException("Connection string 'EFTest02ContextConnection' not found.");

                                    builder.Services.AddDbContext<EFTest02Context>(options =>
                options.UseSqlServer(connectionString));

                                                builder.Services.AddDefaultIdentity<EFTest02User>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<EFTest02Context>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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
                        app.UseAuthentication();;

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
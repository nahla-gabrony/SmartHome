using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartHome.Data;
using SmartHome.Data.Hubs;
using SmartHome.Data.MiddlewareExtensions;
using SmartHome.Data.Services;
using SmartHome.Data.SubscribeTableDependencies;
using SmartHome.Data.ViewModels.Email;
using SmartHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SmartHomeContext>(options => options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<SmartHomeContext>().AddDefaultTokenProviders();

            // Add Session 
            services.AddSession(options => {
                options.Cookie.IsEssential = true;
                options.IdleTimeout = TimeSpan.FromMinutes(20);
            });
            services.AddSignalR();

            services.AddControllersWithViews();
            #if DEBUG
                services.AddRazorPages().AddRazorRuntimeCompilation();
            #endif

            //Services
            services.AddScoped<IAccountService,AccountService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IDevicesService, DevicesService>();
            services.AddScoped<INotificationService, NotificationService>();

            //SignalR
            services.AddSingleton<DashboardHub>();
            services.AddSingleton<SubscribeUsersTableDependency>();
            services.AddSingleton<SubscribeDevicesTableDependency>();
            services.AddSingleton<SubscribeNotificationTableDependency>();

            services.Configure<STMPConfigViewModel>(_configuration.GetSection("SMTPConfig"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/Home/Error", "?code={0}");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=SignIn}/{id?}");

                endpoints.MapHub<DashboardHub>("/dashboardHub");
            });

            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            app.UseSqlTableDependency<SubscribeUsersTableDependency>(connectionString);
            app.UseSqlTableDependency<SubscribeDevicesTableDependency>(connectionString);
            app.UseSqlTableDependency<SubscribeNotificationTableDependency>(connectionString);

        }
    }
}

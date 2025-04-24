using Microsoft.EntityFrameworkCore;
using YesilEvMVC.UI.Context;
using Microsoft.AspNetCore.Identity;
using YesilEvMVC.UI;
using YesilEvMVC.UI.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using YesilEvMVC.UI.Helpers;
using YesilEvMVC.UI.Middlewares;
using Serilog;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace YesilEvMVC.UI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Serilog ayarý
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day) // Günlükleri dosyaya kaydet
                .Enrich.FromLogContext() // Ekstra log bilgileri ekle
                .CreateLogger();

            // Serilog'u kullanmak için host'a dahil et
            builder.Host.UseSerilog();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Database Context
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Identity Configuration
            builder.Services.AddIdentity<Kullanici, AppRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            // Authentication Configuration (5 dakikalýk session ayarlarý)
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    // Kullanýcýyý 5 dakika sonra oturumunun sonlandýrýlmasý için ayarlýyoruz
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);  // 5 dakika
                    options.SlidingExpiration = true;  // Her yeni istek geldiðinde süreyi 5 dakikaya resetler
                    options.LoginPath = "/Identity/Account/Login";  // Giriþ yapýlmamýþsa bu sayfaya yönlendirecek
                });

            builder.Services.AddRazorPages();

            // Email sender service
            builder.Services.AddTransient<IEmailSender, EmailSender>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // Geliþtirme modunda hatalarý daha ayrýntýlý göster
            }
            else
            {
                // Prodüksiyon ortamýnda hatalarý error action'a yönlendir
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // HTTPS yönlendirme
            app.UseHttpsRedirection();

            app.UseStaticFiles(); // Statik dosyalarýn servis edilmesi

            app.UseRouting(); // Routing iþlemleri

            app.UseAuthentication(); // Kimlik doðrulama iþlemleri
            app.UseAuthorization(); // Yetkilendirme iþlemleri

            // Custom Middleware (Rol tabanlý eriþim kontrolü)
            app.UseMiddleware<RolTabanliErisimMiddleware>();

            // Default route map
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Razor Pages map
            app.MapRazorPages();

            // Uygulama baþlatma
            app.Run();
        }
    }
}

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

            // Serilog ayar�
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day) // G�nl�kleri dosyaya kaydet
                .Enrich.FromLogContext() // Ekstra log bilgileri ekle
                .CreateLogger();

            // Serilog'u kullanmak i�in host'a dahil et
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

            // Authentication Configuration (5 dakikal�k session ayarlar�)
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    // Kullan�c�y� 5 dakika sonra oturumunun sonland�r�lmas� i�in ayarl�yoruz
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);  // 5 dakika
                    options.SlidingExpiration = true;  // Her yeni istek geldi�inde s�reyi 5 dakikaya resetler
                    options.LoginPath = "/Identity/Account/Login";  // Giri� yap�lmam��sa bu sayfaya y�nlendirecek
                });

            builder.Services.AddRazorPages();

            // Email sender service
            builder.Services.AddTransient<IEmailSender, EmailSender>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // Geli�tirme modunda hatalar� daha ayr�nt�l� g�ster
            }
            else
            {
                // Prod�ksiyon ortam�nda hatalar� error action'a y�nlendir
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // HTTPS y�nlendirme
            app.UseHttpsRedirection();

            app.UseStaticFiles(); // Statik dosyalar�n servis edilmesi

            app.UseRouting(); // Routing i�lemleri

            app.UseAuthentication(); // Kimlik do�rulama i�lemleri
            app.UseAuthorization(); // Yetkilendirme i�lemleri

            // Custom Middleware (Rol tabanl� eri�im kontrol�)
            app.UseMiddleware<RolTabanliErisimMiddleware>();

            // Default route map
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Razor Pages map
            app.MapRazorPages();

            // Uygulama ba�latma
            app.Run();
        }
    }
}

using System.Security.Claims;

namespace YesilEvMVC.UI.Middlewares
{
    public class RolTabanliErisimMiddleware
    {
        private readonly RequestDelegate _next;

        public RolTabanliErisimMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.ToString().ToLower();

            if (!context.User.Identity.IsAuthenticated)
            {
                await _next(context);
                return;
            }

            var userRoles = context.User.Claims
                                .Where(c => c.Type == ClaimTypes.Role)
                                .Select(c => c.Value)
                                .ToList();

            if (path.Contains("/kullanici/logout"))
            {
                await _next(context);
                return;
            }


            // Normal üyelerin yasaklı yolları
            if (userRoles.Contains("Normal"))
            {
                if (path.Contains("/karaliste") || path.Contains("/favori") || path.Contains("/urun/ekle"))
                {
                    context.Response.Redirect("/Hata/ErisimYok");
                    return;
                }
            }

            // Premium üyelerin yasaklı yolları
            if (userRoles.Contains("Premium"))
            {
                if (path.Contains("/kategori") || path.Contains("/uretici") || path.Contains("/icerik"))
                {
                    context.Response.Redirect("/Hata/ErisimYok");
                    return;
                }
            }

            await _next(context);
        }
    }
}

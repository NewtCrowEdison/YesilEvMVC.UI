using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace YesilEvMVC.UI.Helpers
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Dummy - hiçbir şey yapma
            return Task.CompletedTask;
        }
    }
}

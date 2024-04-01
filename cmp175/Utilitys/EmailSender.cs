using Microsoft.AspNetCore.Identity.UI.Services;

namespace Lab3_LTW_TH.Utilitys
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Task.CompletedTask;
        }
    }
}

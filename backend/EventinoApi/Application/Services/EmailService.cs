using System.Threading.Tasks;
using Infrastructure;

namespace Application.Services
{
    public static class EmailService
    {
        public static Task SendConfirmationEmailAsync(string email, string link) =>
            EmailSender.SendEmailAsync(email, "Eventino email confirmation link", $"Please confirm email: {link}");
    }
}

using Infrastructure.Exceptions;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class EmailSender
    {
        public static async Task SendEmailAsync(string email, string subjectMail, string message)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("event-eventov@yandex.ru", "Eventino app");
            var subject = subjectMail;
            var to = new EmailAddress(email, "");
            var plainTextContent = message;
            var htmlContent = $"<strong>{message}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
            if (!response.IsSuccessStatusCode)
                throw new EmailSendException(await response.Body.ReadAsStringAsync());           
        }
    }
}

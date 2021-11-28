using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChoiceHardware.OrdersService.Application.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string emailTo, int monto);
    }
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string emailTo, int monto)
        {
            var apiKey = _configuration["EmailKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("topchoicehardwareunaj@gmail.com", "Top Choice Hardware");
            var subject = "Compra realizada";
            var to = new EmailAddress(emailTo, "Cliente");
            var plainTextContent = "Test";
            var htmlContent = "<p>¡Hola!</p>" +
                "<p>Su orden de compra se realizó exitosamente.</p>" +
                "<p>En breve nos estaremos comunicando con usted para realizar el pago de su compra.</p>" +
                $"<p>El monto por su compra es de: <strong>${monto}</strong></p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}

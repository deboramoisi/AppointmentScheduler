using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace AppointmentScheduler.Utility
{
    public class EmailSender : IEmailSender
    {
        private readonly IOptions<MailJetSettings> _mailjet;

        public EmailSender(IOptions<MailJetSettings> mailjet)
        {
            _mailjet = mailjet;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            MailjetClient client = new MailjetClient(_mailjet.Value.Api_Key, _mailjet.Value.Secret_Key)
            {

            };

            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
            .Property(Send.FromEmail, "contact.contsal@gmail.com")
            .Property(Send.FromName, "Appointment Scheduler")
            .Property(Send.Subject, subject)
            .Property(Send.HtmlPart, htmlMessage)
            .Property(Send.Recipients, new JArray {
                new JObject {
                 {"Email", email}
                 }
                });
            MailjetResponse response = await client.PostAsync(request);
        }
    }
}

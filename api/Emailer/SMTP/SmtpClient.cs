using System.Net.Mail;
using System.Threading.Tasks;

namespace Emailer.SMTP
{
    public class SmtpClient : ISmtpClient
    {
        private System.Net.Mail.SmtpClient _wrappedClient;

        public SmtpClient(System.Net.Mail.SmtpClient wrappedClient)
        {
            _wrappedClient = wrappedClient;
        }

        public Task SendMailAsync(MailMessage message)
        {
            return _wrappedClient.SendMailAsync(message);
        }
    }
}
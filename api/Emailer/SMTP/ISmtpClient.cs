using System.Net.Mail;
using System.Threading.Tasks;

namespace Emailer.SMTP
{
    public interface ISmtpClient
    {
        Task SendMailAsync(MailMessage message);
    }
}
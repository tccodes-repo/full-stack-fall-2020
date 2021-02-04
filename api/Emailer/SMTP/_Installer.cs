using Microsoft.Extensions.DependencyInjection;

namespace Emailer.SMTP
{
    public static class _Installer
    {
        public static IServiceCollection AddSmtp(this IServiceCollection services) => services
            .AddTransient<ISmtpClient>(svc =>
                new SmtpClient(new System.Net.Mail.SmtpClient("127.0.0.1", 1025)));

    }
}
using NUnit.Framework;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using FluentAssertions;

namespace Emailer.SMTP {

    [TestFixture]
    public class _InstallerTests {

        [Test]
        public void Calling_AddSmtp_Should_Register_A_Transient_ISmtpClient() {
            // Assemble / Act
            var services = new ServiceCollection()
                .AddSmtp();

            // Assert
            var registeredService = services.FirstOrDefault(s => 
                s.ServiceType == typeof(ISmtpClient));
            
            Assert.IsNotNull(registeredService);
            registeredService.Lifetime.Should().Be(ServiceLifetime.Transient);

            var serviceProvider = services.BuildServiceProvider();
            serviceProvider
                .GetService<ISmtpClient>()
                .Should().BeOfType<SmtpClient>();

            
            
        }

    }


}
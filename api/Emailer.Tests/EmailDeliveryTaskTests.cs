using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using Emailer.SMTP;
using Emailer.Templates;
using Moq;
using NUnit.Framework;

namespace Emailer
{
    [TestFixture]
    public class EmailDeliveryTaskTests
    {

        private EmailBlastDeliverer _sut;
        private Mock<IEmailBlastRepository> _emailBlastRepository;
        private Mock<ITemplateEngine> _templateEngine;
        private Mock<IEmailRecipientRepository> _recipientRepository;
        private Mock<IRepository<Template>> _templateRepository;
        private Mock<IRepository<Customer>> _customerRepository;
        private Mock<ISmtpClient> _smtpClient;
        
        [SetUp]
        public void SetUp()
        {
            _emailBlastRepository = new Mock<IEmailBlastRepository>();
            _templateEngine = new Mock<ITemplateEngine>();
            _recipientRepository = new Mock<IEmailRecipientRepository>();
            _templateRepository = new Mock<IRepository<Template>>();
            _customerRepository = new Mock<IRepository<Customer>>();
            _smtpClient = new Mock<ISmtpClient>();
            
            _sut = new EmailBlastDeliverer(
                _emailBlastRepository.Object,
                _templateEngine.Object,
                _recipientRepository.Object,
                _templateRepository.Object,
                _customerRepository.Object,
                _smtpClient.Object);
        }

        // TODO: Fix me
        [Test]
        public async Task Should_Not_Send_An_Email_When_Template_Id_Is_Missing()
        {
            /*
            // Arrange
            var stubBlast = new EmailBlast{ Template = "123" };
            _emailBlastRepository.Setup(x =>
                    x.GetPendingEmailBlastsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<EmailBlast>(new [] {stubBlast}));
            
            // Act
            var tcs = new CancellationTokenSource();
            tcs.CancelAfter(TimeSpan.FromSeconds(10));
            await _sut.ExecuteAsync(tcs.Token);
            
            // Assert
            _smtpClient.Verify(x => x.SendMailAsync(It.IsAny<MailMessage>()),
                Times.Never);
                */
        }

        [Test]
        public async Task Should_Send_Emails_To_Recipients_Using_Template()
        {
            // Arrange
            var stubBlast = new EmailBlast
            {
                Customer = "123", 
                Template = "456"
            };
            var stubCustomer = new Customer
            {
                Id = "123",
                FirstName = "Derek",
                LastName = "Smith",
                Email = "derek.smith@gmail.com"
            };
            var stubTemplate = new Template
            {
                Id = "456",
                Name = "Test Template"
            };
            var stubRecipient1 = new EmailRecipient { Email = "recip1@gmail.com" };
            var stubRecipient2 = new EmailRecipient { Email = "recip2@gmail.com" };
            var stubRecipient3 = new EmailRecipient { Email = "recip3@gmail.com" };
            _emailBlastRepository.Setup(x =>
                    x.GetPendingEmailBlastsAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<EmailBlast>(new[] {stubBlast}));
            _templateRepository.Setup(x =>
                    x.GetByIdAsync(stubBlast.Template, It.IsAny<CancellationToken>()))
                .ReturnsAsync(stubTemplate);
            _customerRepository.Setup(x =>
                    x.GetByIdAsync(stubBlast.Customer, It.IsAny<CancellationToken>()))
                .ReturnsAsync(stubCustomer);
            _recipientRepository.Setup(x =>
                    x.GetRecipientsForCustomer(stubBlast.Customer, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new List<EmailRecipient>(new[]
                    {stubRecipient1, stubRecipient2, stubRecipient3}));
            _templateEngine.Setup(x => x.MergeTemplate(It.IsAny<Template>(), It.IsAny<Customer>(),
                    stubRecipient1, It.IsAny<CancellationToken>()))
                .ReturnsAsync("Email to stub recipient 1.");
            _templateEngine.Setup(x => x.MergeTemplate(It.IsAny<Template>(), It.IsAny<Customer>(),
                    stubRecipient2, It.IsAny<CancellationToken>()))
                .ReturnsAsync("Email to stub recipient 2.");
            _templateEngine.Setup(x => x.MergeTemplate(It.IsAny<Template>(), It.IsAny<Customer>(),
                    stubRecipient3, It.IsAny<CancellationToken>()))
                .ReturnsAsync("Email to stub recipient 3.");
            
            // Act
            var cts = new CancellationTokenSource();
            cts.CancelAfter(TimeSpan.FromSeconds(10));
            await _sut.DeliverBlast(stubBlast, cts.Token);
            
            // Assert
            _smtpClient.Verify(x => 
                x.SendMailAsync(It.Is<MailMessage>(m => 
                    m.Body == "Email to stub recipient 1.")), Times.Once);
            _smtpClient.Verify(x => 
                x.SendMailAsync(It.Is<MailMessage>(m => 
                    m.Body == "Email to stub recipient 2.")), Times.Once);
            _smtpClient.Verify(x => 
                x.SendMailAsync(It.Is<MailMessage>(m => 
                    m.Body == "Email to stub recipient 3.")), Times.Once);
        }

    }
}
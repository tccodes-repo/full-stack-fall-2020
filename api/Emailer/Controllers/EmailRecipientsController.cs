using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Emailer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailRecipientsController : Controller
    {
        // GET
        private readonly IRepository<EmailRecipient> _repository;
        private readonly ILogger<EmailRecipientsController> _logger;

        public EmailRecipientsController(IRepository<EmailRecipient> repository, ILogger<EmailRecipientsController> logger)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<EmailRecipient>> Get()
        {
            return await _repository.GetAllAsync();
        }

        [HttpPost]
        public async Task<EmailRecipient> Add([FromBody] EmailRecipient recipient)
        {
            await _repository.AddAsync(recipient);
            return recipient;
        }

        [HttpPut]
        public async Task<EmailRecipient> Update([FromBody] EmailRecipient customer)
        {
            await _repository.UpdateAsync(customer);
            return customer;
        }

        [HttpDelete]
        public async Task Delete([FromBody] EmailRecipient customer)
        {
            await _repository.DeleteAsync(customer);
        }
    }
}
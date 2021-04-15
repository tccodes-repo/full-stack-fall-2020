using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;

namespace Emailer.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CustomersController : ControllerBase
    {

        private readonly IRepository<Customer> _customerRepository;
        private readonly ILogger<CustomersController> _logger;

        public CustomersController(IRepository<Customer> customerRepository, ILogger<CustomersController> logger)
        {
            _logger = logger;
            _customerRepository = customerRepository;
        }

        [HttpGet(Name = "GetCustomers")]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await _customerRepository.GetAllAsync();
        }

        [HttpPost(Name = "AddCustomer")]
        public async Task<Customer> Add([FromBody] Customer customer)
        {
            await _customerRepository.AddAsync(customer);
            return customer;
        }

        [HttpPut(Name = "UpdateCustomer")]
        public async Task<Customer> Update([FromBody] Customer customer)
        {
            await _customerRepository.UpdateAsync(customer);
            return customer;
        }

        [HttpDelete(Name = "DeleteCustomer")]
        public async Task Delete([FromBody] Customer customer)
        {
            await _customerRepository.DeleteAsync(customer);
        }
    }
}
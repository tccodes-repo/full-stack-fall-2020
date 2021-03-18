using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Emailer.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("[controller]")]
    public class EmailBlastsController : Controller
    {

        private IEmailBlastRepository _emailBlastRepository;
        private IEmailBlastUpdateQueue _emailBlastUpdateQueue;

        public EmailBlastsController(IEmailBlastRepository emailBlastRepository, IEmailBlastUpdateQueue emailBlastUpdateQueue)
        {
            _emailBlastRepository = emailBlastRepository;
            _emailBlastUpdateQueue = emailBlastUpdateQueue;
        }
        
        // GET
        [HttpGet(Name = "GetEmailBlasts")]
        public async Task<List<EmailBlast>> Get()
        {
            return await _emailBlastRepository.GetAllAsync();
        }

        [HttpPost(Name = "AddEmailBlast")]
        public async Task<EmailBlast> Add([FromBody] EmailBlast blast)
        {
            await _emailBlastRepository.AddAsync(blast);
            return blast;
        }

        [HttpPut(Name = "UpdateEmailBlast")]
        public async Task<EmailBlast> Update([FromBody] EmailBlast blast)
        {
            await _emailBlastRepository.UpdateAsync(blast);
            if (blast.Id != null) {
                await _emailBlastUpdateQueue.EnqueueUpdateAsync(new EmailBlastUpdate { EmailBlastId = blast.Id });
            }
            return blast;
        }


        [HttpDelete("{id}", Name = "DeleteEmailBlast")]
        public async Task Delete([FromRoute] string id)
        {
            var blast = await _emailBlastRepository.GetByIdAsync(id);
            if (blast != null)
            {
                await _emailBlastRepository.DeleteAsync(blast);
            }
        }
    }
}
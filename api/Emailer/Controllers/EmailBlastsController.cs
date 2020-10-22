using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Emailer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailBlastsController : Controller
    {

        private IEmailBlastRepository _emailBlastRepository;

        public EmailBlastsController(IEmailBlastRepository emailBlastRepository)
        {
            _emailBlastRepository = emailBlastRepository;
        }
        
        // GET
        public async Task<List<EmailBlast>> Get()
        {
            return await _emailBlastRepository.GetAllAsync();
        }

        [HttpPost]
        public async Task<EmailBlast> Add([FromBody] EmailBlast blast)
        {
            await _emailBlastRepository.AddAsync(blast);
            return blast;
        }

        [HttpPut]
        public async Task<EmailBlast> Update([FromBody] EmailBlast blast)
        {
            await _emailBlastRepository.UpdateAsync(blast);
            return blast;
        }

        [HttpDelete]
        [Route("{id}")]
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
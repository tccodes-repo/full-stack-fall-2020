using System.Collections.Generic;
using System.Threading.Tasks;
using Emailer.Templates;
using Microsoft.AspNetCore.Mvc;

namespace Emailer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemplatesController : Controller
    {
        private IRepository<Template> _templateRepository;

        public TemplatesController(IRepository<Template> templateRepository)
        {
            _templateRepository = templateRepository;
        }
        
        // GET
        [HttpGet(Name = "GetTemplates")]
        public async Task<List<Template>> Get()
        {
            return await _templateRepository.GetAllAsync();
        }

        [HttpPost(Name = "AddTemplate")]
        public async Task<Template> Add([FromBody] Template template)
        {
            await _templateRepository.AddAsync(template);
            return template;
        }

        [HttpPut(Name = "UpdateTemplate")]
        public async Task<Template> Update([FromBody] Template template)
        {
            await _templateRepository.UpdateAsync(template);
            return template;
        }

        [HttpDelete(Name = "DeleteTemplate")]
        public async Task Delete([FromQuery] string id)
        {
            var blast = await _templateRepository.GetByIdAsync(id);
            if (blast != null)
            {
                await _templateRepository.DeleteAsync(blast);
            }
        }
    }
}
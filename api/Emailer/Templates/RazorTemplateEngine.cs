using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using RazorLight;

namespace Emailer.Templates
{
    public class RazorTemplateEngine : ITemplateEngine
    {

        private readonly RazorLightEngine _razorEngine;
        private readonly ILogger<RazorTemplateEngine> _logger;

        public RazorTemplateEngine(ILogger<RazorTemplateEngine>? logger = null)
        {
            _razorEngine = new RazorLightEngineBuilder()
                .UseEmbeddedResourcesProject(typeof(Program))
                .UseMemoryCachingProvider()
                .Build();

            _logger = logger ?? NullLogger<RazorTemplateEngine>.Instance;
        }
        
        public async Task<string> MergeTemplate(Template template, Customer customer, EmailRecipient recipient,
            CancellationToken cancellationToken = default)
        {
            
            var model = new
            {
                Customer = customer,
                Recipient = recipient
            };
            
            var cacheResult = _razorEngine.Handler.Cache.RetrieveTemplate(template.Id);
            if (cacheResult.Success)
            {
                _logger.LogDebug($"Found cached template for id {template.Id}");
                var cachedTemplate = cacheResult.Template.TemplatePageFactory();
                return await _razorEngine.RenderTemplateAsync(cachedTemplate, model);
            }


            return await _razorEngine.CompileRenderStringAsync(template.Id, template.Body, model);
        }
    }
}
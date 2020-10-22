using Microsoft.Extensions.DependencyInjection;

namespace Emailer.Templates
{
    public static class _Installer
    {
        public static IServiceCollection AddTemplates(this IServiceCollection services)
        {
            services.AddSingleton<ITemplateEngine, RazorTemplateEngine>();
            return services;
        }
    }
}
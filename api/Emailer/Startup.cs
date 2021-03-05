using Emailer.MongoDb;
using Emailer.SMTP;
using Emailer.Templates;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Impl;

namespace Emailer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddRouting(options => { options.LowercaseUrls = true; })
                .AddMongoDb(Configuration)
                .AddSmtp()
                .AddTemplates()
                .AddScoped<EmailProcessingService>()
                .AddTransient<EmailDeliveryJob>()
                .AddScoped<IEmailBlastDeliverer, EmailBlastDeliverer>()
                .AddSingleton<ISchedulerFactory, EmailerSchedulerFactory>()
                .AddSwaggerGen()
                .AddCors(options =>
                {
                    options.AddDefaultPolicy(policyBuilder =>
                    {
                        policyBuilder.AllowAnyOrigin();
                        policyBuilder.AllowAnyHeader();
                        policyBuilder.AllowAnyMethod();
                    });
                })
                .AddApiVersioning(options =>
                {
                    options.ReportApiVersions = true;
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                    options.AssumeDefaultVersionWhenUnspecified = true;
                })
                .AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseCors();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Emailer API");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
using Emailer.MongoDb;
using Emailer.SMTP;
using Emailer.Templates;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Net.Http;
using System.Linq;
using Quartz;
using Quartz.Impl;
using Emailer.Auth;

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
                .AddScoped<IEmailBlastUpdateQueue, MongoDbEmailBlastUpdateQueue>()
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

                services.AddAuthentication(options => {
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(o => {
                    o.MetadataAddress = "https://www.googleapis.com/oauth2/v3/certs";
                    o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters {
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                    o.IncludeErrorDetails = true;

                    o.Events = new JwtBearerEvents {
                        OnAuthenticationFailed = (ctx) => {
                            return System.Threading.Tasks.Task.CompletedTask;
                        },
                        OnTokenValidated = (ctx) => {   

                            ctx.HttpContext.User = ctx.Principal;
                            return System.Threading.Tasks.Task.CompletedTask;
                        }
                    };         

                    o.ConfigurationManager = new ConfigurationManager<OpenIdConnectConfiguration>(
                        o.MetadataAddress,
                        new JwksConfigurationRetriever(),
                        new HttpDocumentRetriever(new HttpClient(new HttpClientHandler())
                        {
                            Timeout = o.BackchannelTimeout,
                            MaxResponseContentBufferSize = 10485760L
                        })
                        {
                            RequireHttps = false
                        });
                });

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
            app.UseStaticFiles();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Emailer API");
            });
            
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
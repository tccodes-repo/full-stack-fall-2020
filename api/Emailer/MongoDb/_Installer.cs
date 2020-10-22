using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Emailer.MongoDb
{
    public static class _Installer
    {

        public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoSettings>(configuration.GetSection("MongoDb"));

            var mongoSettings = new MongoSettings
            {
                ConnectionString = configuration.GetValue<string>("MongoDb:ConnectionString")
            };
            var mongoClient = new MongoClient(mongoSettings.ConnectionString);

            services.AddScoped<IMongoDatabase>(svc => mongoClient.GetDatabase("emailer"));
            
            services.AddScoped(typeof(IRepository<>), typeof(MongoRepository<>));
            services.AddScoped<IEmailBlastRepository, MongoEmailBlastRepository>();
            services.AddScoped<IEmailRecipientRepository, MongoEmailRecipientRepository>();

            return services;
        }
    }
}
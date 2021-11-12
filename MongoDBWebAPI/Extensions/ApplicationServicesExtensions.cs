using Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using MongoDBWebAPI.Core.Interfaces;
using MongoDBWebAPI.Infrastructure.Data;
using MongoDBWebAPI.Infrastructure.Services;

namespace MongoDBWebAPI.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookService>();

            return services;
        }
    }
}

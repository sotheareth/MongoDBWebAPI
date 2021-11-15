using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using MongoDBWebAPI.Core.Interfaces;
using MongoDBWebAPI.Core.Settings;
using MongoDBWebAPI.Infrastructure.Data;

namespace MongoDBWebAPI.Test
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        public IBookstoreDatabaseSettings BookstoreDatabaseSettings { get; private set; } = new BookstoreDatabaseSettings();

        public IMongoBookStoreDBContext MongoBookStoreDBContext { get; private set; }

        //protected override void ConfigureWebHost(IWebHostBuilder builder)
        //{
        //    builder.ConfigureServices(services =>
        //    {
        //        //var descriptor = services.SingleOrDefault(
        //        //    d => d.ServiceType == typeof(IMongoBookStoreDBContext));

        //        //if (descriptor != null)
        //        //{
        //        //    services.Remove(descriptor);
        //        //}

        //        //var config = new ConfigurationBuilder()
        //        //    .AddJsonFile("appsettings.json")
        //        //    .Build();
                
        //        //config.Bind(nameof(BookstoreDatabaseSettings), BookstoreDatabaseSettings);
        //        //BookstoreDatabaseSettings.DatabaseName = $"test_db_{Guid.NewGuid()}";
                
        //        //this.MongoBookStoreDBContext = new MongoBookStoreDBContext(this.BookstoreDatabaseSettings);
                
        //    });
        //}
    }
}
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoFixture;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using MongoDBWebAPI.Core.Interfaces;
using MongoDBWebAPI.Infrastructure.Data;
using Xunit;

namespace MongoDBWebAPI.Test
{
    public class IntegrationTestBase : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        protected readonly CustomWebApplicationFactory<Startup> _factory;
        protected HttpClient _client;
        protected readonly IMongoBookStoreDBContext _bookStoreDBContext;

        public IntegrationTestBase(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
            _bookStoreDBContext = CreateDbContext();
        }

        private IMongoBookStoreDBContext CreateDbContext()
        {
            var context = _factory.Services.CreateScope().ServiceProvider.GetRequiredService<IMongoBookStoreDBContext>();
            return context;
        }        

    }
}
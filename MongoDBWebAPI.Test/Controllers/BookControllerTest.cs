using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.Net;
using MongoDBWebAPI.Core.Entities.Database;
using System.Collections.Generic;

namespace MongoDBWebAPI.Test.Controllers
{
    public class BookControllerTest : IntegrationTestBase
    {
        public BookControllerTest(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {

        }

        [Fact]
        public async Task GetBookTest()
        {
            //Arrange
            //var books = this._bookStoreDBContext.GetCollection<Book>("Books");
            //var newBook = new Book()
            //{
            //    BookName = "test",
            //    Author = "test",
            //    Category = "test",
            //    Price = 2.0m
            //};
            //books.InsertOne(newBook);

            //Action
            var response = await _client.GetRequest<List<Book>>("book/getcollection");

            //Assert
            response.Should().NotBeNull();
        }

    }
}

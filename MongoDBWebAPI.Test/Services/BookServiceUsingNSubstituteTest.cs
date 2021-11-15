using Microsoft.Extensions.Logging;
using MongoDBWebAPI.Core.Entities.Database;
using MongoDBWebAPI.Core.Interfaces;
using MongoDBWebAPI.Infrastructure.Services;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System.Threading.Tasks;
using Xunit;

namespace TestAspNetCore_XUnitTest.Services
{
    public class BookServiceUsingNSubstituteTest
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BookService> _logger = Substitute.For<ILogger<BookService>>();
        private readonly IBookRepository _bookRepository = Substitute.For<IBookRepository>();

        public BookServiceUsingNSubstituteTest()
        {
            _bookService = new BookService(_bookRepository, _logger);
        }

        [Fact]
        public async Task TestGetCustomerById()
        {
            //Arrange
            var customerId = "";
            var customerResponse = new Book
            {
                Id = "",
                BookName = "test"
            };

            _bookRepository.Get(customerId).Returns(customerResponse);

            //Act
            var result = await _bookService.GetBook(customerId);

            //Assert
            Assert.Equal(customerId, result.Id);
        }

        [Fact]
        public async Task TestGetCustomerById_WhenNotExistCustomer()
        {
            var id = "";

            //Arrange
            _bookRepository.Get(Arg.Any<string>()).ReturnsNull();

            //Act
            var result = await _bookService.GetBook(id);

            //Assert
            Assert.Null(result);
        }
    }
}

using Microsoft.Extensions.Logging;
using MongoDBWebAPI.Core.Entities.Database;
using MongoDBWebAPI.Core.Interfaces;
using MongoDBWebAPI.Infrastructure.Services;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MongoDBWebAPI.Test.Services
{
    public class BookServiceTest
    {
        private readonly IBookService _bookService;
        private readonly Mock<ILogger<BookService>> _logger = new Mock<ILogger<BookService>>();
        private readonly Mock<IBookRepository> _bookRepository = new Mock<IBookRepository>();

        public BookServiceTest()
        {
            _bookService = new BookService(_bookRepository.Object, _logger.Object);
        }

        [Fact]
        public async Task TestGetBookById()
        {
            //Arrange
            var bookId = "";
            var bookResponse = new Book
            {
                BookName = "test",
                Author = "test",
                Category = "test",
                Price = 2.0m
            };

            _bookRepository.Setup(x => x.Get(bookId))
                .ReturnsAsync(bookResponse);

            _bookRepository.Object.Create(bookResponse);

            //Act
            var result = await _bookService.GetBooks();

            //Assert
            //Assert.Equal(bookId, result.Id);
            Assert.True(result.Any());
        }

        //[Fact]
        //public async Task TestGetBookById_WhenNotExistBook()
        //{
        //    var id = "";

        //    //Arrange
        //    _bookRepository.Setup(x => x.Get(It.IsAny<string>()))
        //        .ReturnsAsync(() => null);

        //    //Act
        //    var result = await _bookService.GetBook(id);

        //    //Assert
        //    Assert.Null(result);
        //}

    }
}

using Microsoft.Extensions.Logging;
using MongoDBWebAPI.Core.Entities.Database;
using MongoDBWebAPI.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDBWebAPI.Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BookService> _logger;

        public BookService(IBookRepository bookRepository, ILogger<BookService> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        public Book Create(Book book)
        {
            return _bookRepository.Create(book);
        }

        public async Task Update(Book book)
        {
            await _bookRepository.Update(book.Id, book);
        }

        public async Task<Book> GetBook(string id)
        {
            return await _bookRepository.Get(id);
        }

        public async Task<List<Book>> GetBooks()
        {
            return await _bookRepository.Gets();
        }

        public async Task<List<Book>> GetBooks(int skip, int limit)
        {
            return await _bookRepository.Gets(skip, limit);
        }

    }
}

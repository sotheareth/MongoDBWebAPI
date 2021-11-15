using MongoDB.Driver;
using MongoDBWebAPI.Core.Entities.Database;
using MongoDBWebAPI.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDBWebAPI.Infrastructure.Data
{
    public class BookRepository : IBookRepository
    {

        private readonly IMongoCollection<Book> _books;

        public BookRepository(IMongoBookStoreDBContext context, IBookstoreDatabaseSettings setting)
        {
            _books = context.GetCollection<Book>(setting.BooksCollectionName);
        }

        public async Task<List<Book>> Gets()
        {
            return await _books.Find(b => true).ToListAsync();
        }

        public async Task<List<Book>> Gets(int skip, int limit)
        {
            return await _books.Find(b => true).Skip(skip).Limit(limit).ToListAsync();
        }

        public async Task<Book> Get(string id)
        {
            return await _books.Find(b => b.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public Book Create(Book book)
        {
            _books.InsertOne(book);

            return book;
        }

        public async Task Update(string id, Book book)
        {
            await _books.ReplaceOneAsync(book => book.Id.Equals(id), book);
        }

        public async Task Delete(string id)
        {
            await _books.DeleteOneAsync(book => book.Id.Equals(id));
        }
       
    }
}

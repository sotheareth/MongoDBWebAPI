using MongoDBWebAPI.Core.Entities.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDBWebAPI.Core.Interfaces
{
    public interface IBookService
    {
        Task<Book> GetBook(string id);

        Task<List<Book>> GetBooks();

        Task Update(Book book);

        Book Create(Book book);
    }
}

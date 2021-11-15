using MongoDBWebAPI.Core.Entities.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDBWebAPI.Core.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> Gets();

        Task<List<Book>> Gets(int skip, int limit);

        Task<Book> Get(string id);

        Book Create(Book book);

        Task Update(string id, Book book);

        Task Delete(string id);

    }
}

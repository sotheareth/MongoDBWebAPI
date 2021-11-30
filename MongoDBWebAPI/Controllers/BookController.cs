using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDBWebAPI.Core.DTO.Requests;
using MongoDBWebAPI.Core.Entities.Database;
using MongoDBWebAPI.Core.Interfaces;

namespace MongoDBWebAPI.Controllers
{
    /// <summary>
    /// Book controller.
    /// </summary>
    [ApiController]
    [Route("[controller]/[action]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> logger;
        private readonly IBookService bookService;
        private readonly IMapper mapper;

        /// <summary>
        /// Constructor for book controller.
        /// </summary>
        /// <param name="logger">logger.</param>
        /// <param name="bookService">bookService.</param>
        /// <param name="mapper">Mapper.</param>
        public BookController(ILogger<BookController> logger, IBookService bookService, IMapper mapper)
        {
            this.logger = logger;
            this.bookService = bookService;
            this.mapper = mapper;
        }

        /// <summary>
        /// Test first controller.
        /// </summary>
        /// <returns>string.</returns>
        [HttpGet]
        public IActionResult Test()
        {
            var result = "Hello World!";

            return this.Ok(result);
        }

        /// <summary>
        /// Get all book collection.
        /// </summary>
        /// <returns>book list.</returns>
        [HttpGet]
        public async Task<IActionResult> GetCollection()
        {
            var result = await this.bookService.GetBooks();

            return this.Ok(result);
        }

        /// <summary>
        /// get book by id.
        /// </summary>
        /// <param name="id">book id.</param>
        /// <returns>book object.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await this.bookService.GetBook(id);

            return this.Ok(result);
        }

        /// <summary>
        /// create new book.
        /// </summary>
        /// <param name="request">CreateBookRequestDTO parameter.</param>
        /// <returns>created book object.</returns>
        [HttpPost]
        public IActionResult CreateBook([FromBody] CreateBookRequestDTO request)
        {
            var book = this.mapper.Map<Book>(request);
            var result = this.bookService.Create(book);

            return this.Ok(result);
        }
    }
}

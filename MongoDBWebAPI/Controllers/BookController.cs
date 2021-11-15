using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDBWebAPI.Core.DTO.Requests;
using MongoDBWebAPI.Core.Entities.Database;
using MongoDBWebAPI.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace MongoDBWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BookController(ILogger<BookController> logger, IBookService bookService, IMapper mapper)
        {
            _logger = logger;
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet()]
        public IActionResult Test()
        {
            var result = "Hello World!";

            return Ok(result);
        }

        [HttpGet()]
        public async Task<IActionResult> GetCollection()
        {
            var result = await _bookService.GetBooks();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _bookService.GetBook(id);

            return Ok(result);
        }

        [HttpPost()]
        public IActionResult CreateBook([FromBody] CreateBookRequestDTO request)
        {
            var book = _mapper.Map<Book>(request);
            var result = _bookService.Create(book);

            return Ok(result);
        }
    }
}

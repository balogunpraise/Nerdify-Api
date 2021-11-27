using Microsoft.AspNetCore.Mvc;
using Nerdify.Model;
using NerdifyApi.Interfaces;
using System.Threading.Tasks;

namespace NerdifyApi.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("all-books")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetBooks();
            if (books is not null)
            {
                return Ok(books);
            }
            else
            {
                return BadRequest();
            }


        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Book>> GetBook(string Id)
        {
            var book = await _bookRepository.GetBookById(Id);
            if (book is not null)
            {
                return book;

            }
            else
            {
                return BadRequest();
            }
        }


        [HttpGet("{author}/books")]
        public async Task<IActionResult> GetBooksByAuthor(string author)
        {
            var booksByAuthor = await _bookRepository.GetBooksByAuthor(author);
            if (booksByAuthor is null)
            {
                return NoContent();
            }
            else
            {
                return Ok(booksByAuthor);
            }
        }



        [HttpGet("{title}/book")]
        public async Task<IActionResult> GetBookByTitle(string title)
        {
            var bookByTitle = await _bookRepository.GetBookByTitle(title);
            if (bookByTitle is not null)
            {
                return Ok(bookByTitle);

            }
            else
            {
                return NotFound();
            }
        }



    }
}

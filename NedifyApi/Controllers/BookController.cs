using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Nerdify.Model.Dtos;
using System.Collections.Generic;
using NerdifyApi.ExtensionMethods;
using Nerdify.Data.Interfaces;
using Nerdify.Model;

namespace NerdifyApi.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IGenericRepository<Book> _repo;
        public BookController(IGenericRepository<Book> repo)
        {
            _repo = repo;
        }

        [HttpGet("all-books")]
        public async Task<ActionResult<ICollection<AsBookDto>>> GetAllBooks()
        {
            var books = await _repo.GetBooks();
            var bookDto = new List<AsBookDto>();
            
            if (books is not null)
            {
                foreach (var i in books)
                {
                    
                    bookDto.Add(i.AsDto());
                }
                return Ok(bookDto);
            }
            else
            {
                return BadRequest();
            }


        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<AsBookDto>> GetBook(int Id)
        {
            var book = await _repo.GetBookById(Id);
            if (book is not null)
            {
                return book.AsDto();

            }
            else
            {
                return BadRequest();
            }
        }

    }
}

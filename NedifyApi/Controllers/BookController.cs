using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Nerdify.Model.Dtos;
using System.Collections.Generic;
using NerdifyApi.ExtensionMethods;
using Nerdify.Data.Interfaces;
using Nerdify.Model;
using Nerdify.Model.Specifications;

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
        public async Task<ActionResult<ICollection<AsBookDto>>> GetAllBooks(string sort)
        {
            var spec = new BooksWithAuthorAndSubject(sort);
            var books = await _repo.ListAsync(spec);
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
            var spec = new BooksWithAuthorAndSubject(Id);
            var book = await _repo.GetEntityWithSpec(spec);
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

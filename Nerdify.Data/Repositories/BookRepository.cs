using Microsoft.EntityFrameworkCore;
using Nerdify.Model;
using NerdifyApi.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nerdify.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DatabaseContext _context;
        public BookRepository(DatabaseContext context)
        {
            _context = context;
        }



        public async Task<ICollection<Book>> GetBooks()
        {
            var books = await _context.Books.ToListAsync();
            return books;
        }


        public async Task<Book> GetBookById(string id)
        {
            var book = await _context.Books.FindAsync(id);

            if(book is not null)
            {
                return book;
            }
            else
            {
                return null;
            }
        }


        public async Task<ICollection<Book>> GetBooksByAuthor(string author)
        {
            var booksByAuthor = await _context.Books.Where(x => x.Author == author).ToListAsync();
            if(booksByAuthor.Count != 0)
            {
                return booksByAuthor;
            }
            else
            {
                return null;
            }
        }


        public async Task<Book> GetBookByTitle(string title)
        {
            var bookByTitle = await _context.Books.FindAsync(title);
            if(bookByTitle is not null)
            {
                return bookByTitle;
            }
            else
            {
                return null;
            }
        }

        public async Task<ICollection<Book>> GetBooksBySubJect(string subject)
        {
            var booksByCategory = await _context.Books
                .Include(x => x.Subject)
                .Where(x => x.Subject == subject)
                .ToListAsync();
            return booksByCategory;
        }


        public async Task<ICollection<Book>> GetBooksByYear(int year)
        {
            var booksByYear = await _context.Books.Where(x => x.Year == year).ToListAsync();
            return (booksByYear);
        }


       /* public async Task<ICollection<Book>> GetTopRated()
        {
            var topRatedBooks = await _context.Books
                .Include(x => x.Review)
                .Where(x => x.Review.Rating > 4.5)
                .ToListAsync();
            return topRatedBooks;
        }
*/
    }
}

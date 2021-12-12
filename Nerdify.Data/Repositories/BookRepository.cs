using Microsoft.EntityFrameworkCore;
using Nerdify.Model;
using Nerdify.Model.Dtos;
using NerdifyApi.Interfaces;
using System;
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
            var books = await _context.Books
                //.Include(x => x.Review)
                //.Include(x => x.Rating)
                .Include(x => x.Subject)
                .ThenInclude(x => x.Category)
                .ToListAsync();
            return books;
        }

        

        public async Task<Book> GetBookById(int Id)
        {
            var book = await _context.Books
                //.Include(x => x.Review)
                //.Include(x => x.Rating)
                .Include(x => x.Subject)
                .ThenInclude(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == Id);

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
                .Where(x => x.Subject.Name == subject)
                .ToListAsync();
            return booksByCategory;
        }


        public async Task<ICollection<Book>> GetBooksByYear(int year)
        {
            return await _context.Books.Where(x => x.Year == year).ToListAsync();
           
        }


        public async Task<ICollection<Book>> GetTopRated()
        {
            var topRatedBooks = await _context.Books
                //.Include(x => x.Review)
                .Include(x => x.Subject)
                .ThenInclude(x => x.Category)
                /*.Include(x => x.Rating).OrderByDescending(x => x.Rating)*/.ToListAsync();
            return topRatedBooks;
        }

    }
}

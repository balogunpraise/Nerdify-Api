using Nerdify.Model;
using Nerdify.Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NerdifyApi.Interfaces
{
    public interface IBookRepository
    {
        Task<ICollection<Book>> GetBooks();
        Task<Book> GetBookById(int Id);
        Task<ICollection<Book>> GetBooksByAuthor(string author);
        Task<Book> GetBookByTitle(string title);
        Task<ICollection<Book>> GetBooksBySubJect(string Id);
        Task<ICollection<Book>> GetBooksByYear(int year);
        //Task<ICollection<Book>> GetTopRated();
       
    }
}

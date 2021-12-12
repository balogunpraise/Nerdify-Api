using Nerdify.Model;
using Nerdify.Model.Dtos;

namespace NerdifyApi.ExtensionMethods
{
    public static class Extensions
    {
        public static AsBookDto AsDto(this Book book)
        {
            return new AsBookDto()
            {
                Id = book.Id,
                Title = book.Title,
                Year = book.Year,
                Author = book.Author,
                PictureUrl = book.PictureUrl,
                Description = book.Description,
                //Subject = book.Subject.Name,
                BookNumber = book.BookNumber,
                BookLink = book.BookLink

            };
        }
    }
}

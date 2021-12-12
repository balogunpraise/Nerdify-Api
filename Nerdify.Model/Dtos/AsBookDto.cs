using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nerdify.Model.Dtos
{
    public class AsBookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Author { get; set; }
        public string PictureUrl { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
        public string BookNumber { get; set; }
        public string BookLink { get; set; }
        /*public ICollection<Review> Review { get; set; }
        public ICollection<Rating> Rating { get; set; }*/
    }
}

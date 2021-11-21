using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nerdify.Model
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public string Author { get; set; }
        public string PictureUrl { get; set; }
        public string Description { get; set; }
        public string BookNumber { get; set; }
        public string BookLink { get; set; }
        public Review Review { get; set; }
        public string ReviewId { get; set; }
        public Subject Subject { get; set; }
        public string SubjectId { get; set; }
    }
}

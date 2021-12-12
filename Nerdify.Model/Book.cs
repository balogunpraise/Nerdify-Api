using System;
using System.Collections.Generic;

namespace Nerdify.Model
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string PictureUrl { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public string BookNumber { get; set; }
        public string BookLink { get; set; }
        public ICollection<Review> Review { get; set; }
        public ICollection<Rating> Rating { get; set; }

        
    }
}

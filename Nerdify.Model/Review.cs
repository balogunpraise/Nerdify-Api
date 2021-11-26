using System.Collections.Generic;

namespace Nerdify.Model
{
    public class Review : BaseEntity
    {
        public string UserReview { get; set; }
        public ICollection<Book> Book { get; set; }
        public int Rating { get; set; }
    }
}

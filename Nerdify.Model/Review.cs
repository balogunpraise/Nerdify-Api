using System.Collections.Generic;

namespace Nerdify.Model
{
    public class Review : BaseEntity
    {
        public string UserReview { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}

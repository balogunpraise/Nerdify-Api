using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nerdify.Model
{
    public class Review : BaseEntity
    {
        public string UserReview { get; set; }
        public Book Book { get; set; }
        public string BookId { get; set; }
        public AppUser AppUser { get; set; }
        public string AppuserId { get; set; }
        public int Rating { get; set; }
    }
}

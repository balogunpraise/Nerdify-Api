using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nerdify.Model
{
    public class Rating : BaseEntity
    {
        public float Stars { get; set; }
        public int  Bookid { get; set; }
        public Book Book { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}

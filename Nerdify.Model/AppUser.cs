using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nerdify.Model
{
    public class AppUser :IdentityUser
    {
        public ICollection<Review> Review { get; set; }
        public ICollection<Rating> Rating { get; set; }
    }
}

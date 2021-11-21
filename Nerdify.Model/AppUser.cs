

using Microsoft.AspNet.Identity.EntityFramework;

namespace Nerdify.Model
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string Password { get; set; }
        public string ImgUrl { get; set; }
    }
}

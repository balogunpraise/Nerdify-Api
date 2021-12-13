using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nerdify.Model.Specifications
{
    public class BooksWithAuthorAndSubject : BaseSpecification<Book>
    {
        public BooksWithAuthorAndSubject()
        {
            AddIncludes(x => x.Subject);
            AddIncludes(x => x.Review);
            AddIncludes(x => x.Rating);

        }


        public BooksWithAuthorAndSubject(int id) 
            : base(x => x.Id == id)
        {
            AddIncludes(x => x.Subject);
            AddIncludes(x => x.Review);
            AddIncludes(x => x.Rating);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nerdify.Model.Specifications
{
    public class BooksWithAuthorAndSubject : BaseSpecification<Book>
    {
        public BooksWithAuthorAndSubject(string sort)
        {
            AddIncludes(x => x.Subject);
            AddIncludes(x => x.Review);
            AddIncludes(x => x.Rating);
            AddOrderby(x => x.Title);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "yearAsc":
                        AddOrderby(x => x.Year);
                        break;
                    case "yearDesc":
                        AddOrderbyDescending(x => x.Year);
                        break;
                    default:
                        AddOrderby(n => n.Title);
                        break;
                }
            }

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

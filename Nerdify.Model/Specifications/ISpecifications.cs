using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Nerdify.Model.Specifications
{
    public interface ISpecifications<T>
    {
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; }
    }
}

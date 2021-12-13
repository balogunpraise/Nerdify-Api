using System;
using System.Collections.Generic;
using System.Linq.Expressions;



namespace Nerdify.Model.Specifications
{
    public class BaseSpecification<T> : ISpecifications<T>
    {
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();


        public BaseSpecification()
        {

        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }


        protected void AddIncludes(Expression<Func<T, object>> includeStatement)
        {
            Includes.Add(includeStatement);
        }
    }
}

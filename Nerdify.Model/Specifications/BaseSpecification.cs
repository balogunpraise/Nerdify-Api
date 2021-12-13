using System;
using System.Collections.Generic;
using System.Linq.Expressions;



namespace Nerdify.Model.Specifications
{
    public class BaseSpecification<T> : ISpecifications<T>
    {
        public Expression<Func<T, bool>> Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

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

        protected void AddOrderby(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }


        protected void AddOrderbyDescending(Expression<Func<T, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
        }
    }
}

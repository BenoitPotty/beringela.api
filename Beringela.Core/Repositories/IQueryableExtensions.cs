using System;
using System.Linq;
using System.Linq.Expressions;

namespace Beringela.Core.Repositories
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> OrderByPropertyName<T>(this IQueryable<T> queryable, SortOptions sortOptions = null)
        {
            if (sortOptions?.PropertyName == null) return queryable;
            
            var parameterExpression = Expression.Parameter(typeof(T), nameof(T));
            MemberExpression propertyExpression;
            try
            {
                propertyExpression = Expression.Property(parameterExpression, sortOptions.PropertyName);
            }
            catch (Exception)
            {
                //Property doesn't exist, no sort
                return queryable;
            }

            var lambda = Expression.Lambda(propertyExpression, parameterExpression);
            var methodName = sortOptions.Descending ? "OrderByDescending" : "OrderBy";
            var types = new[] { queryable.ElementType, lambda.Body.Type };
            var rs = Expression.Call(typeof(Queryable), methodName, types, queryable.Expression, lambda);
            return queryable.Provider.CreateQuery<T>(rs);
        }
    }
}

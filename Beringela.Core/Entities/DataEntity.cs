using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Beringela.Core.Entities
{
    public abstract class DataEntity : IDataEntity
    {
        public Guid Id { get; set; } = new Guid();


        

        public static IEnumerable<PropertyInfo> GetAllTextualSearchProperties<T>() where T : IDataEntity
        {
            var propertyInfos = typeof(T).GetProperties();
            return propertyInfos.Where(property =>
                Attribute.IsDefined(property, typeof(TextualSearchAttribute)));
        }

        public static Func<T, bool> GetTextualSearchPredicate<T>(string search) where T : IDataEntity
        {
            var parameterExpression = Expression.Parameter(typeof(T), nameof(T));
            static bool DefaultTextualSearchPredicate(T entity) => true;

            if (string.IsNullOrEmpty(search))
                return DefaultTextualSearchPredicate;

            Expression textualSearchExpression = null;

            var properties = GetAllTextualSearchProperties<T>();
            foreach (var propertyInfo in properties)
            {
               textualSearchExpression =  Or(textualSearchExpression, ContainsSearch(parameterExpression, propertyInfo.Name, search));
            }

            return textualSearchExpression == null ? DefaultTextualSearchPredicate : Expression.Lambda<Func<T, bool>>(textualSearchExpression, parameterExpression).Compile();
        }

        private static Expression ContainsSearch(Expression listOfNames, string propertyName, string search)
        {
            // TODO : Understand that
            // TODO : GetStringComparisonFrom Attribute
            var nameProperty = Expression.Property(listOfNames, propertyName);

            var containsMethodInfo = typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string), typeof(StringComparison) });

            var searchedTextConstantExpression = Expression.Constant(search, typeof(string));
            
            var stringComparisonConstantExpression = Expression.Constant(StringComparison.InvariantCultureIgnoreCase, typeof(StringComparison));

            var containsCallExpression = Expression.Call(nameProperty, containsMethodInfo, searchedTextConstantExpression, stringComparisonConstantExpression);

            var trueConstantExpression = Expression.Constant(true, typeof(bool));

            return Expression.Equal(containsCallExpression, trueConstantExpression);
        }

        private static Expression Or(Expression originalExpression, Expression orExpression)
        {
            return originalExpression == null ? orExpression : Expression.Or(originalExpression, orExpression);
        }
    }
}

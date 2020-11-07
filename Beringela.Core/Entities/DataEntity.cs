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
            //TODO : why ? 
            var parameterExpression = Expression.Parameter(typeof(T), nameof(T));
            static bool DefaultTextualSearchPredicate(T entity) => true;

            if (string.IsNullOrEmpty(search))
                return DefaultTextualSearchPredicate;

            Expression textualSearchExpression = null;

            var properties = GetAllTextualSearchProperties<T>();
            foreach (var propertyInfo in properties)
            {
                // TODO : GetStringComparisonFrom Attribute
                var textualSearchAttribute = (TextualSearchAttribute)propertyInfo.GetCustomAttribute(typeof(TextualSearchAttribute));

                textualSearchExpression =  Or(textualSearchExpression, ContainsSearch(parameterExpression, propertyInfo.Name, search, textualSearchAttribute?.IgnoreCase));
            }

            return textualSearchExpression == null ? DefaultTextualSearchPredicate : Expression.Lambda<Func<T, bool>>(textualSearchExpression, parameterExpression).Compile();
        }

        private static Expression ContainsSearch(Expression listOfNames, string propertyName, string search, bool? ignoreCase)
        {
            
            var nameProperty = Expression.Property(listOfNames, propertyName);

            var containsMethodInfo = typeof(string).GetMethod(nameof(string.Contains), new[] { typeof(string), typeof(StringComparison) });

            var searchedTextConstantExpression = Expression.Constant(search, typeof(string));
            
            var stringComparisonConstantExpression = Expression.Constant(ignoreCase.GetValueOrDefault(true) ? StringComparison.InvariantCultureIgnoreCase : StringComparison.InvariantCulture, typeof(StringComparison));

            var containsCallExpression = Expression.Call(nameProperty, containsMethodInfo, searchedTextConstantExpression, stringComparisonConstantExpression);

            var trueConstantExpression = Expression.Constant(true, typeof(bool));

            var containsExpression = Expression.Equal(containsCallExpression, trueConstantExpression);
                
            var isNullOrEmptyMethodInfo = typeof(string).GetMethod(nameof(string.IsNullOrEmpty), BindingFlags.Public | BindingFlags.Static);

            var isNullOrEmptyCallExpression = Expression.Call(isNullOrEmptyMethodInfo, nameProperty);

            var isNullOrEmptyExpression = Expression.IsFalse(isNullOrEmptyCallExpression);

            return And(isNullOrEmptyExpression, containsExpression);
        }

        private static Expression Or(Expression originalExpression, Expression orExpression)
        {
            return originalExpression == null ? orExpression : Expression.OrElse(originalExpression, orExpression);
        }
        private static Expression And(Expression originalExpression, Expression orExpression)
        {
            return originalExpression == null ? orExpression : Expression.AndAlso(originalExpression, orExpression);
        }
    }
}

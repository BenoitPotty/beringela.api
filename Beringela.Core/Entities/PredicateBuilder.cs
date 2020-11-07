using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Beringela.Core.Entities
{
    public class PredicateBuilder
    {
        private static IEnumerable<PropertyInfo> GetAllTextualSearchProperties<T>() where T : IDataEntity
        {
            var propertyInfos = typeof(T).GetProperties();
            return propertyInfos.Where(property =>
                Attribute.IsDefined(property, typeof(TextualSearchAttribute)));
        }

        public static Func<T, bool> TextualSearch<T>(string search) where T : IDataEntity
        {
            var typeParameterExpression = Expression.Parameter(typeof(T), nameof(T));

            static bool DefaultTextualSearchPredicate(T entity) => true;

            if (string.IsNullOrEmpty(search))
                return DefaultTextualSearchPredicate;

            Expression textualSearchExpression = null;

            var properties = GetAllTextualSearchProperties<T>();
            foreach (var propertyInfo in properties)
            {
                var textualSearchAttribute = (TextualSearchAttribute)propertyInfo.GetCustomAttribute(typeof(TextualSearchAttribute));

                textualSearchExpression = Or(textualSearchExpression, ContainsSearch(typeParameterExpression, propertyInfo.Name, search, textualSearchAttribute?.IgnoreCase));
            }

            return textualSearchExpression == null ? DefaultTextualSearchPredicate : Expression.Lambda<Func<T, bool>>(textualSearchExpression, typeParameterExpression).Compile();
        }

        private static Expression ContainsSearch(Expression propertyExpression, string propertyName, string search, bool? ignoreCase)
        {
            var memberExpression = Expression.Property(propertyExpression, propertyName);

            var containsExpression = StringContains(memberExpression, search, ignoreCase);

            var isNullOrEmptyExpression = StringDefined(memberExpression);

            return And(isNullOrEmptyExpression, containsExpression);
        }

        private static UnaryExpression StringDefined(MemberExpression nameProperty)
        {
            var isNullOrEmptyMethodInfo =
                typeof(string).GetMethod(nameof(string.IsNullOrEmpty), BindingFlags.Public | BindingFlags.Static);

            var isNullOrEmptyCallExpression = Expression.Call(isNullOrEmptyMethodInfo, nameProperty);

            var isNullOrEmptyExpression = Expression.IsFalse(isNullOrEmptyCallExpression);
            return isNullOrEmptyExpression;
        }

        private static BinaryExpression StringContains(MemberExpression memberExpression, string search, bool? ignoreCase)
        {
            var containsMethodInfo =
                typeof(string).GetMethod(nameof(string.Contains), new[] {typeof(string), typeof(StringComparison)});

            var searchedTextConstantExpression = Expression.Constant(search, typeof(string));

            var stringComparisonConstantExpression = Expression.Constant(
                ignoreCase.GetValueOrDefault(true)
                    ? StringComparison.InvariantCultureIgnoreCase
                    : StringComparison.InvariantCulture, typeof(StringComparison));

            var containsCallExpression = Expression.Call(memberExpression, containsMethodInfo, searchedTextConstantExpression,
                stringComparisonConstantExpression);

            var trueConstantExpression = Expression.Constant(true, typeof(bool));

            var containsExpression = Expression.Equal(containsCallExpression, trueConstantExpression);
            return containsExpression;
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

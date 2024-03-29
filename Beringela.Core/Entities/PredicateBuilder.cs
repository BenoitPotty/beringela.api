﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Beringela.Core.Entities
{
    public class PredicateBuilder
    {
        public static Func<T, bool> TextualSearch<T>(string search)
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

        public static Func<T, bool> IdPredicate<T>(Guid id) where T: IDataEntity
        {
            var typeParameterExpression = Expression.Parameter(typeof(T), nameof(T));
            var memberExpression = Expression.Property(typeParameterExpression, nameof(IDataEntity.Id));
            return Expression.Lambda<Func<T, bool>>(GuidEquals(memberExpression, id), typeParameterExpression).Compile();
        }

        private static IEnumerable<PropertyInfo> GetAllTextualSearchProperties<T>()
        {
            var propertyInfos = typeof(T).GetProperties();
            return propertyInfos.Where(property =>
                Attribute.IsDefined(property, typeof(TextualSearchAttribute)));
        }

        private static Expression ContainsSearch(Expression propertyExpression, string propertyName, string search, bool? ignoreCase)
        {
            var memberExpression = Expression.Property(propertyExpression, propertyName);

            var containsExpression = StringContains(memberExpression, search, ignoreCase);

            var isNullOrEmptyExpression = StringDefined(memberExpression);

            return And(isNullOrEmptyExpression, containsExpression);
        }

        private static UnaryExpression StringDefined(Expression memberExpression)
        {
            var isNullOrEmptyMethodInfo =
                typeof(string).GetMethod(nameof(string.IsNullOrEmpty), BindingFlags.Public | BindingFlags.Static);

            var isNullOrEmptyCallExpression = Expression.Call(isNullOrEmptyMethodInfo, memberExpression);

            var isNullOrEmptyExpression = Expression.IsFalse(isNullOrEmptyCallExpression);
            return isNullOrEmptyExpression;
        }

        private static BinaryExpression StringContains(Expression memberExpression, string search, bool? ignoreCase)
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

        private static UnaryExpression GuidEquals(Expression memberExpression, Guid id)
        {
            var guidEqualsMethodInfo =
                typeof(Guid).GetMethod(nameof(Guid.Equals), new[] { typeof(Guid) });

            var searchedTextConstantExpression = Expression.Constant(id, typeof(Guid));

            var guidEqualsCallExpression =
                Expression.Call(memberExpression, guidEqualsMethodInfo, searchedTextConstantExpression);

            return Expression.IsTrue(guidEqualsCallExpression);
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

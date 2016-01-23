using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace EmpleoDotNet.Repository.Helpers
{
    /// <summary>
    /// TODO: Si sacamos estas extensiones de otro sitio, 
    /// sería bueno poner los enlaces de donde lo sacamos para referencia
    /// </summary>
    public static class QueryableExtensions
    {
         /// <summary>
         /// Searches in all string properties for the specifed search key.
         /// It is also able to search for several words. If the searchKey is for example 'John Travolta' then
         /// all records which contain either 'John' or 'Travolta' in some string property
         /// are returned.
         /// </summary>
         /// <typeparam name="T"></typeparam>
         /// <param name="queryable"></param>
         /// <param name="searchKey">The keyword to be search</param>
         /// <returns></returns>
        public static IQueryable<T> FullTextSearch<T>(this IQueryable<T> queryable, string searchKey)
        {
            return FullTextSearch(queryable, searchKey, false);
        }


        /// <summary>
        /// Searches in all string properties for the specifed search key.
        /// It is also able to search for several words. If the searchKey is for example 'John Travolta' then
        /// with exactMatch set to false all records which contain either 'John' or 'Travolta' in some string property
        /// are returned.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="searchKey">The keyword to be search</param>
        /// <param name="exactMatch">Specifies if only the whole word or every single word should be searched.</param>
        /// <returns></returns>
        public static IQueryable<T> FullTextSearch<T>(this IQueryable<T> queryable, string searchKey, bool exactMatch)
        {
            var parameter = Expression.Parameter(typeof(T), "c");

            var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });

            var publicProperties = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Where(p => p.PropertyType == typeof(string));

            var searchKeyParts = exactMatch ? new[] { searchKey } : searchKey.Split(' ');

            var orExpressions = (from property in publicProperties
                select Expression.Property(parameter, property)
                into nameProperty
                from searchKeyPart in searchKeyParts
                let searchKeyExpression = Expression.Constant(searchKeyPart)
                select Expression.Call(nameProperty, containsMethod, searchKeyExpression))
                    .Aggregate<Expression, Expression>(null, 
                        (current, callContainsMethod) =>
                        current == null ? callContainsMethod : Expression.Or(current, callContainsMethod));

            var whereCallExpression = Expression.Call(
                typeof(Queryable),
                "Where",
                new[] { queryable.ElementType },
                queryable.Expression,
                Expression.Lambda<Func<T, bool>>(orExpressions, parameter));

            return queryable.Provider.CreateQuery<T>(whereCallExpression);
        }
    }
}
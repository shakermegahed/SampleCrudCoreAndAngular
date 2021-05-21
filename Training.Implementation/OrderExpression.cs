using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Training.Domain.Enums;

namespace Training.Implementation
{
    public static class OrderExpression
    {
        public static IQueryable<T> KOrderBy<T>(this IQueryable<T> source, string ordering, OrderTypeEnum OrderType, params object[] values)
        {
            string OrderTypeStr = "";
            if (OrderType == OrderTypeEnum.Asc)
            {
                OrderTypeStr = "OrderBy";
            }
            else
            {
                OrderTypeStr = "OrderByDescending";
            }
            var type = typeof(T);

            var property = type.GetProperty(ordering);

            

            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            MethodCallExpression resultExp = Expression.Call(typeof(Queryable), OrderTypeStr, new Type[] { type, property.PropertyType }, source.Expression, Expression.Quote(orderByExp));
            return source.Provider.CreateQuery<T>(resultExp);
        }
     
    }
}

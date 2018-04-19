using System;
using System.Linq.Expressions;
using System.Reflection;

namespace NonFactors.Mvc.Grid.Web.Filters
{
    public class NumberContainsFilter : BaseGridFilter
    {
        public override Expression Apply(Expression expression)
        {
            if (String.IsNullOrEmpty(Value))
                return null;

            MethodInfo toStringMethod = typeof(Int32).GetMethod("ToString", new Type[0]);
            MethodInfo containsMethod = typeof(String).GetMethod("Contains");

            Expression toString = Expression.Call(expression, toStringMethod);
            Expression value = Expression.Constant(Value.ToUpper());

            return Expression.Call(toString, containsMethod, value);
        }
    }
}

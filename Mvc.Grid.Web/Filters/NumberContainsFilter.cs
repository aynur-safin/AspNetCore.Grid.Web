using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace NonFactors.Mvc.Grid.Web.Filters
{
    public class NumberContainsFilter : AGridFilter
    {
        public override Expression? Apply(Expression expression)
        {
            if (Values.Count == 0 || Values.Any(String.IsNullOrEmpty))
                return null;

            return base.Apply(expression);
        }

        protected override Expression? Apply(Expression expression, String? value)
        {
            Expression valueExpression = Expression.Constant(value?.ToUpper());
            MethodInfo toStringMethod = typeof(Int32).GetMethod(nameof(Int32.ToString), new Type[0])!;
            MethodInfo containsMethod = typeof(String).GetMethod(nameof(String.Contains), new[] { typeof(String) })!;

            Expression toString = Expression.Call(expression, toStringMethod);

            return Expression.Call(toString, containsMethod, valueExpression);
        }
    }
}

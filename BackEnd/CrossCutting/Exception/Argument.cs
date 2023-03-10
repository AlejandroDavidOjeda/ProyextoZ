using System.Linq.Expressions;

namespace CrossCutting.Exception
{
    public static class Argument
    {
        public static void ThrowIfNull<T>(Expression<Func<T>> expression)
        {
            Evaluate(expression, out MemberExpression body, out T value);

            ThrowIfNull(value, body.Member.Name);
        }

        private static void Evaluate<T>(Expression<Func<T>> expression, out MemberExpression body, out T value)
        {
            body = (MemberExpression)expression.Body;
            ThrowIfNull(body, nameof(body));

            var compiled = expression.Compile();

            value = compiled();
        }

        private static void ThrowIfNull<T>(T obj, String parameterName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }
    }
}
using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Chat.Core.Extensions
{
    internal static class ExpressionExtensions
    {
        #region Public Methods

        public static T GetPropertyValue<T>(this Expression<Func<T>> lambda) => lambda.Compile().Invoke();

        public static void SetPropertyValue<T>(this Expression<Func<T>> lambda, T value)
        {
            if (lambda.Body is MemberExpression expression)
            {
                var propInfo = (PropertyInfo)expression.Member;
                var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();
                propInfo.SetValue(target, value);
            }
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace FastDatabaseQuery
{
    public static class HelperExpressions
    {

        public static Func<T, T, bool> GreaterThan<T>()
        {
            //TODO: make a static variable to not construct everytime
            // declare the parameters
            ParameterExpression paramA = Expression.Parameter(typeof(T), "a"),
            paramB = Expression.Parameter(typeof(T), "b");
            // add the parameters together
            BinaryExpression body = Expression.GreaterThan(paramA, paramB);
            // compile it
            Func<T, T, bool> gt = Expression.Lambda<Func<T, T, bool>>(body, paramA, paramB).Compile();
            // call it
            return gt;
        }
        private static bool IsNullableType(Type t) { return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>); }
        private static string GetPropertyName(Expression property)
        {
            var expression = GetMemberInfo(property);
            var ret = expression.Member.Name;
            if (expression.Expression != null && expression.Expression.NodeType == ExpressionType.MemberAccess)
            {
                return GetPropertyName(expression.Expression) + "." + ret;
            }
            return ret;


        }

        //http://stackoverflow.com/questions/671968/retrieving-property-name-from-lambda-expression
        private static MemberExpression GetMemberInfo(Expression method)
        {
            if (method.NodeType == ExpressionType.MemberAccess)
            {
                return method as MemberExpression;
            }

            LambdaExpression lambda = method as LambdaExpression;
            if (lambda == null)
                throw new ArgumentNullException("lambda");

            MemberExpression memberExpr = null;

            if (lambda.Body.NodeType == ExpressionType.Convert)
            {
                memberExpr = ((UnaryExpression)lambda.Body).Operand as MemberExpression;
            }
            else if (lambda.Body.NodeType == ExpressionType.MemberAccess)
            {
                memberExpr = lambda.Body as MemberExpression;
            }

            if (memberExpr == null)
                throw new ArgumentException("memberExpr");

            return memberExpr;
        }
        private static Expression PropertyRec(Expression item, string name)
        {
            int dot = name.IndexOf(".");
            if (dot > 0)
            {
                var pm = PropertyRec(item, name.Substring(0, dot));
                return PropertyRec(pm, name.Substring(dot + 1));
            }
            return Expression.Property(item, name);

        }
        public static Expression<Func<U, bool>> PredicateBinary<T, U>(Expression<Func<U, T>> e1, T value, string exp)
        {
            ParameterExpression item = Expression.Parameter(typeof(U), "item");
            BinaryExpression body = null;
            string name = GetPropertyName(e1);
            Expression left = PropertyRec(item, name);
            Expression right = Expression.Constant(value);
            if (IsNullableType(typeof(T)) && !IsNullableType(right.Type))
                right = Expression.Convert(right, typeof(T));
            switch (exp)
            {
                case "equal":
                    body = Expression.Equal(left, right);
                    break;
                case "less":
                    body = Expression.LessThan(left, right);
                    break;
                case "lessorequal":
                    body = Expression.LessThanOrEqual(left, right);
                    break;

                case "greater":
                    body = Expression.GreaterThan(left, right);
                    break;
                case "greaterorequal":
                    body = Expression.GreaterThanOrEqual(left, right);
                    break;
                case "containsinsensitivestring":
                    string val = value.ToString().ToUpper();
                    right = Expression.Constant(val);
                    Expression.Call(Expression.Call(left, "ToUpper", null, null), typeof(string).GetMethod("Contains", new Type[] { typeof(string) }), right);

                    break;
                default:
                    throw new ArgumentException("not know : " + exp);
            }

            Expression<Func<U, bool>> filter = Expression.Lambda<Func<U, bool>>(body, item);
            return filter;
        }
    }
}

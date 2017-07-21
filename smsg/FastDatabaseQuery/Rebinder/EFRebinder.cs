using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
//http://blogs.msdn.com/b/meek/archive/2008/05/02/linq-to-entities-combining-predicates.aspx
namespace EFRebinder
{
    public class ParameterRebinder : ExpressionVisitor
    {

        private readonly Dictionary<ParameterExpression, ParameterExpression> map;



        public ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
        {

            this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();

        }



        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
        {

            return new ParameterRebinder(map).Visit(exp);

        }



        protected override Expression VisitParameter(ParameterExpression p)
        {

            ParameterExpression replacement;

            if (map.TryGetValue(p, out replacement))
            {

                p = replacement;

            }

            return base.VisitParameter(p);

        }

    }
    public static class Utility
    {

        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {

            // build parameter map (from parameters of second to parameters of first)

            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);



            // replace parameters in the second lambda expression with parameters from the first

            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);



            // apply composition of lambda expression bodies to parameters from the first expression 

            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);

        }



        public static Expression<Func<T, bool>> AndRebind<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {

            if (first == null)
                return second;//maybe return null??

            return first.Compose(second, Expression.And);

        }
        public static Expression<Func<T, bool>> AddExpression<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second, Func<Expression,Expression,Expression> merge)
        {

            if (first == null)
                return second;//maybe return null??

            return first.Compose(second, merge);

        }



        public static Expression<Func<T, bool>> OrRebind<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            if (first == null)
                return second;
            return first.Compose(second, Expression.Or);

        }

        //http://www.devlinliles.com/post/Composing-Complex-Queries-with-LINQ-to-Entities.aspx
        public static Expression<Func<T, bool>> BuildOr<T>(params Expression<Func<T, bool>>[] conditions)
        {
            return conditions.Aggregate<Expression<Func<T, bool>>, Expression<Func<T, bool>>>(null, (current, expression) => current == null ? expression : current.OrRebind(expression));
            //var cond = conditions.First();

            //if (conditions.Count() == 1)
            //    return cond;
            
            //foreach (var item in conditions)
            //{                
            //    cond = cond.OrRebind(item);
            //}
            //return cond;
        } 
    }
}

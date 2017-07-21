using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace FastDatabaseQuery
{
    public class FindHelper<T>
        where T:class
    {
        public Expression<Func<T, bool>> custompredicate { get; private set; }
        protected internal ColList<T> ColToLoad;
        public FindHelper(ColList<T> col)
        {
           
            this.ColToLoad = col;
        }
        public FindHelper<T> AddToCustomPredicate2(Expression<Func<T, bool>> pred1, Expression<Func<T, bool>> pred2, bool PutAnd)
        {
            
            AddToCustomPredicate(pred1, PutAnd);
            AddToCustomPredicate(pred2, PutAnd);
            return this;
        }
        public void AddToCustomPredicate(Expression<Func<T, bool>> pred, Func<Expression, Expression, Expression> merge)
        {
            if (pred == null)
                return;

            if (custompredicate == null)
            {
                custompredicate = pred;
                return;
            }
            custompredicate = EFRebinder.Utility.AddExpression(pred, custompredicate, merge);

        }
        public void AddToCustomPredicate(Expression<Func<T, bool>> pred, bool PutAnd=true)
        {
            if (pred == null)
                return;

            if (custompredicate == null)
            {
                custompredicate = pred;
                return;
            }
            if (PutAnd)
            {
                // pred.And(custompredicate);
                custompredicate = EFRebinder.Utility.AndRebind(pred, custompredicate);
            }
            else
            {
                //pred.Or(custompredicate);
                custompredicate = EFRebinder.Utility.OrRebind(pred, custompredicate);
            }
        }
    }
}

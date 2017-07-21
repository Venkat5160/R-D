using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace FastDatabaseQuery
{
   public class FindInDatabase<T> : FindHelper<T> 
        where T: class
    {
        public FindInDatabase(ColList<T> col):base(col)
        {
                
        }
        //http://social.msdn.microsoft.com/forums/en-US/adodotnetentityframework/thread/095745fe-dcf0-4142-b684-b7e4a1ab59f0/
        protected internal Expression<Func<T1, bool>> BuildContainsExpression<T1, TValue>(
    
        Expression<Func<T1, TValue>> valueSelector, IEnumerable<TValue> values)
    
    {
    
        if (null == valueSelector) { throw new ArgumentNullException("valueSelector"); }
    
        if (null == values) { throw new ArgumentNullException("values"); }
    
        ParameterExpression p = valueSelector.Parameters.Single();
    
        // p => valueSelector(p) == values[0] || valueSelector(p) == ...
    
        if (!values.Any())
    
        {
    
            return e => false;
    
        }
    
        var equals = values.Select(item => (Expression)Expression.Equal(valueSelector.Body, Expression.Constant(item, typeof(TValue))));
    
        var body = equals.Aggregate<Expression>((accumulate, equal) => Expression.Or(accumulate, equal));
    
        return Expression.Lambda<Func<T1, bool>>(body, p);
    
    }
        public virtual void LoadFromQueryable(IQueryable<T> iq)
        {
            if(iq == null)
                return;
            foreach(var item in iq)
            {
                ColToLoad.Add(item);
            }
        }
        public virtual IQueryable<T> LoadAllQ()
        {
            return ColToLoad.SelfObjectSet;        
        }
        public virtual void LoadAll()
        {
            LoadFromQueryable(ColToLoad.SelfObjectSet);        
        }
        
    }
}

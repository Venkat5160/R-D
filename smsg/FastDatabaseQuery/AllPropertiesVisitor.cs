using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace FastDatabaseQuery
{
    public class AllPropertiesVisitor : IPropertiesVisitor
    {
        public virtual void BeforeExport()
        {

        }
        public virtual void AfterExport()
        {

        }
        public virtual void BeforeProp()
        {

        }
        public virtual void AfterProp()
        {
            sb.Append(Environment.NewLine);
        }
        protected string FormatString;
        protected StringBuilder sb= new StringBuilder();
        public virtual string Visited(IReceiveVisitor i)
        {
            
            BeforeExport();
            var objectType = i.GetType();
            var properties = objectType.GetProperties();
            //http://msmvps.com/blogs/paulomorgado/archive/2010/08/03/dumping-objects-using-expression-trees.aspx
            var compiledExpressions = (from property in properties
                                       let objectParameter = Expression.Parameter(typeof(object), "o")
                                       select
                                           Expression.Lambda<Func<object, object>>(
                                               Expression.Convert(
                                                   Expression.Property(
                                                       Expression.Convert(
                                                           objectParameter,
                                                           objectType
                                                           ),
                                                       property
                                                       ),
                                                   typeof(object)
                                                   ),
                                               objectParameter
                                           ).Compile()).ToArray<Func<object, object>>();



            foreach (var item in compiledExpressions)
            {
                
                sb.Append(string.Format(FormatString, item.Method.Name, item(i)));
            }
            AfterExport();
            return sb.ToString();
        }



    }
}
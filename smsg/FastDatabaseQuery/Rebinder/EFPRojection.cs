using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Reflection;
using KVP;
namespace EFRebinder
{
    
    //http://www.lostechies.com/blogs/jimmy_bogard/archive/2011/02/09/autoprojecting-linq-queries.aspx
    public interface IProjectionExpression
    {
        IQueryable<TResult> To<TResult>();
        IQueryable<TResult> ToKVPNew<TResult>(string KeyName, string ValueName, string AdditionalDataName=null);
        IQueryable<KVPNew<Tkey, TValue>> ToKVP<Tkey, TValue>(string KeyName, string ValueName, string AdditionalDataName = null);
        IQueryable<KVPNew<long, string>> ToKVPLongString(string KeyName, string ValueName, string AdditionalDataName = null);
        IQueryable<KVPNew<int, string>> ToKVPIntString(string KeyName, string ValueName, string AdditionalDataName = null);
        IQueryable<KVPNew<string, string>> ToKVPStringString(string KeyName, string ValueName, string AdditionalDataName = null);
        IQueryable<KVPNew<Guid, string>> ToKVPGuidString(string KeyName, string ValueName, string AdditionalDataName = null);


    }
    public static class QueryableExtensions
    {

        public static IProjectionExpression Project<TSource>(this IQueryable<TSource> source)
        {
            return new ProjectionExpression<TSource>(source);
        }

    }
    public class ProjectionExpression<TSource>
    : IProjectionExpression
    {
        private readonly IQueryable<TSource> _source;

        public ProjectionExpression(IQueryable<TSource> source)
        {
            _source = source;
        }

        public IQueryable<TResult> To<TResult>()
        {
            Expression<Func<TSource, TResult>> expr = BuildExpression<TResult>();

            return _source.Select(expr);
        }
        public IQueryable<TResult> ToKVPNew<TResult>(string KeyName, string ValueName, string AdditionalDataName = null)           
        {
            Expression<Func<TSource, TResult>> expr = BuildExpressionToKVPNew<TResult>(KeyName,ValueName,AdditionalDataName);
            
            return _source.Select(expr);
        }

        public IQueryable<KVPNew<Tkey, TValue>> ToKVP<Tkey, TValue>(string KeyName, string ValueName, string AdditionalDataName = null)
        {
            var expr = BuildExpressionToKVP<Tkey, TValue>(KeyName, ValueName, AdditionalDataName);
            return _source.Select(expr);
        }

        public IQueryable<KVPNew<long, string>> ToKVPLongString(string KeyName, string ValueName, string AdditionalDataName = null)
        {
            return ToKVP<long, string>(KeyName, ValueName, AdditionalDataName);
        }
        public IQueryable<KVPNew<int, string>> ToKVPIntString(string KeyName, string ValueName, string AdditionalDataName = null)
        {
            return ToKVP<int, string>(KeyName, ValueName, AdditionalDataName);
        }
        public IQueryable<KVPNew<string, string>> ToKVPStringString(string KeyName, string ValueName, string AdditionalDataName = null)
        {
            return ToKVP<string, string>(KeyName, ValueName, AdditionalDataName);
        }
        public IQueryable<KVPNew<Guid, string>> ToKVPGuidString(string KeyName, string ValueName, string AdditionalDataName = null)
        {
            return ToKVP<Guid, string>(KeyName, ValueName, AdditionalDataName);
        }


        static Dictionary<string, object> cache = new Dictionary<string, object>();
        static object mylock = new object();
        private static bool IsNullableType(Type t)
        {

            return t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
        //andrei
        public static Expression<Func<TSource, KVPNew<Tkey,TValue>>> BuildExpressionToKVP<Tkey,TValue>(string KeyName, string ValueName, string AdditionalDataName)            
        {
            return BuildExpressionToKVPNew<KVPNew<Tkey, TValue>>(KeyName, ValueName, AdditionalDataName);
        }
        public static Expression<Func<TSource, TResult>> BuildExpressionToKVPNew<TResult>(string KeyName,string ValueName,string AdditionalDataName)            
        {
            Type s = typeof(TSource);
            Type t = typeof(TResult);
            string key = s.FullName + "_" + t.FullName;
            if (cache.ContainsKey(key))
                return cache[key] as Expression<Func<TSource, TResult>>;
            List<MemberBinding> q = new List<MemberBinding>(2);
            
            lock (mylock)
            {

                if (cache.ContainsKey(key))
                    return cache[key] as Expression<Func<TSource, TResult>>;


                var sourceMembers = s.GetProperties();

                var name = "src";
                var parameterExpression = Expression.Parameter(typeof(TSource), name);


                PropertyInfo piKey = t.GetProperty("Key");
                var source = sourceMembers.FirstOrDefault(pi => pi.Name == KeyName);
                Expression exp = Expression.Property(parameterExpression, source);

                q.Add(Expression.Bind(piKey, exp));

                if (!string.IsNullOrEmpty(ValueName))
                {

                    PropertyInfo piValue = t.GetProperty("Value");
                    source = sourceMembers.FirstOrDefault(pi => pi.Name == ValueName);
                    exp = Expression.Property(parameterExpression, source);
                    q.Add(Expression.Bind(piValue, exp));
                }
                if (!string.IsNullOrEmpty(AdditionalDataName))
                {
                    PropertyInfo piAdd = t.GetProperty("AdditionalData");
                    source = sourceMembers.FirstOrDefault(pi => pi.Name == AdditionalDataName);
                    exp = Expression.Property(parameterExpression, source);
                    q.Add(Expression.Bind(piAdd, exp));
                }
                
                cache.Add(key, Expression.Lambda<Func<TSource, TResult>>(
                    Expression.MemberInit(
                        Expression.New(typeof(TResult)),
                       q.ToArray()
                        ),
                    parameterExpression
                    ));

                return cache[key] as Expression<Func<TSource, TResult>>;
            }

            
        }
        public static Expression<Func<TSource, TResult>> BuildExpression<TResult>()
        {
            Type s = typeof(TSource);
            Type t = typeof(TResult);
            string key = s.FullName + "_" + t.FullName;
            if (cache.ContainsKey(key))
                return cache[key] as Expression<Func<TSource, TResult>>;


            lock (mylock)
            {
                if (cache.ContainsKey(key))
                    return cache[key] as Expression<Func<TSource, TResult>>;


                var sourceMembers = s.GetProperties();
                var destinationMembers = typeof(TResult).GetProperties();

                var name = "src";

                var parameterExpression = Expression.Parameter(typeof(TSource), name);
                List<MemberBinding> q = new List<MemberBinding>(destinationMembers.Count());
                foreach (var dest in destinationMembers)
                {
                    
                    string Name = dest.Name;
                    var source = sourceMembers.FirstOrDefault(pi => pi.Name == Name);
                    
                    if (source != null)
                    {
                        Expression exp = Expression.Property(parameterExpression, source);
                        if (dest.PropertyType.IsEnum)
                        {
                            exp = Expression.Convert(exp, dest.PropertyType);
                        }
                        if (IsNullableType(source.PropertyType) && !IsNullableType(dest.PropertyType))
                        {
                            var item = Activator.CreateInstance(dest.PropertyType);
                            exp=Expression.Coalesce(exp,Expression.Constant(item));
                        }
                        q.Add(Expression.Bind(dest,exp));
                        continue;
                    }
                    int i = 0;
                    while ((i = Name.IndexOf("_", i + 1)) > 1)
                    {
                        string newprop = Name.Substring(0, i);
                        source = sourceMembers.FirstOrDefault(pi => pi.Name == newprop);
                        if (source != null)
                        {
                            var propClass = Expression.Property(
                                parameterExpression,
                                source

                                );
                            var prop = Expression.Property(propClass, Name.Substring(i + 1));
                            q.Add(Expression.Bind(dest, prop));
                        }

                    }


                }
                q.TrimExcess();
                cache.Add(key, Expression.Lambda<Func<TSource, TResult>>(
                    Expression.MemberInit(
                        Expression.New(typeof(TResult)),
                       q.ToArray()
                        ),
                    parameterExpression
                    ));
                return cache[key] as Expression<Func<TSource, TResult>>;
            }
        }
    }
}

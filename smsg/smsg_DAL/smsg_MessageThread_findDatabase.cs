//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq.Expressions;
using System.Data.Objects;
using System.Linq;
using System.Reflection;
using smsg_DAL;
using FastDatabaseQuery;
using System.Data.Entity;

namespace smsg_DAL
{
    
    public partial class smsg_MessageThread_FindDB : FindInDatabase<smsg_MessageThread>
    {
        
        public static Expression<Func<smsg_MessageThread, long>> exp_IDMessageThread = (item => item.IDMessageThread );
        public static Func<long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageThread = value => (item => 
                // item.IDMessageThread != null  &&  
                item.IDMessageThread == value);
        //TODO: find who supports this!   
    	////    a// a
        //public static Func<long,long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageThreadBetween = (value1,value2) => (item => item.IDMessageThread> value1 && item.IDMessageThread<value2);
    	//public static Func<long,long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageThreadBetweenEq = (value1,value2) => (item => item.IDMessageThread >= value1 && item.IDMessageThread <= value2);
    	//public static Func<long,long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageThreadBetweenEqDate = (value1,value2) =>{
    	//		value1=
    	//			//value1.Value.Date ;
    	//			value1.Date ;
    	//		value2=
    	//			//value2.Value.Date.AddDays(1) ;
    	//			value2.Date.AddDays(1) ;	
    	//		return (item => item.IDMessageThread >= value1 && item.IDMessageThread < value2);
    	// };
    	//public static Func<long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageThreadGreater = (value =>(item => item.IDMessageThread > value));
    	//public static Func<long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageThreadGreaterEq = (value => (item =>item.IDMessageThread >= value));
    	//public static Func<long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageThreadLess = (value => (item =>item.IDMessageThread < value));
    	//public static Func<long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageThreadLessEq = (value => (item =>item.IDMessageThread <= value));
        //public static Func<long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageThreadGreater = value => (item => HelperExpressions.GreaterThan<long>()(item.IDMessageThread ,value));
        //public static Func<long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageThreadLess = value => (item => HelperExpressions.GreaterThan<long>()(value, item.IDMessageThread ));
        // public static Func<long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageThreadContains = value => (item =>  item.IDMessageThread != null  &&  item.IDMessageThread.Contains(value));
        // public static Func<long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageThreadStartsWith = value => (item =>  item.IDMessageThread != null  &&  item.IDMessageThread.StartsWith(value));
    	// public IQueryable<smsg_MessageThread> LoadFrom_IDMessageThreadContainsQ(string value)
    	// {
    	//  return this.ObjectSetWithInclude().Where(fexp_IDMessageThreadContains(value));
    	//  }
    	// public static Func<long,string, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageThreadContainsMultiple = (value,separator) => 
    	//	{
    	//		value=value.ToLower();
    	//		var arr=value.Split(new string[1]{separator}, StringSplitOptions.RemoveEmptyEntries);
    	//		switch(arr.Length)//TODO: use a better expression here rahter than based on length 
    	//		{
    	//			case 1:
    	//				return (item =>  item.IDMessageThread != null  &&  item.IDMessageThread.ToLower().Contains(value));
    	//			case 2:
    	//				 {
    	//				  string v1=arr[0].Replace(separator,"");
    	//				  string v2=arr[1].Replace(separator,"");				
    	//				 return (item =>  item.IDMessageThread != null  &&  item.IDMessageThread.ToLower().Contains(v1)  &&  item.IDMessageThread.ToLower().Contains(v2) );		
    	//				}
    	//			default:
    	//				 {
    	//				   string v1=arr[0].Replace(separator,"");
    	//				  string v2=arr[1].Replace(separator,"");
    	//				  string v3=arr[2].Replace(separator,"");
    	//				return (item =>  item.IDMessageThread != null  &&  item.IDMessageThread.ToLower().Contains(v1) &&  item.IDMessageThread.ToLower().Contains(v2) &&  item.IDMessageThread.ToLower().Contains(v3) );
    	//				}
    	//
    	//		}
    	//			
    	//
    	//	};	 
    	// public static Func<string, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageThreadContainsMultipleDef = value => fexp_IDMessageThreadContainsMultiple(value, "%");
        
        public static Expression<Func<smsg_MessageThread, long>> exp_IDMessageInitial = (item => item.IDMessageInitial );
        public static Func<long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageInitial = value => (item => 
                // item.IDMessageInitial != null  &&  
                item.IDMessageInitial == value);
        //TODO: find who supports this!   
    	////    a// a
        //public static Func<long,long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageInitialBetween = (value1,value2) => (item => item.IDMessageInitial> value1 && item.IDMessageInitial<value2);
    	//public static Func<long,long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageInitialBetweenEq = (value1,value2) => (item => item.IDMessageInitial >= value1 && item.IDMessageInitial <= value2);
    	//public static Func<long,long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageInitialBetweenEqDate = (value1,value2) =>{
    	//		value1=
    	//			//value1.Value.Date ;
    	//			value1.Date ;
    	//		value2=
    	//			//value2.Value.Date.AddDays(1) ;
    	//			value2.Date.AddDays(1) ;	
    	//		return (item => item.IDMessageInitial >= value1 && item.IDMessageInitial < value2);
    	// };
    	//public static Func<long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageInitialGreater = (value =>(item => item.IDMessageInitial > value));
    	//public static Func<long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageInitialGreaterEq = (value => (item =>item.IDMessageInitial >= value));
    	//public static Func<long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageInitialLess = (value => (item =>item.IDMessageInitial < value));
    	//public static Func<long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageInitialLessEq = (value => (item =>item.IDMessageInitial <= value));
        //public static Func<long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageInitialGreater = value => (item => HelperExpressions.GreaterThan<long>()(item.IDMessageInitial ,value));
        //public static Func<long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageInitialLess = value => (item => HelperExpressions.GreaterThan<long>()(value, item.IDMessageInitial ));
        // public static Func<long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageInitialContains = value => (item =>  item.IDMessageInitial != null  &&  item.IDMessageInitial.Contains(value));
        // public static Func<long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageInitialStartsWith = value => (item =>  item.IDMessageInitial != null  &&  item.IDMessageInitial.StartsWith(value));
    	// public IQueryable<smsg_MessageThread> LoadFrom_IDMessageInitialContainsQ(string value)
    	// {
    	//  return this.ObjectSetWithInclude().Where(fexp_IDMessageInitialContains(value));
    	//  }
    	// public static Func<long,string, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageInitialContainsMultiple = (value,separator) => 
    	//	{
    	//		value=value.ToLower();
    	//		var arr=value.Split(new string[1]{separator}, StringSplitOptions.RemoveEmptyEntries);
    	//		switch(arr.Length)//TODO: use a better expression here rahter than based on length 
    	//		{
    	//			case 1:
    	//				return (item =>  item.IDMessageInitial != null  &&  item.IDMessageInitial.ToLower().Contains(value));
    	//			case 2:
    	//				 {
    	//				  string v1=arr[0].Replace(separator,"");
    	//				  string v2=arr[1].Replace(separator,"");				
    	//				 return (item =>  item.IDMessageInitial != null  &&  item.IDMessageInitial.ToLower().Contains(v1)  &&  item.IDMessageInitial.ToLower().Contains(v2) );		
    	//				}
    	//			default:
    	//				 {
    	//				   string v1=arr[0].Replace(separator,"");
    	//				  string v2=arr[1].Replace(separator,"");
    	//				  string v3=arr[2].Replace(separator,"");
    	//				return (item =>  item.IDMessageInitial != null  &&  item.IDMessageInitial.ToLower().Contains(v1) &&  item.IDMessageInitial.ToLower().Contains(v2) &&  item.IDMessageInitial.ToLower().Contains(v3) );
    	//				}
    	//
    	//		}
    	//			
    	//
    	//	};	 
    	// public static Func<string, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageInitialContainsMultipleDef = value => fexp_IDMessageInitialContainsMultiple(value, "%");
        
        public static Expression<Func<smsg_MessageThread, long>> exp_IDMessageReply = (item => item.IDMessageReply );
        public static Func<long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageReply = value => (item => 
                // item.IDMessageReply != null  &&  
                item.IDMessageReply == value);
        //TODO: find who supports this!   
    	////    a// a
        //public static Func<long,long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageReplyBetween = (value1,value2) => (item => item.IDMessageReply> value1 && item.IDMessageReply<value2);
    	//public static Func<long,long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageReplyBetweenEq = (value1,value2) => (item => item.IDMessageReply >= value1 && item.IDMessageReply <= value2);
    	//public static Func<long,long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageReplyBetweenEqDate = (value1,value2) =>{
    	//		value1=
    	//			//value1.Value.Date ;
    	//			value1.Date ;
    	//		value2=
    	//			//value2.Value.Date.AddDays(1) ;
    	//			value2.Date.AddDays(1) ;	
    	//		return (item => item.IDMessageReply >= value1 && item.IDMessageReply < value2);
    	// };
    	//public static Func<long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageReplyGreater = (value =>(item => item.IDMessageReply > value));
    	//public static Func<long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageReplyGreaterEq = (value => (item =>item.IDMessageReply >= value));
    	//public static Func<long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageReplyLess = (value => (item =>item.IDMessageReply < value));
    	//public static Func<long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageReplyLessEq = (value => (item =>item.IDMessageReply <= value));
        //public static Func<long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageReplyGreater = value => (item => HelperExpressions.GreaterThan<long>()(item.IDMessageReply ,value));
        //public static Func<long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageReplyLess = value => (item => HelperExpressions.GreaterThan<long>()(value, item.IDMessageReply ));
        // public static Func<long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageReplyContains = value => (item =>  item.IDMessageReply != null  &&  item.IDMessageReply.Contains(value));
        // public static Func<long, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageReplyStartsWith = value => (item =>  item.IDMessageReply != null  &&  item.IDMessageReply.StartsWith(value));
    	// public IQueryable<smsg_MessageThread> LoadFrom_IDMessageReplyContainsQ(string value)
    	// {
    	//  return this.ObjectSetWithInclude().Where(fexp_IDMessageReplyContains(value));
    	//  }
    	// public static Func<long,string, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageReplyContainsMultiple = (value,separator) => 
    	//	{
    	//		value=value.ToLower();
    	//		var arr=value.Split(new string[1]{separator}, StringSplitOptions.RemoveEmptyEntries);
    	//		switch(arr.Length)//TODO: use a better expression here rahter than based on length 
    	//		{
    	//			case 1:
    	//				return (item =>  item.IDMessageReply != null  &&  item.IDMessageReply.ToLower().Contains(value));
    	//			case 2:
    	//				 {
    	//				  string v1=arr[0].Replace(separator,"");
    	//				  string v2=arr[1].Replace(separator,"");				
    	//				 return (item =>  item.IDMessageReply != null  &&  item.IDMessageReply.ToLower().Contains(v1)  &&  item.IDMessageReply.ToLower().Contains(v2) );		
    	//				}
    	//			default:
    	//				 {
    	//				   string v1=arr[0].Replace(separator,"");
    	//				  string v2=arr[1].Replace(separator,"");
    	//				  string v3=arr[2].Replace(separator,"");
    	//				return (item =>  item.IDMessageReply != null  &&  item.IDMessageReply.ToLower().Contains(v1) &&  item.IDMessageReply.ToLower().Contains(v2) &&  item.IDMessageReply.ToLower().Contains(v3) );
    	//				}
    	//
    	//		}
    	//			
    	//
    	//	};	 
    	// public static Func<string, Expression<Func<smsg_MessageThread, bool>>> fexp_IDMessageReplyContainsMultipleDef = value => fexp_IDMessageReplyContainsMultiple(value, "%");
        
        public static Expression<Func<smsg_MessageThread, System.DateTime>> exp_DateInserted = (item => item.DateInserted );
        public static Func<System.DateTime, Expression<Func<smsg_MessageThread, bool>>> fexp_DateInserted = value => (item => 
                // item.DateInserted != null  &&  
                item.DateInserted == value);
        //TODO: find who supports this!   
    	//    a// a
        public static Func<System.DateTime,System.DateTime, Expression<Func<smsg_MessageThread, bool>>> fexp_DateInsertedBetween = (value1,value2) => (item => item.DateInserted> value1 && item.DateInserted<value2);
    	public static Func<System.DateTime,System.DateTime, Expression<Func<smsg_MessageThread, bool>>> fexp_DateInsertedBetweenEq = (value1,value2) => (item => item.DateInserted >= value1 && item.DateInserted <= value2);
    	public static Func<System.DateTime,System.DateTime, Expression<Func<smsg_MessageThread, bool>>> fexp_DateInsertedBetweenEqDate = (value1,value2) =>{
    			value1=
    				//value1.Value.Date ;
    				value1.Date ;
    			value2=
    				//value2.Value.Date.AddDays(1) ;
    				value2.Date.AddDays(1) ;	
    			return (item => item.DateInserted >= value1 && item.DateInserted < value2);
    	 };
    	public static Func<System.DateTime, Expression<Func<smsg_MessageThread, bool>>> fexp_DateInsertedGreater = (value =>(item => item.DateInserted > value));
    	public static Func<System.DateTime, Expression<Func<smsg_MessageThread, bool>>> fexp_DateInsertedGreaterEq = (value => (item =>item.DateInserted >= value));
    	public static Func<System.DateTime, Expression<Func<smsg_MessageThread, bool>>> fexp_DateInsertedLess = (value => (item =>item.DateInserted < value));
    	public static Func<System.DateTime, Expression<Func<smsg_MessageThread, bool>>> fexp_DateInsertedLessEq = (value => (item =>item.DateInserted <= value));
        //public static Func<System.DateTime, Expression<Func<smsg_MessageThread, bool>>> fexp_DateInsertedGreater = value => (item => HelperExpressions.GreaterThan<System.DateTime>()(item.DateInserted ,value));
        //public static Func<System.DateTime, Expression<Func<smsg_MessageThread, bool>>> fexp_DateInsertedLess = value => (item => HelperExpressions.GreaterThan<System.DateTime>()(value, item.DateInserted ));
        // public static Func<System.DateTime, Expression<Func<smsg_MessageThread, bool>>> fexp_DateInsertedContains = value => (item =>  item.DateInserted != null  &&  item.DateInserted.Contains(value));
        // public static Func<System.DateTime, Expression<Func<smsg_MessageThread, bool>>> fexp_DateInsertedStartsWith = value => (item =>  item.DateInserted != null  &&  item.DateInserted.StartsWith(value));
    	// public IQueryable<smsg_MessageThread> LoadFrom_DateInsertedContainsQ(string value)
    	// {
    	//  return this.ObjectSetWithInclude().Where(fexp_DateInsertedContains(value));
    	//  }
    	// public static Func<System.DateTime,string, Expression<Func<smsg_MessageThread, bool>>> fexp_DateInsertedContainsMultiple = (value,separator) => 
    	//	{
    	//		value=value.ToLower();
    	//		var arr=value.Split(new string[1]{separator}, StringSplitOptions.RemoveEmptyEntries);
    	//		switch(arr.Length)//TODO: use a better expression here rahter than based on length 
    	//		{
    	//			case 1:
    	//				return (item =>  item.DateInserted != null  &&  item.DateInserted.ToLower().Contains(value));
    	//			case 2:
    	//				 {
    	//				  string v1=arr[0].Replace(separator,"");
    	//				  string v2=arr[1].Replace(separator,"");				
    	//				 return (item =>  item.DateInserted != null  &&  item.DateInserted.ToLower().Contains(v1)  &&  item.DateInserted.ToLower().Contains(v2) );		
    	//				}
    	//			default:
    	//				 {
    	//				   string v1=arr[0].Replace(separator,"");
    	//				  string v2=arr[1].Replace(separator,"");
    	//				  string v3=arr[2].Replace(separator,"");
    	//				return (item =>  item.DateInserted != null  &&  item.DateInserted.ToLower().Contains(v1) &&  item.DateInserted.ToLower().Contains(v2) &&  item.DateInserted.ToLower().Contains(v3) );
    	//				}
    	//
    	//		}
    	//			
    	//
    	//	};	 
    	// public static Func<string, Expression<Func<smsg_MessageThread, bool>>> fexp_DateInsertedContainsMultipleDef = value => fexp_DateInsertedContainsMultiple(value, "%");
        
       
        
        public smsg_MessageThread_FindDB(ColList<smsg_MessageThread> col):base(col)
        {
     
            
        
                    
        }
        
    
        
        
        public IQueryable<smsg_MessageThread> LoadFrom_IDMessageThreadQ(long Value)
                {
                    
                    return LoadFrom1PropertyQ(exp_IDMessageThread, Value);
    
                }
        public void LoadFrom_IDMessageThread(long Value)
                {
                    
                    this.LoadFromQueryable( LoadFrom_IDMessageThreadQ(Value));
    
                }
        public IQueryable<smsg_MessageThread> LoadFindIDsColumn_IDMessageThreadQ(long[] ColumnValues)
        {
            return LoadFindIDsColumnQ<long>(ColumnValues,"IDMessageThread"); 
        }
        public void LoadFindIDsColumn_IDMessageThread(long[] ColumnValues)
        {
            this.LoadFromQueryable(LoadFindIDsColumnQ<long>(ColumnValues,"IDMessageThread")); 
        }
    
    
    	public IQueryable<smsg_MessageThread> LoadFindIDsColumn_IDMessageThreadQ(List<long> ColumnValues)
        {
            return LoadFindIDsColumn_IDMessageThreadQ(ColumnValues.ToArray<long>()); 
        }
        public void LoadFindIDsColumn_IDMessageThread(List<long> ColumnValues)
        {
            this.LoadFindIDsColumn_IDMessageThread(ColumnValues.ToArray<long>()); 
        }
                
        public IQueryable<smsg_MessageThread> LoadFrom_IDMessageInitialQ(long Value)
                {
                    
                    return LoadFrom1PropertyQ(exp_IDMessageInitial, Value);
    
                }
        public void LoadFrom_IDMessageInitial(long Value)
                {
                    
                    this.LoadFromQueryable( LoadFrom_IDMessageInitialQ(Value));
    
                }
        public IQueryable<smsg_MessageThread> LoadFindIDsColumn_IDMessageInitialQ(long[] ColumnValues)
        {
            return LoadFindIDsColumnQ<long>(ColumnValues,"IDMessageInitial"); 
        }
        public void LoadFindIDsColumn_IDMessageInitial(long[] ColumnValues)
        {
            this.LoadFromQueryable(LoadFindIDsColumnQ<long>(ColumnValues,"IDMessageInitial")); 
        }
    
    
    	public IQueryable<smsg_MessageThread> LoadFindIDsColumn_IDMessageInitialQ(List<long> ColumnValues)
        {
            return LoadFindIDsColumn_IDMessageInitialQ(ColumnValues.ToArray<long>()); 
        }
        public void LoadFindIDsColumn_IDMessageInitial(List<long> ColumnValues)
        {
            this.LoadFindIDsColumn_IDMessageInitial(ColumnValues.ToArray<long>()); 
        }
                
        public IQueryable<smsg_MessageThread> LoadFrom_IDMessageReplyQ(long Value)
                {
                    
                    return LoadFrom1PropertyQ(exp_IDMessageReply, Value);
    
                }
        public void LoadFrom_IDMessageReply(long Value)
                {
                    
                    this.LoadFromQueryable( LoadFrom_IDMessageReplyQ(Value));
    
                }
        public IQueryable<smsg_MessageThread> LoadFindIDsColumn_IDMessageReplyQ(long[] ColumnValues)
        {
            return LoadFindIDsColumnQ<long>(ColumnValues,"IDMessageReply"); 
        }
        public void LoadFindIDsColumn_IDMessageReply(long[] ColumnValues)
        {
            this.LoadFromQueryable(LoadFindIDsColumnQ<long>(ColumnValues,"IDMessageReply")); 
        }
    
    
    	public IQueryable<smsg_MessageThread> LoadFindIDsColumn_IDMessageReplyQ(List<long> ColumnValues)
        {
            return LoadFindIDsColumn_IDMessageReplyQ(ColumnValues.ToArray<long>()); 
        }
        public void LoadFindIDsColumn_IDMessageReply(List<long> ColumnValues)
        {
            this.LoadFindIDsColumn_IDMessageReply(ColumnValues.ToArray<long>()); 
        }
                
        public IQueryable<smsg_MessageThread> LoadFrom_DateInsertedQ(System.DateTime Value)
                {
                    
                    return LoadFrom1PropertyQ(exp_DateInserted, Value);
    
                }
        public void LoadFrom_DateInserted(System.DateTime Value)
                {
                    
                    this.LoadFromQueryable( LoadFrom_DateInsertedQ(Value));
    
                }
        public IQueryable<smsg_MessageThread> LoadFindIDsColumn_DateInsertedQ(System.DateTime[] ColumnValues)
        {
            return LoadFindIDsColumnQ<System.DateTime>(ColumnValues,"DateInserted"); 
        }
        public void LoadFindIDsColumn_DateInserted(System.DateTime[] ColumnValues)
        {
            this.LoadFromQueryable(LoadFindIDsColumnQ<System.DateTime>(ColumnValues,"DateInserted")); 
        }
    
    
    	public IQueryable<smsg_MessageThread> LoadFindIDsColumn_DateInsertedQ(List<System.DateTime> ColumnValues)
        {
            return LoadFindIDsColumn_DateInsertedQ(ColumnValues.ToArray<System.DateTime>()); 
        }
        public void LoadFindIDsColumn_DateInserted(List<System.DateTime> ColumnValues)
        {
            this.LoadFindIDsColumn_DateInserted(ColumnValues.ToArray<System.DateTime>()); 
        }
                
        private IQueryable<smsg_MessageThread> LoadFrom1PropertyQ<T>(Expression<Func<smsg_MessageThread, T>> property, T Value)
                {
                    var iq = HelperExpressions.PredicateBinary<T, smsg_MessageThread >(property, Value, "equal");
                    return ObjectSetWithInclude().Where(iq);
    
                }
        
        public void LoadFrom1Property<T>(Expression<Func<smsg_MessageThread, T>> property, T Value)
                {
                    
                    this.LoadFromQueryable(LoadFrom1PropertyQ(property,Value));
    
                }
                public void LoadFrom2Property<T,U>(Expression<Func<smsg_MessageThread, T>> property1, T Value1, Expression<Func<smsg_MessageThread, U>> property2, U Value2,bool And)
                {
                    var iq = HelperExpressions.PredicateBinary<T, smsg_MessageThread >(property1, Value1, "equal");
                    if(And)
                    {
                        iq =EFRebinder.Utility.AndRebind(iq, HelperExpressions.PredicateBinary<U, smsg_MessageThread >(property2, Value2, "equal"));
                    }
                    else
                    {
                        iq =EFRebinder.Utility.OrRebind(iq, HelperExpressions.PredicateBinary<U, smsg_MessageThread >(property2, Value2, "equal"));
                    }
                    this.LoadFromQueryable(ObjectSetWithInclude().Where(iq));
    
                }
        public void LoadFindIDsColumn<T>(T[] ColumnValues,string ColumnName)
        {
            this.LoadFromQueryable(LoadFindIDsColumnQ(ColumnValues,ColumnName));
        }
        public IQueryable<smsg_MessageThread> LoadFindIDsColumnQ<T>(T[] ColumnValues,string ColumnName)
        {
    	//TODO: do this with buildcontains
            bool IsString = (typeof(T).FullName == typeof(string).FullName);
    
            string where="";
            string whereTemplate="it.{0} in ({1})";            
            if (ColumnValues != null && ColumnValues.Length > 0)
                {
                        
                    string inID = "{" + string.Join(", ", ColumnValues) + "}";
                    if (IsString)
                    {
                        inID ="";
                        foreach (var item in ColumnValues)
                        {
                            inID += string.Format("'{0}',", item.ToString().Replace("'","''"));
                        }
                        inID = inID.Substring(0, inID.Length - 1);
    					inID = "{" + inID + "}";
                    }
                    where += string.Format(whereTemplate, ColumnName, inID);
                }
                if (where.Length == 0)
                    return null;
                //return ObjectSetWithInclude().Where(where);
    			return null;
        }
        public IQueryable<smsg_MessageThread> LoadFindIDsQ(long[] IDMessageThread)
      {
        
            var find = BuildContainsExpression(exp_IDMessageThread,IDMessageThread);			
            return ObjectSetWithInclude().Where(find);
      }
        public IQueryable<smsg_MessageThread> LoadFromPKQ(long IDMessageThread)
        {
            //FindPartial.IDMessageThread = IDMessageThread;
    
            //return ObjectSetWithInclude().Where(PredicateID());
    		return null;		
        }
        public smsg_MessageThread LoadFromPK(long IDMessageThread)
        {
    
            this.LoadFromQueryable(LoadFromPKQ( IDMessageThread));
                
            if(this.ColToLoad.Count == 1)
            {
                return this.ColToLoad[0];
            }
            throw new ExceptionUtils.NoElementFoundException( IDMessageThread);
            //return null;
        }
        
        #region include 
            
         public enum Include : ulong { None = 0/*1*/,Include_smsg_Message=1/*1*/,Include_smsg_Message_Archive=2,All = 3}
         public Include flaginclude =Include.None;

        #endregion
    
    private IQueryable<smsg_MessageThread> ObjectSetWithInclude()
        {
            IQueryable<smsg_MessageThread> ret=this.ColToLoad.SelfObjectSet;
            if ((flaginclude & Include.Include_smsg_Message) == Include.Include_smsg_Message) 
     ret = ret.Include("smsg_Message");
    if ((flaginclude & Include.Include_smsg_Message_Archive) == Include.Include_smsg_Message_Archive) 
     ret = ret.Include("smsg_Message_Archive");
    
            return ret;
        }
        public  void LoadFindCustomPredicate()
        {
                this.LoadFromQueryable(LoadFindCustomPredicateQ());		  
        }
    	public IOrderedQueryable<smsg_MessageThread> LoadFindCustomPredicateOrderedQ(string FieldName){
    		return OrderByField(LoadFindCustomPredicateQ(),FieldName);
    	}
        public  IQueryable<smsg_MessageThread> LoadFindCustomPredicateQ()
      {
    	var ret=ObjectSetWithInclude();
    	if( custompredicate != null)
    	{
    		ret=ret.Where (custompredicate);;
    	}
    	return ret;
        //      return ObjectSetWithInclude().Where (custompredicate);
    
       }
    	public static IOrderedQueryable<smsg_MessageThread> OrderByField(IQueryable<smsg_MessageThread> var, string Field1) { 
    	if(string.IsNullOrEmpty(Field1))
    		return null;//TODO : return by PK
    
    	IOrderedQueryable<smsg_MessageThread> ret=null;
    
    	switch(Field1)
    	{
    			
    	case "IDMessageThread": ret=var.OrderBy(exp_IDMessageThread);break;
    case "IDMessageInitial": ret=var.OrderBy(exp_IDMessageInitial);break;
    case "IDMessageReply": ret=var.OrderBy(exp_IDMessageReply);break;
    case "DateInserted": ret=var.OrderBy(exp_DateInserted);break;
    
    	}
    	return ret;
    	}
    }
    
    
    
}

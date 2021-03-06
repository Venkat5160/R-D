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
    
    public partial class smsg_User_FindDB : FindInDatabase<smsg_User>
    {
        
        public static Expression<Func<smsg_User, string>> exp_IDUser = (item => item.IDUser );
        public static Func<string, Expression<Func<smsg_User, bool>>> fexp_IDUser = value => (item => 
                // item.IDUser != null  &&  
                item.IDUser == value);
        //TODO: find who supports this!   
    	////    a// a
        //public static Func<string,string, Expression<Func<smsg_User, bool>>> fexp_IDUserBetween = (value1,value2) => (item => item.IDUser> value1 && item.IDUser<value2);
    	//public static Func<string,string, Expression<Func<smsg_User, bool>>> fexp_IDUserBetweenEq = (value1,value2) => (item => item.IDUser >= value1 && item.IDUser <= value2);
    	//public static Func<string,string, Expression<Func<smsg_User, bool>>> fexp_IDUserBetweenEqDate = (value1,value2) =>{
    	//		value1=
    	//			//value1.Value.Date ;
    	//			value1.Date ;
    	//		value2=
    	//			//value2.Value.Date.AddDays(1) ;
    	//			value2.Date.AddDays(1) ;	
    	//		return (item => item.IDUser >= value1 && item.IDUser < value2);
    	// };
    	//public static Func<string, Expression<Func<smsg_User, bool>>> fexp_IDUserGreater = (value =>(item => item.IDUser > value));
    	//public static Func<string, Expression<Func<smsg_User, bool>>> fexp_IDUserGreaterEq = (value => (item =>item.IDUser >= value));
    	//public static Func<string, Expression<Func<smsg_User, bool>>> fexp_IDUserLess = (value => (item =>item.IDUser < value));
    	//public static Func<string, Expression<Func<smsg_User, bool>>> fexp_IDUserLessEq = (value => (item =>item.IDUser <= value));
        //public static Func<string, Expression<Func<smsg_User, bool>>> fexp_IDUserGreater = value => (item => HelperExpressions.GreaterThan<string>()(item.IDUser ,value));
        //public static Func<string, Expression<Func<smsg_User, bool>>> fexp_IDUserLess = value => (item => HelperExpressions.GreaterThan<string>()(value, item.IDUser ));
         public static Func<string, Expression<Func<smsg_User, bool>>> fexp_IDUserContains = value => (item =>  item.IDUser != null  &&  item.IDUser.Contains(value));
         public static Func<string, Expression<Func<smsg_User, bool>>> fexp_IDUserStartsWith = value => (item =>  item.IDUser != null  &&  item.IDUser.StartsWith(value));
    	 public IQueryable<smsg_User> LoadFrom_IDUserContainsQ(string value)
    	 {
    	  return this.ObjectSetWithInclude().Where(fexp_IDUserContains(value));
    	  }
    	 public static Func<string,string, Expression<Func<smsg_User, bool>>> fexp_IDUserContainsMultiple = (value,separator) => 
    		{
    			value=value.ToLower();
    			var arr=value.Split(new string[1]{separator}, StringSplitOptions.RemoveEmptyEntries);
    			switch(arr.Length)//TODO: use a better expression here rahter than based on length 
    			{
    				case 1:
    					return (item =>  item.IDUser != null  &&  item.IDUser.ToLower().Contains(value));
    				case 2:
    					 {
    					  string v1=arr[0].Replace(separator,"");
    					  string v2=arr[1].Replace(separator,"");				
    					 return (item =>  item.IDUser != null  &&  item.IDUser.ToLower().Contains(v1)  &&  item.IDUser.ToLower().Contains(v2) );		
    					}
    				default:
    					 {
    					   string v1=arr[0].Replace(separator,"");
    					  string v2=arr[1].Replace(separator,"");
    					  string v3=arr[2].Replace(separator,"");
    					return (item =>  item.IDUser != null  &&  item.IDUser.ToLower().Contains(v1) &&  item.IDUser.ToLower().Contains(v2) &&  item.IDUser.ToLower().Contains(v3) );
    					}
    	
    			}
    				
    	
    		};	 
    	 public static Func<string, Expression<Func<smsg_User, bool>>> fexp_IDUserContainsMultipleDef = value => fexp_IDUserContainsMultiple(value, "%");
        
        public static Expression<Func<smsg_User, string>> exp_UserName = (item => item.UserName );
        public static Func<string, Expression<Func<smsg_User, bool>>> fexp_UserName = value => (item => 
                // item.UserName != null  &&  
                item.UserName == value);
        //TODO: find who supports this!   
    	////    a// a
        //public static Func<string,string, Expression<Func<smsg_User, bool>>> fexp_UserNameBetween = (value1,value2) => (item => item.UserName> value1 && item.UserName<value2);
    	//public static Func<string,string, Expression<Func<smsg_User, bool>>> fexp_UserNameBetweenEq = (value1,value2) => (item => item.UserName >= value1 && item.UserName <= value2);
    	//public static Func<string,string, Expression<Func<smsg_User, bool>>> fexp_UserNameBetweenEqDate = (value1,value2) =>{
    	//		value1=
    	//			//value1.Value.Date ;
    	//			value1.Date ;
    	//		value2=
    	//			//value2.Value.Date.AddDays(1) ;
    	//			value2.Date.AddDays(1) ;	
    	//		return (item => item.UserName >= value1 && item.UserName < value2);
    	// };
    	//public static Func<string, Expression<Func<smsg_User, bool>>> fexp_UserNameGreater = (value =>(item => item.UserName > value));
    	//public static Func<string, Expression<Func<smsg_User, bool>>> fexp_UserNameGreaterEq = (value => (item =>item.UserName >= value));
    	//public static Func<string, Expression<Func<smsg_User, bool>>> fexp_UserNameLess = (value => (item =>item.UserName < value));
    	//public static Func<string, Expression<Func<smsg_User, bool>>> fexp_UserNameLessEq = (value => (item =>item.UserName <= value));
        //public static Func<string, Expression<Func<smsg_User, bool>>> fexp_UserNameGreater = value => (item => HelperExpressions.GreaterThan<string>()(item.UserName ,value));
        //public static Func<string, Expression<Func<smsg_User, bool>>> fexp_UserNameLess = value => (item => HelperExpressions.GreaterThan<string>()(value, item.UserName ));
         public static Func<string, Expression<Func<smsg_User, bool>>> fexp_UserNameContains = value => (item =>  item.UserName != null  &&  item.UserName.Contains(value));
         public static Func<string, Expression<Func<smsg_User, bool>>> fexp_UserNameStartsWith = value => (item =>  item.UserName != null  &&  item.UserName.StartsWith(value));
    	 public IQueryable<smsg_User> LoadFrom_UserNameContainsQ(string value)
    	 {
    	  return this.ObjectSetWithInclude().Where(fexp_UserNameContains(value));
    	  }
    	 public static Func<string,string, Expression<Func<smsg_User, bool>>> fexp_UserNameContainsMultiple = (value,separator) => 
    		{
    			value=value.ToLower();
    			var arr=value.Split(new string[1]{separator}, StringSplitOptions.RemoveEmptyEntries);
    			switch(arr.Length)//TODO: use a better expression here rahter than based on length 
    			{
    				case 1:
    					return (item =>  item.UserName != null  &&  item.UserName.ToLower().Contains(value));
    				case 2:
    					 {
    					  string v1=arr[0].Replace(separator,"");
    					  string v2=arr[1].Replace(separator,"");				
    					 return (item =>  item.UserName != null  &&  item.UserName.ToLower().Contains(v1)  &&  item.UserName.ToLower().Contains(v2) );		
    					}
    				default:
    					 {
    					   string v1=arr[0].Replace(separator,"");
    					  string v2=arr[1].Replace(separator,"");
    					  string v3=arr[2].Replace(separator,"");
    					return (item =>  item.UserName != null  &&  item.UserName.ToLower().Contains(v1) &&  item.UserName.ToLower().Contains(v2) &&  item.UserName.ToLower().Contains(v3) );
    					}
    	
    			}
    				
    	
    		};	 
    	 public static Func<string, Expression<Func<smsg_User, bool>>> fexp_UserNameContainsMultipleDef = value => fexp_UserNameContainsMultiple(value, "%");
        
        public static Expression<Func<smsg_User, string>> exp_UserEmail = (item => item.UserEmail );
        public static Func<string, Expression<Func<smsg_User, bool>>> fexp_UserEmail = value => (item => 
                // item.UserEmail != null  &&  
                item.UserEmail == value);
        //TODO: find who supports this!   
    	////    a// a
        //public static Func<string,string, Expression<Func<smsg_User, bool>>> fexp_UserEmailBetween = (value1,value2) => (item => item.UserEmail> value1 && item.UserEmail<value2);
    	//public static Func<string,string, Expression<Func<smsg_User, bool>>> fexp_UserEmailBetweenEq = (value1,value2) => (item => item.UserEmail >= value1 && item.UserEmail <= value2);
    	//public static Func<string,string, Expression<Func<smsg_User, bool>>> fexp_UserEmailBetweenEqDate = (value1,value2) =>{
    	//		value1=
    	//			//value1.Value.Date ;
    	//			value1.Date ;
    	//		value2=
    	//			//value2.Value.Date.AddDays(1) ;
    	//			value2.Date.AddDays(1) ;	
    	//		return (item => item.UserEmail >= value1 && item.UserEmail < value2);
    	// };
    	//public static Func<string, Expression<Func<smsg_User, bool>>> fexp_UserEmailGreater = (value =>(item => item.UserEmail > value));
    	//public static Func<string, Expression<Func<smsg_User, bool>>> fexp_UserEmailGreaterEq = (value => (item =>item.UserEmail >= value));
    	//public static Func<string, Expression<Func<smsg_User, bool>>> fexp_UserEmailLess = (value => (item =>item.UserEmail < value));
    	//public static Func<string, Expression<Func<smsg_User, bool>>> fexp_UserEmailLessEq = (value => (item =>item.UserEmail <= value));
        //public static Func<string, Expression<Func<smsg_User, bool>>> fexp_UserEmailGreater = value => (item => HelperExpressions.GreaterThan<string>()(item.UserEmail ,value));
        //public static Func<string, Expression<Func<smsg_User, bool>>> fexp_UserEmailLess = value => (item => HelperExpressions.GreaterThan<string>()(value, item.UserEmail ));
         public static Func<string, Expression<Func<smsg_User, bool>>> fexp_UserEmailContains = value => (item =>  item.UserEmail != null  &&  item.UserEmail.Contains(value));
         public static Func<string, Expression<Func<smsg_User, bool>>> fexp_UserEmailStartsWith = value => (item =>  item.UserEmail != null  &&  item.UserEmail.StartsWith(value));
    	 public IQueryable<smsg_User> LoadFrom_UserEmailContainsQ(string value)
    	 {
    	  return this.ObjectSetWithInclude().Where(fexp_UserEmailContains(value));
    	  }
    	 public static Func<string,string, Expression<Func<smsg_User, bool>>> fexp_UserEmailContainsMultiple = (value,separator) => 
    		{
    			value=value.ToLower();
    			var arr=value.Split(new string[1]{separator}, StringSplitOptions.RemoveEmptyEntries);
    			switch(arr.Length)//TODO: use a better expression here rahter than based on length 
    			{
    				case 1:
    					return (item =>  item.UserEmail != null  &&  item.UserEmail.ToLower().Contains(value));
    				case 2:
    					 {
    					  string v1=arr[0].Replace(separator,"");
    					  string v2=arr[1].Replace(separator,"");				
    					 return (item =>  item.UserEmail != null  &&  item.UserEmail.ToLower().Contains(v1)  &&  item.UserEmail.ToLower().Contains(v2) );		
    					}
    				default:
    					 {
    					   string v1=arr[0].Replace(separator,"");
    					  string v2=arr[1].Replace(separator,"");
    					  string v3=arr[2].Replace(separator,"");
    					return (item =>  item.UserEmail != null  &&  item.UserEmail.ToLower().Contains(v1) &&  item.UserEmail.ToLower().Contains(v2) &&  item.UserEmail.ToLower().Contains(v3) );
    					}
    	
    			}
    				
    	
    		};	 
    	 public static Func<string, Expression<Func<smsg_User, bool>>> fexp_UserEmailContainsMultipleDef = value => fexp_UserEmailContainsMultiple(value, "%");
        
       
        
        public smsg_User_FindDB(ColList<smsg_User> col):base(col)
        {
     
            
        
                    
        }
        
    
        
        
        public IQueryable<smsg_User> LoadFrom_IDUserQ(string Value)
                {
                    
                    return LoadFrom1PropertyQ(exp_IDUser, Value);
    
                }
        public void LoadFrom_IDUser(string Value)
                {
                    
                    this.LoadFromQueryable( LoadFrom_IDUserQ(Value));
    
                }
        public IQueryable<smsg_User> LoadFindIDsColumn_IDUserQ(string[] ColumnValues)
        {
            return LoadFindIDsColumnQ<string>(ColumnValues,"IDUser"); 
        }
        public void LoadFindIDsColumn_IDUser(string[] ColumnValues)
        {
            this.LoadFromQueryable(LoadFindIDsColumnQ<string>(ColumnValues,"IDUser")); 
        }
    
    
    	public IQueryable<smsg_User> LoadFindIDsColumn_IDUserQ(List<string> ColumnValues)
        {
            return LoadFindIDsColumn_IDUserQ(ColumnValues.ToArray<string>()); 
        }
        public void LoadFindIDsColumn_IDUser(List<string> ColumnValues)
        {
            this.LoadFindIDsColumn_IDUser(ColumnValues.ToArray<string>()); 
        }
                
        public IQueryable<smsg_User> LoadFrom_UserNameQ(string Value)
                {
                    
                    return LoadFrom1PropertyQ(exp_UserName, Value);
    
                }
        public void LoadFrom_UserName(string Value)
                {
                    
                    this.LoadFromQueryable( LoadFrom_UserNameQ(Value));
    
                }
        public IQueryable<smsg_User> LoadFindIDsColumn_UserNameQ(string[] ColumnValues)
        {
            return LoadFindIDsColumnQ<string>(ColumnValues,"UserName"); 
        }
        public void LoadFindIDsColumn_UserName(string[] ColumnValues)
        {
            this.LoadFromQueryable(LoadFindIDsColumnQ<string>(ColumnValues,"UserName")); 
        }
    
    
    	public IQueryable<smsg_User> LoadFindIDsColumn_UserNameQ(List<string> ColumnValues)
        {
            return LoadFindIDsColumn_UserNameQ(ColumnValues.ToArray<string>()); 
        }
        public void LoadFindIDsColumn_UserName(List<string> ColumnValues)
        {
            this.LoadFindIDsColumn_UserName(ColumnValues.ToArray<string>()); 
        }
                
        public IQueryable<smsg_User> LoadFrom_UserEmailQ(string Value)
                {
                    
                    return LoadFrom1PropertyQ(exp_UserEmail, Value);
    
                }
        public void LoadFrom_UserEmail(string Value)
                {
                    
                    this.LoadFromQueryable( LoadFrom_UserEmailQ(Value));
    
                }
        public IQueryable<smsg_User> LoadFindIDsColumn_UserEmailQ(string[] ColumnValues)
        {
            return LoadFindIDsColumnQ<string>(ColumnValues,"UserEmail"); 
        }
        public void LoadFindIDsColumn_UserEmail(string[] ColumnValues)
        {
            this.LoadFromQueryable(LoadFindIDsColumnQ<string>(ColumnValues,"UserEmail")); 
        }
    
    
    	public IQueryable<smsg_User> LoadFindIDsColumn_UserEmailQ(List<string> ColumnValues)
        {
            return LoadFindIDsColumn_UserEmailQ(ColumnValues.ToArray<string>()); 
        }
        public void LoadFindIDsColumn_UserEmail(List<string> ColumnValues)
        {
            this.LoadFindIDsColumn_UserEmail(ColumnValues.ToArray<string>()); 
        }
                
        private IQueryable<smsg_User> LoadFrom1PropertyQ<T>(Expression<Func<smsg_User, T>> property, T Value)
                {
                    var iq = HelperExpressions.PredicateBinary<T, smsg_User >(property, Value, "equal");
                    return ObjectSetWithInclude().Where(iq);
    
                }
        
        public void LoadFrom1Property<T>(Expression<Func<smsg_User, T>> property, T Value)
                {
                    
                    this.LoadFromQueryable(LoadFrom1PropertyQ(property,Value));
    
                }
                public void LoadFrom2Property<T,U>(Expression<Func<smsg_User, T>> property1, T Value1, Expression<Func<smsg_User, U>> property2, U Value2,bool And)
                {
                    var iq = HelperExpressions.PredicateBinary<T, smsg_User >(property1, Value1, "equal");
                    if(And)
                    {
                        iq =EFRebinder.Utility.AndRebind(iq, HelperExpressions.PredicateBinary<U, smsg_User >(property2, Value2, "equal"));
                    }
                    else
                    {
                        iq =EFRebinder.Utility.OrRebind(iq, HelperExpressions.PredicateBinary<U, smsg_User >(property2, Value2, "equal"));
                    }
                    this.LoadFromQueryable(ObjectSetWithInclude().Where(iq));
    
                }
        public void LoadFindIDsColumn<T>(T[] ColumnValues,string ColumnName)
        {
            this.LoadFromQueryable(LoadFindIDsColumnQ(ColumnValues,ColumnName));
        }
        public IQueryable<smsg_User> LoadFindIDsColumnQ<T>(T[] ColumnValues,string ColumnName)
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
        public IQueryable<smsg_User> LoadFindIDsQ(string[] IDUser)
      {
        
            var find = BuildContainsExpression(exp_IDUser,IDUser);			
            return ObjectSetWithInclude().Where(find);
      }
        public IQueryable<smsg_User> LoadFromPKQ(string IDUser)
        {
            //FindPartial.IDUser = IDUser;
    
            //return ObjectSetWithInclude().Where(PredicateID());
    		return null;		
        }
        public smsg_User LoadFromPK(string IDUser)
        {
    
            this.LoadFromQueryable(LoadFromPKQ( IDUser));
                
            if(this.ColToLoad.Count == 1)
            {
                return this.ColToLoad[0];
            }
            throw new ExceptionUtils.NoElementFoundException( IDUser);
            //return null;
        }
        
        #region include 
            
         public enum Include : ulong { None = 0}
         public Include flaginclude =Include.None;

        #endregion
    
    private IQueryable<smsg_User> ObjectSetWithInclude()
        {
            IQueryable<smsg_User> ret=this.ColToLoad.SelfObjectSet;
            
            return ret;
        }
        public  void LoadFindCustomPredicate()
        {
                this.LoadFromQueryable(LoadFindCustomPredicateQ());		  
        }
    	public IOrderedQueryable<smsg_User> LoadFindCustomPredicateOrderedQ(string FieldName){
    		return OrderByField(LoadFindCustomPredicateQ(),FieldName);
    	}
        public  IQueryable<smsg_User> LoadFindCustomPredicateQ()
      {
    	var ret=ObjectSetWithInclude();
    	if( custompredicate != null)
    	{
    		ret=ret.Where (custompredicate);;
    	}
    	return ret;
        //      return ObjectSetWithInclude().Where (custompredicate);
    
       }
    	public static IOrderedQueryable<smsg_User> OrderByField(IQueryable<smsg_User> var, string Field1) { 
    	if(string.IsNullOrEmpty(Field1))
    		return null;//TODO : return by PK
    
    	IOrderedQueryable<smsg_User> ret=null;
    
    	switch(Field1)
    	{
    			
    	case "IDUser": ret=var.OrderBy(exp_IDUser);break;
    case "UserName": ret=var.OrderBy(exp_UserName);break;
    case "UserEmail": ret=var.OrderBy(exp_UserEmail);break;
    
    	}
    	return ret;
    	}
    }
    
    
    
}

//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace smsg_DAL
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public partial class smsg_Message_Archive_Visitor: FastDatabaseQuery.IPropertiesVisitor
    {
    
        
         public string Visited(FastDatabaseQuery.IReceiveVisitor i)
         {
            StringBuilder sb=new StringBuilder();     
            var item=i as smsg_Message_Archive;
            if(item == null)
                 throw new ArgumentException("visiting can not convert to  smsg_Message_Archive");
    
                string Format="{0}={1};";
                    sb.Append(string.Format(Format,"IDMessageArchive",item.IDMessageArchive) );
                    sb.Append(string.Format(Format,"Subject",item.Subject) );
                    sb.Append(string.Format(Format,"Body",item.Body) );
                    sb.Append(string.Format(Format,"FromUser",item.FromUser) );
                    sb.Append(string.Format(Format,"ToUser",item.ToUser) );
                    sb.Append(string.Format(Format,"DateInserted",item.DateInserted) );
                    sb.Append(string.Format(Format,"MessageRead",item.MessageRead) );
                    return sb.ToString();
         }
    
    }
}
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
    
    public partial class smsg_Message: FastDatabaseQuery.IReceiveVisitor
    {
        public string Accept(FastDatabaseQuery.IPropertiesVisitor visit)
            {
                return visit.Visited(this);
            }
        partial void OnBeginConstructor();
        public smsg_Message()
        {
            OnBeginConstructor();
            this.IDMessage_IDMessageInitial = new HashSet<smsg_MessageThread>();
            this.IDMessage_IDMessageReply = new HashSet<smsg_MessageThread>();
        }
    
        public long IDMessage { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string FromUser { get; set; }
        public string ToUser { get; set; }
        public System.DateTime DateInserted { get; set; }
        public bool MessageRead { get; set; }
    
        public virtual ICollection<smsg_MessageThread> IDMessage_IDMessageInitial { get; set; }
        public virtual ICollection<smsg_MessageThread> IDMessage_IDMessageReply { get; set; }
    }
}

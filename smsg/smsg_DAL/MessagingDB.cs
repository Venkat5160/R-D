using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smsg_DAL
{
   public partial class MessagingDB 
    {
       partial void OnFinishModelCreating(System.Data.Entity.DbModelBuilder modelBuilder, string prefix)
       {
           modelBuilder.Entity<smsg_Message>().Ignore(item => item.Key);
       }
    }
}

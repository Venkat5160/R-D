using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smsg_DAL
{
    partial class smsg_Message_List
    {
        public void AddConditionRead(string Key , bool Read){
            this.LoadFromDB.AddToCustomPredicate(smsg_Message_FindDB.fexp_ToUser(Key));
            this.LoadFromDB.AddToCustomPredicate(smsg_Message_FindDB.fexp_MessageRead(Read));
        }
        
                
    }
}

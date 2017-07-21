using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smsg_DAL;
using smsg_MVC4.Utils;

namespace smsg_MVC4.Areas.Messaging.Models
{
    public class MVCUserModel
    {
        public MVCUserModel()
        {
            MessageReceived_PageNumber = 1;
        }
        public int MessageReceived_PageNumber{get;set;}
        public IUserString User;
        public int UnreadMessages()
        {
            return User.RetrieveMessagesUnreadCount();
        }
        
    }
}
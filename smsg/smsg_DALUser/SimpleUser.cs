using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KVP;
using MvcContrib.Pagination;
using smsg_DAL;
using EFRebinder;
namespace smsg_DAL
{
    public class SimpleUser : IUserString
    {
        public string ConnectionUser;
        public string ConnectionMessaging;
        protected internal smsg_User User;

        public SimpleUser()
        {
            this.User = new smsg_User();
        }
        public string Key
        {
            get
            {
                return User.IDUser;
            }
            set
            {
                User.IDUser = value;
            }
        }

        public string UserNameToDisplay
        {
            get
            {
                return User.UserName;
            }
            set
            {
                User.UserName = value;
            }
        }

        public string OtherInfo
        {
            get
            {
                return User.UserEmail;
            }
            set
            {
                User.UserEmail = value;
            }
        }

        public IEnumerable<KVP.KVPNew<string, string>> FindFriends(string search)
        {
            using (smsg_User_List ul = new smsg_User_List(ConnectionUser))
            {
                return ul.LoadFromDB.LoadFrom_UserNameContainsQ(search).Project().ToKVPStringString(smsg_User_List.FieldNames.IDUser, smsg_User_List.FieldNames.UserName, smsg_User_List.FieldNames.UserEmail).ToList();
                
            }
        }
        /// <summary>
        /// naive implementation  - all users are online...
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public IEnumerable<KVP.KVPNew<string, string>> FindFriendsOnline(string search)
        {
            return FindFriends(search);
        }




        public void SendMessage(IUserMessage<IUser<string>, string> message)
        {
            //TODO: use AutoMapper
            var msg = new smsg_Message();
            msg.Body = message.Body;
            
            if (msg.FromUser == null)
                msg.FromUser = this.Key;
            
            msg.DateInserted = message.DateInserted;
            msg.Subject = message.Subject;

            msg.ToUser = message.To.Key??this.Key;

            using (smsg_Message_List ml = new smsg_Message_List(ConnectionMessaging))
            {
                ml.Add(msg);
                ml.SaveNew();
            }
        }

       

        public int RetrieveMessagesUnreadCount()
        {
            using (smsg_Message_List ml = new smsg_Message_List(ConnectionMessaging))
            {
                ml.AddConditionRead(this.Key,false);
                return ml.LoadFromDB.LoadFindCustomPredicateQ().Count();
            }
        }

        public IEnumerable<KVP.KVPNew<long, string>>  RetrieveMessagesUnreadSummary()
        {
            
            using (smsg_Message_List ml = new smsg_Message_List(ConnectionMessaging))
            {
                ml.AddConditionRead(this.Key, false);
                return ml.LoadFromDB.LoadFindCustomPredicateQ().Project()
                    .ToKVPLongString(smsg_Message_List.FieldNames.IDMessage,smsg_Message_List.FieldNames.Subject,smsg_Message_List.FieldNames.FromUser)
                    .ToList();
            }
        }

        public IEnumerable<IUserMessage<IUser<String>, string>> RetrieveMessagesUnread()
        {
            using (smsg_Message_List ml = new smsg_Message_List(ConnectionMessaging))
            {
                ml.AddConditionRead(this.Key, false);
                ml.LoadFromDB.LoadFindCustomPredicate();
                ml.Update_MessageRead(true);
                return ml;
            }
        }
        public  IEnumerable<IUserMessage<IUser<String>,string>> RetrieveMessageSent(DateTime dt)
        {
            using (smsg_Message_List ml = new smsg_Message_List(ConnectionMessaging))
            {
                ml.LoadFromDB.AddToCustomPredicate(smsg_Message_FindDB.fexp_FromUser(this.Key));
                ml.LoadFromDB.AddToCustomPredicate(smsg_Message_FindDB.fexp_DateInsertedBetweenEqDate(dt, dt));
                ml.LoadFromDB.LoadFindCustomPredicate();
                
                return ml;
            }
        }


        public IEnumerable<IUserMessage<IUser<string>, string>> RetrieveMessageReceived(DateTime dt)
        {
            using (smsg_Message_List ml = new smsg_Message_List(ConnectionMessaging))
            {
                ml.LoadFromDB.AddToCustomPredicate(smsg_Message_FindDB.fexp_ToUser(this.Key));
                ml.LoadFromDB.AddToCustomPredicate(smsg_Message_FindDB.fexp_DateInsertedBetweenEqDate(dt, dt));
                ml.LoadFromDB.LoadFindCustomPredicate();
                ml.Update_MessageRead(true);
                return ml;
            }
        }

        public IPagination<KVPNew<long, string>> RetrieveMessageReceived_Paginatings(string OrderBy, int PageNumber, int RecordsPerPage, IMessagesFind find)
        {
            if (find == null)
                find = new SimpleFind();

            if (string.IsNullOrEmpty(OrderBy))
                OrderBy = smsg_DAL.smsg_Message_List.FieldNames.DateInserted;

            List<AccessViolationException> a;
            using (smsg_Message_List ml = new smsg_Message_List(ConnectionMessaging))
            {
                
                if (find.FromDate != null)
                    ml.LoadFromDB.AddToCustomPredicate(smsg_Message_FindDB.fexp_DateInsertedGreater(find.FromDate.Value.Date.AddMilliseconds(-1)));

                if (find.FromDate != null)
                    ml.LoadFromDB.AddToCustomPredicate(smsg_Message_FindDB.fexp_DateInsertedLess(find.ToDate.Value.Date.AddDays(1)));

                if (!string.IsNullOrEmpty(find.Subject))
                    ml.LoadFromDB.AddToCustomPredicate(smsg_Message_FindDB.fexp_SubjectContainsMultipleDef(find.Subject));

                if (!string.IsNullOrEmpty(find.SearchBody))
                    ml.LoadFromDB.AddToCustomPredicate(smsg_Message_FindDB.fexp_BodyContainsMultipleDef(find.SearchBody));

                ml.AddConditionRead(this.Key, true);
                
                var query = ml.LoadFromDB.LoadFindCustomPredicateOrderedQ(OrderBy);

                var s = query.Project()
                    .ToKVPLongString(smsg_Message_List.FieldNames.IDMessage,smsg_Message_List.FieldNames.Subject,smsg_Message_List.FieldNames.FromUser)
                    .AsPaginationExecute(PageNumber, RecordsPerPage);
                //TODO : mark read.
                return s ;//as  IPagination<KVPNew<long, string>>

            }
        }

        /// <summary>
        /// retrieve message id
        /// </summary>
        /// <param name="ID">id of the message</param>
        /// <returns>the messages - and marks as read</returns>
        public IUserMessage<IUser<string>, string> FindMessage(long ID)
        {
            using (smsg_Message_List ml = new smsg_Message_List(ConnectionMessaging))
            {
                
                ml.LoadFromDB.LoadFrom_IDMessage(ID);
                ml.Update_MessageRead(true);
                return ml[0];
            }
        }
    }
}

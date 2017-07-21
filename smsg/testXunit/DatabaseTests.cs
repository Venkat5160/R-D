using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SubSpec;
using Xunit;
using Ploeh.AutoFixture;
using smsg_DAL;
using Xunit.Extensions.AssertExtensions;
using Xunit.Extensions;
namespace testXunit
{

    public class clsTestUserSendMessage:IDisposable
    {
        static string conUser = "name=SMsgSEntities";
        static string conMessaging = "name=MessagingDB";
        public clsTestUserSendMessage()
        {
            DeleteDataUsersSimple();
        }

        public void ReadMessagex()
        {

            List<SimpleUser> users = null;

            users = CreateUsersAndDeleteItFirst(); SendMessage(users);

            RetrieveMessageUnreadCount(users[1]).ShouldEqual(1);
            RetrieveMessageUnread(users[1]); 

            RetrieveMessageUnreadCount(users[1]).ShouldEqual(0);
        }
        [Specification]
        //[AutoRollback]
        [Trace]
        public void TestReadMessage()
        {

            List<SimpleUser> users = null;

            "When create two users and sent message ".Context(() =>
                                                                  {
                                                                      users = CreateUsersAndDeleteItFirst();
                                                                  });
            "and send messages".Do(() => { SendMessage(users); });

            "the unread messages are 1 when retrieving summary ".Assert(() =>
            {
                RetrieveMessagesUnreadSummary(users[1]);
                RetrieveMessageUnreadCount(users[1]).ShouldEqual(1);
            }

                );

            "the unread messages are 0".Assert(() =>
                                                   {
                                                       RetrieveMessageUnread(users[1]);
                                                       RetrieveMessageUnreadCount(users[1]).ShouldEqual(0);
                                                   }

                );


        }

        private void RetrieveMessagesUnreadSummary(SimpleUser su)
        {
            su.ConnectionUser = conUser;
            su.ConnectionMessaging = conMessaging;
            su.RetrieveMessagesUnreadSummary();
        }

        [Specification]
        [Trace]
        public void TestCreateUsersAndPaginationOfReadMessages()
        {
            List<SimpleUser> users = null;

            "When create two users and sent message ".Context(() => {  users = CreateUsersAndDeleteItFirst(); });
            "and reading unread messages".Do(() => { SendMessage(users, 91, 100); RetrieveMessageUnread(users[1]); });
            "the pagination should retrive number of pages ".Assert(() => { RetrievePagination(users[1], 20).ShouldEqual(5); });
        }

        private int RetrievePagination(SimpleUser su, int RecordsPerPage)
        {
            SimpleFind sf = new SimpleFind();

            su.ConnectionUser = conUser;
            su.ConnectionMessaging = conMessaging;
            var ret = su.RetrieveMessageReceived_Paginatings(null, 1, RecordsPerPage, sf);

            return ret.TotalPages;
        }

        [Specification]
        //[AutoRollback]
        [Trace]
        public void TestCreateUsersAndSendMessage()
        {
            
            List<SimpleUser> users = null;

            "When create two users".Context(() =>
                                                {
                                                    DeleteDataUsersSimple();
                                                    users = CreateUsersAndDeleteItFirst();
                                                });
            "it will be friends".Assert(() => FindFriend(users).ShouldNotBeNull());
            
            "and when send message from first user to second user".Do(() => SendMessage(users));

            
            "we will retrieve it searching message from first user ".Assert(() => RetrieveMessageSent( users[0]).ShouldEqual(1));

            "we will NOT retrieve it searching message from second user".Assert(() => RetrieveMessageSent(users[1]).ShouldEqual(0));

            "we will retrieve searching messages received by second user".Assert(() => RetrieveMessageReceived(users[1]).ShouldEqual(1));

            "we will retrieve count of unread messages :1 ".Assert(() => RetrieveMessageUnreadCount(users[1]).ShouldEqual(1));

            


        }
        private void RetrieveMessageUnread(SimpleUser su)
        {
            su.ConnectionUser = conUser;
            su.ConnectionMessaging = conMessaging;
            su.RetrieveMessagesUnread();
        }
        private List<SimpleUser> CreateUsersAndDeleteItFirst()
        {
            DeleteDataUsersSimple();
            return CreateUsers();
        }

        private int RetrieveMessageUnreadCount(SimpleUser su)
        {
            su.ConnectionUser = conUser;
            su.ConnectionMessaging = conMessaging;
            int i= su.RetrieveMessagesUnreadCount();
            return i;
        }

        private int RetrieveMessageReceived(SimpleUser su)
        {
            su.ConnectionUser = conUser;
            su.ConnectionMessaging = conMessaging;
            return su.RetrieveMessageReceived(DateTime.Now).Count();

        }
        private int RetrieveMessageSent(SimpleUser su)
        {
            su.ConnectionUser = conUser;
            su.ConnectionMessaging = conMessaging;
            return su.RetrieveMessageSent(DateTime.Now).Count();
        }
        private KVP.KVPNew<string,string> FindFriend(List<SimpleUser> users)
        {
            SimpleUser u = new SimpleUser();
            u.Key = users[0].Key;
            u.ConnectionUser = conUser;
            u.ConnectionMessaging = conMessaging;
            var colFriends = u.FindFriends(users[1].UserNameToDisplay);
            return colFriends.Where(item=>item.Key != u.Key).FirstOrDefault();
        }

        private void SendMessage(List<SimpleUser> users, int Number=1, int milliseconds=0)
        {
            SimpleUser u = new SimpleUser();
            u.Key = users[0].Key;
            u.ConnectionUser = conUser;
            u.ConnectionMessaging = conMessaging;
            bool sleep = (milliseconds > 0);
            var user = FindFriend(users);
            Fixture f=new Fixture();
            for (int i = 0; i < Number; i++)
            {
                if (sleep && i > 0)
                    Thread.Sleep(milliseconds);

                smsg_Message m = new smsg_Message();
                //smsg_Message m = f.CreateAnonymous<smsg_Message>();
                m.Subject = f.CreateAnonymous<string>().Substring(0, 10);
                m.Body = f.CreateAnonymous<string>();
                m.UsersFind = new smsg_User_List(conUser);
                m.FromUser = u.Key;
                m.ToUser = users[1].Key;
                u.SendMessage(m);
                
            }
        }

        private List<SimpleUser> CreateUsers()
        {
            
            List<SimpleUser> ret = new List<SimpleUser>();
            Fixture f = new Fixture();
            
            using (IUserList<SimpleUser, string> ul = new smsg_User_List(conUser))
            {
                ul.Add(f.CreateAnonymous<SimpleUser>());
                ul.Add(f.CreateAnonymous<SimpleUser>());
                ul.SaveNew();
                
                
                
                ret.Add(ul.Find(0));
                ret.Add(ul.Find(1));
                
            }
            return ret;
            
        }

        static void DeleteDataUsersSimple()
        {
            using (smsg_Message_List ml = new smsg_Message_List(conMessaging))
            {
                ml.FastDeleteAll();
            }
            //TODO: delete messages
            using (IUserList<SimpleUser, string> ul = new smsg_User_List(conUser))
            {
                ul.FastDeleteAll();
            }

        }

        public void Dispose()
        {
            DeleteDataUsersSimple();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using smsg_DAL;

namespace smsg_MVC4.Utils
{
    public static class SiteUtils
    {
        public static  string ConnectionStringUsers
        {
            get { return "name=DefaultConnection"; }

        }
        public static string ConnectionStringMSG
        {
            get { return "name=MessagingDB"; }

        }




        public static string UserAdministratorID
        {
           get
            {
                return "78AD44EB-1B95-4E39-A791-3282307277CA";
            }
        }

        
        public static string SiteName
        {
            get { return "Messaging System With MVC4 ( mobile also)"; }
        }

        private static string _welcomeMessage;
        public static string WelcomeMessage
        {
            get 
            {
                if(_welcomeMessage != null)
                    return _welcomeMessage;
                var http = System.Web.HttpContext.Current;
                try
                {
                    http.Application.Lock();
                    _welcomeMessage = System.IO.File.ReadAllText(http.Server.MapPath("~/Templates/Welcome.txt"));
                    return _welcomeMessage;
                }
                finally
                {
                    http.Application.UnLock();
                }
                
            }

        }

        public static IUserString CreateUserFromID(string UserID)
        {
           
                SimpleUser su=new SimpleUser();
                su.Key = UserID;
                su.ConnectionMessaging = ConnectionStringMSG;
                su.ConnectionUser = ConnectionStringUsers;
                return su;
        }

        public static IUserMessage<IUser<String>, string> CreateNewMessage()
        {
            smsg_Message m = new smsg_Message();
            m.UsersFind = new smsg_User_List(ConnectionStringUsers);            
            return m;
        }

        public static int RetrieveMessagesUnreadCount(String UserID)
        {
            using (smsg_Message_List ml = new smsg_Message_List(ConnectionStringMSG))
            {
                ml.AddConditionRead(UserID, false);
                return ml.LoadFromDB.LoadFindCustomPredicateQ().Count();
            }
        }

        public static IUserString UserLoggedOn
        {
            get { return System.Web.HttpContext.Current.Session["UserLoggedOn"] as IUserString; }
            set { System.Web.HttpContext.Current.Session["UserLoggedOn"] = value; }
        }
    }
}
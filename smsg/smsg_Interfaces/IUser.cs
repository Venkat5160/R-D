using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KVP;
using MvcContrib.Pagination;

namespace smsg_DAL
{
    /// <summary>
    /// the user that can send messages
    /// TODO version 2: make pagination
    /// </summary>
    /// <typeparam name="UserPrimaryKey">the type of primary key</typeparam>
    public interface IUser<UserPrimaryKey>
    {
        /// <summary>
        /// the user primary key
        /// </summary>
        UserPrimaryKey Key { get; set; }
        /// <summary>
        /// the user name to be displayed
        /// </summary>
        string UserNameToDisplay { get; set; }
        /// <summary>
        /// other info for the user
        /// </summary>
        string OtherInfo { get; set; }

        /// <summary>
        /// find friends
        /// </summary>
        /// <param name="search">find user by name</param>
        /// <returns></returns>
        IEnumerable<KVPNew<UserPrimaryKey, string>> FindFriends(string search);

        /// <summary>
        /// find friends online
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        IEnumerable<KVPNew<UserPrimaryKey, string>> FindFriendsOnline(string search);

        /// <summary>
        /// sends a message 
        /// </summary>
        /// <param name="message"></param>
        void SendMessage(IUserMessage<IUser<UserPrimaryKey>, UserPrimaryKey> message);


        /// <summary>
        /// retrieves messages sent on date
        /// </summary>
        /// <param name="dt">date</param>
        /// <returns>  a list of messages</returns>
        IEnumerable<IUserMessage<IUser<UserPrimaryKey>, UserPrimaryKey>> RetrieveMessageSent(DateTime dt);

        /// <summary>
        /// retrieves messages received on date
        /// </summary>
        /// <param name="dt">date</param>
        /// <returns>  a list of messages</returns>
        IEnumerable<IUserMessage<IUser<UserPrimaryKey>, UserPrimaryKey>> RetrieveMessageReceived(DateTime dt);

        /// <summary>
        /// retrieves messages unread
        /// </summary>
        /// <returns>  a list of messages</returns>        
        IEnumerable<IUserMessage<IUser<UserPrimaryKey>, UserPrimaryKey>> RetrieveMessagesUnread();

        /// <summary>
        /// retrieve messages unread  *  but it not reads them
        /// TODO: Create class for that
        /// </summary>
        /// <returns>a list of messages</returns>
        IEnumerable<KVPNew<long, string>>  RetrieveMessagesUnreadSummary();
        
        /// <summary>
        /// number of unread messages
        /// </summary>
        /// <returns>number of unread messages</returns>
        int RetrieveMessagesUnreadCount();

        /// <summary>
        /// pagination of all messages
        /// </summary>
        /// <param name="OrderBy">if you pass null, then date received</param>
        /// <returns>paginating list of messages</returns>
        IPagination<KVPNew<long, string>> RetrieveMessageReceived_Paginatings(string OrderBy, int Page, int RecordsPerPage, IMessagesFind find);

        /// <summary>
        /// retrieve message id
        /// </summary>
        /// <param name="ID">id of the message</param>
        /// <returns>the messages - and marks as read</returns>
        IUserMessage<IUser<UserPrimaryKey>, UserPrimaryKey> FindMessage(long ID);
    }


    //default implementations : string, long, guid

    /// <summary>
    /// default string implementation for  IUser
    /// </summary>
    public interface IUserString : IUser<string>
    {
    }

    /// <summary>
    /// default long implementation for IUser
    /// </summary>
    public interface IUserLong : IUser<long>
    {

    }

    /// <summary>
    /// default GUID implementation for  IUser
    /// </summary>
    public interface IUserGuid : IUser<Guid>
    {
    }
    
}

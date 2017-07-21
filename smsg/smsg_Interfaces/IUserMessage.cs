using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smsg_DAL
{
    /// <summary>
    /// message importance - as in outlook 
    /// </summary>
    public enum MessageImportance
    {
        /// <summary>
        /// normal
        /// </summary>
        Normal = 0,

        /// <summary>
        /// low
        /// </summary>
        Low =1,

        /// <summary>
        /// high
        /// </summary>
        High=2
    }
    /// <summary>
    /// the message to be sent to the user
    /// TODO version 2: allow messaging for more than 1 user
    /// TODO version 2: message importance
    /// </summary>
    /// <typeparam name="TheUser">user interface</typeparam>
    ///  /// <typeparam name="UserPrimaryKey">user primary key</typeparam>
    public interface IUserMessage<TheUser, UserPrimaryKey>
        where TheUser : IUser<UserPrimaryKey>
    {
        /// <summary>
        /// id of the message
        /// </summary>
        long Key { get; set; }

        /// <summary>
        /// subject of the message
        /// </summary>
        string Subject { get; set; }
        /// <summary>
        /// body of the message
        /// </summary>
        string Body { get; set; }
        /// <summary>
        /// to the user
        /// </summary>
        TheUser To { get; set; }
        /// <summary>
        /// from the user
        /// </summary>
        TheUser From { get; set; }
        /// <summary>
        /// cc - as in email
        /// </summary>
        TheUser CC { get; set; }

        /// <summary>
        /// date of message
        /// </summary>
        DateTime DateInserted { get; set; }

        /// <summary>
        /// if recipient have read
        /// </summary>
        bool MessageRead { get; set; }
        // <summary>
        // bcc - as in email
        // </summary>
        //TheUser BCC { get; set; }



    }
}

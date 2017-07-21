using System;

namespace smsg_DAL
{
    ///<summary>
    /// finding messages 
    ///</summary>
    public interface IMessagesFind
    {
        /// <summary>
        /// search date >= from date
        /// </summary>
        DateTime? FromDate { get; set; }
        /// <summary>
        /// search date <= from date
        /// </summary>
        DateTime? ToDate { get; set; }
        /// <summary>
        /// search on user -could be null or empty
        /// </summary>
        string FromUser { get; set; }
        /// <summary>
        /// search for containing  on subject
        /// </summary>
        string Subject { get; set; }
        /// <summary>
        /// search for body
        /// </summary>
        string SearchBody { get; set; }
    }
}
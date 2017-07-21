using System;
using smsg_DAL;

namespace smsg_DAL
{
    public class SimpleFind: IMessagesFind
    {
        #region Implementation of IMessagesFind

        /// <summary>
        /// search date >= from date
        /// </summary>
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// search date <= from date
        /// </summary>
        public DateTime? ToDate { get; set; }

        /// <summary>
        /// search on user -could be null or empty
        /// </summary>
        public string FromUser { get; set; }

        /// <summary>
        /// search for containing  on subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// search for body
        /// </summary>
        public string SearchBody { get; set; }

        #endregion
    }
}
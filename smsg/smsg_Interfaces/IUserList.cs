using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smsg_DAL
{
    /// <summary>
    /// operations with the database
    /// </summary>
    /// <typeparam name="User"></typeparam>
    /// <typeparam name="UserPrimaryKey"></typeparam>
    public interface IUserList<User, UserPrimaryKey>: IDisposable
        where User : IUser<UserPrimaryKey>
    {
        /// <summary>
        /// fast delete all from database - good for testing
        /// </summary>
        void FastDeleteAll();
        
        /// <summary>
        /// add to internal list
        /// </summary>
        /// <param name="u">the user to be added </param>
        void Add(User u);
         
        /// <summary>
        /// save changes for new and old members
        /// </summary>
        void SaveNew();
        /// <summary>
        /// save changes for old members
        /// </summary>
        void SaveExisting();

        /// <summary>
        /// for retrieving 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        User Find(int i);
        
    }
}

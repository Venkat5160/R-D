using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KVP;

namespace smsg_DAL
{
    /// <summary>
    /// used by application to load plugins to find users
    /// because each application can have it's own way to find users
    /// used by admins to find users
    /// Improvement version 2 : pagination 
    /// </summary>
    /// <typeparam name="T">user </typeparam>
    /// <typeparam name="UserKey">user key </typeparam>
    public interface IUsersFind<T,UserKey>
        where T:IUser<UserKey>
    {
        /// <summary>
        /// used to find users online to send message
        /// </summary>
        /// <param name="UserThatMakesTheSearch"> the user that makes the search </param>
        /// <param name="Search">search string - could be null</param>
        /// <returns> a list of users</returns>
        IEnumerable<KVPNew<T, string>> FindUsersOnline(T UserThatMakesTheSearch, string Search);
        /// <summary>
        /// used to find users (online or not )to send message
        /// </summary>
        /// <param name="UserThatMakesTheSearch"> the user that makes the search </param>
        /// <param name="Search">search string - could be null</param>
        /// <returns> a list of users</returns>
        IEnumerable<KVPNew<T, string>> FindUsers(T UserThatMakesTheSearch, string Search);
        /// <summary>
        /// find a user by his key
        /// </summary>
        /// <param name="key">the user key</param>
        /// <returns></returns>
        IUser<UserKey> FindUser(UserKey key);
            
    }
    /// <summary>
    /// default implementation for find string
    /// </summary>
    public interface IUsersFindString : IUsersFind<IUserString, string>
    {

    }
}

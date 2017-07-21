using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using smsg_DAL;


namespace smsg_DAL
{
    public partial class smsg_User_List : IUserList<SimpleUser, string>, IUsersFindString
    {

        public SimpleUser Find(int i)
        {
            
            return new SimpleUser() { User = this[i] };
        }
        public void Add(SimpleUser u)
        {
            this.Add(u.User);
        }

        public IEnumerable<KVP.KVPNew<IUserString, string>> FindUsersOnline(IUserString UserThatMakesTheSearch, string Search)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KVP.KVPNew<IUserString, string>> FindUsers(IUserString UserThatMakesTheSearch, string Search)
        {
            throw new NotImplementedException();
        }

        public IUser<string> FindUser(string key)
        {
            var ret = this.FirstOrDefault(item=>item.IDUser==key);

            if (ret == null)
            {
                this.LoadFromDB.LoadFrom_IDUser(key);
                ret = this.FirstOrDefault(item => item.IDUser == key);
            }

            SimpleUser su = new SimpleUser();
            su.User = ret;
            return su;

        }
    }
}

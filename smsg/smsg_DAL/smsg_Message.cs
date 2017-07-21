using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace smsg_DAL
{
    partial class smsg_Message : IUserMessage<IUser<String>, string>
    {
        partial void OnBeginConstructor()
        {
            this.DateInserted = DateTime.Now;
        }
        private IUsersFindString _usersFind;

        public IUsersFindString UsersFind
        {
            get {
                if (_usersFind == null)
                {
                    //TODO : find default implementation
                }
                return  _usersFind; }
            set {  _usersFind = value; }
        }

        /// <summary>
        /// id of the message
        /// </summary>        
        public long Key
        {
            get { return this.IDMessage; }
            set { this.IDMessage = value;  }
        }

        public  IUser<String> To
        {
            get
            {
                return _usersFind.FindUser(this.ToUser);
            }
            set
            {
                this.ToUser = value.Key;
            }
        }

        public  IUser<String> From
        {
            get
            {
                return _usersFind.FindUser(this.FromUser);
            }
            set
            {
                this.FromUser = value.Key;
            }
        }




        public  IUser<String> CC
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}

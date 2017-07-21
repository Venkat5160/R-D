using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExceptionUtils
{
    public class NoPermission: ExceptionBase
    {

        public object id1;
        public string user;
        public string nume;
        public NoPermission(string user,string nume, object ID)            
            :base(" user " + user + " nu ar acces la " + nume + " cu id " +ID)
        {
            this.id1 = ID;
            this.user = user;
            this.nume = nume;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastDatabaseQuery
{
    public interface IObjectConnection
    {
        string ConnectionName { get; set; }
        object ConnectionObject { get; set; }
    }
}

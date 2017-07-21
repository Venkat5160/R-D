using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExceptionUtils
{
    public class ExceptionBase : Exception
    {
        public ExceptionBase() : base() { }
        public ExceptionBase(string Message) : base(Message) { }
    }
}

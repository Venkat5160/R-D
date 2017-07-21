using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExceptionUtils
{
    public class NoElementFoundException: ExceptionBase
    {
        public object id1;
        public object id2;
        public object id3;
        public object id4;
        private long IDLinie;
        private long IDComanda;
        private int NrLinie;
        private string CodProdus;
        private string Articol;
        private decimal Comandat;
        private decimal Livrat;
        public NoElementFoundException(object ID):this(ID, "","")
        {
            
        }
        public NoElementFoundException(object ID1,object ID2)
            : this(ID1,ID2,"")
        {
            
        }
        public NoElementFoundException(object ID1, object ID2, object ID3)
            : this( ID1, ID2, ID3,"")
        {
            
        }
        public NoElementFoundException(object ID1,object ID2, object ID3, object ID4)
            : base(string.Format(" no element with {0} {1} {2} found", ID1,ID2,ID3,ID4))
        {
            this.id1 = ID1;
            this.id2 = ID2;
            this.id3 = ID3;
            this.id4 = ID4;
        }

        
        
    }
    public class NoElementFoundExceptionFor<T> : NoElementFoundException
    {
         public NoElementFoundExceptionFor(object ID):this(ID, "","")
        {
            
        }
        public NoElementFoundExceptionFor(object ID1,object ID2)
            : this(ID1,ID2,"")
        {
            
        }
        public NoElementFoundExceptionFor(object ID1, object ID2, object ID3)
            : this( ID1, ID2, ID3,"")
        {
            
        }
        public NoElementFoundExceptionFor(object ID1, object ID2, object ID3, object ID4)
            : base( ID1,ID2,ID3,ID4)
        {
            
        }
    }
}

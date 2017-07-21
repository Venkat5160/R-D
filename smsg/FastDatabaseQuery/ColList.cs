using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
namespace FastDatabaseQuery
{
    public class ColList<T> : List<T>, IDisposable, IObjectConnection, IReceiveVisitor
    where T : class
    {
        
        private FindInDatabase<T> _FindDB;
        public FindInDatabase<T> LoadFromDB
        {
            get
            {
                if (_FindDB == null)
                {
                    _FindDB = new FindInDatabase<T>(this);
                }
                return _FindDB;
            }
            set
            {
                _FindDB = value;
            }
        }
        public List<TElement> ExecuteStoreQuery<TElement>(string commandText, params object[] parameters)
        {
            List<TElement> list = new List<TElement>();
           
            var res = Conection.Database.SqlQuery<TElement>(commandText, parameters);
            foreach (var item in res)
            {
                list.Add(item);
            }
            return list;
        }
        public DbSet<T> SelfObjectSet
        {
            get { return _SelfObjectSet ?? (_SelfObjectSet = Conection.Set<T>()); }
        }
        private DbSet<T> _SelfObjectSet;
        private DbContext _Conection;
        protected internal DbContext Conection
        {
            get
            {
                
                if (_Conection == null)
                {
                    //_Conection = new DezvoltariScalaEntities("");
                    throw new ArgumentException("Connection is null");
                }
                return _Conection;
                
            }
            set
            {
                _Conection = value;
            }
        }

        string Name = typeof(T).Name;
        #region conection transfer
        string IObjectConnection.ConnectionName { get; set; }

        object IObjectConnection.ConnectionObject
        {
            get
            {
                return Conection;
            }
            set
            {
                Conection = value as DbContext;
            }
        }
        #endregion
        #region constructors
        public ColList()
        {
            this.DisposeConnection = true;
        }
        public ColList(IObjectConnection con)
        {
            this.DisposeConnection = false;
            this._Conection = con.ConnectionObject as DbContext;
        }
        public ColList(object context)
            : base()
        {
            this.DisposeConnection = false;
            this.Conection = context as DbContext;
        }

        #endregion
        #region IDisposable
        protected bool DisposeConnection = true;
        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void DisposeConnectionNow()
        {
            if (_Conection != null && DisposeConnection)
            {
                _Conection.Dispose();
                _Conection = null;
            }
        }
        private void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed
                // and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.
                    //component.Dispose();
                }

                DisposeConnectionNow();
                // Note disposing has been done.
                disposed = true;

            }
        }

        #endregion

        public void MarkDelete(int id)
        {
            MarkDelete(this[id]);
        }
        public void MarkDelete(T item)
        {
            Conection.Set<T>().Remove(item);
        }
        public event EventHandler<EventArgs> BeforeSave;
        public event EventHandler<EventArgs> AfterSave;
        public void SaveExisting()
        {
            if (BeforeSave != null)
                BeforeSave(this, EventArgs.Empty);
            Conection.SaveChanges();
            if (AfterSave != null)
                AfterSave(this, EventArgs.Empty);
         
        }
        //public void SaveHistory(HistoryObjects.clsUser c, T item)
        //{
        //    var h = item as HistoryObjects.IHistory;
        //    if (h != null)
        //    {
        //        c.IdentifyWhoDidIt(h);
        //    }
        //}
        public void SaveNew()
        {

            //HistoryObjects.clsUser c = new HistoryObjects.clsUser();

            foreach (var item in this)
            {
                //SaveHistory(c, item);
                SelfObjectSet.Add(item);
            }
            SaveExisting();

        }
        public List<KeyValuePair<string, string>> ToKeyValueList(Func<T, string> Key, Func<T, string> Value, bool Sort = true)
        {
            List<KeyValuePair<string, string>> ret = new List<KeyValuePair<string, string>>();
            foreach (var item in this)
            {
                ret.Add(new KeyValuePair<string, string>(Key(item), Value(item)));
            }
            if (Sort)
            {
                ret.Sort(new Comparison<KeyValuePair<string, string>>((x, y) => x.Value.CompareTo(y.Value)));
            }
            return ret;
        }




        public string  Accept(IPropertiesVisitor visit)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(visit.Visited(this));
            foreach (var item in this)
            {
                IReceiveVisitor i = item as IReceiveVisitor;
                if (i != null )
                {
                    sb.Append(i.Accept(visit));
                }
            }
            return sb.ToString();
        }

        
    }
}

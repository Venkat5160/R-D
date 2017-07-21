using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KVP
{
    /// <summary>
    /// this is the correspondent class of KeyValuePair structure from .net
    /// The features:
    /// 1. it is a class-  can be compared fastly with null
    /// 2. can be used in a search and display <paramref name="AdditionalData">AdditionalData </paramref>
    /// </summary>
    /// <typeparam name="TKEY">Key - it is compared in equals and GetHashCode</typeparam>
    /// <typeparam name="TValue">Value to be displayed</typeparam>
    public class KVPNew<TKEY, TValue>
    {
        public KVPNew() { }
        public KVPNew(TKEY key, TValue value):this()
        {
            this.Key = key;
            this.Value = value;

        }
        public TKEY Key { get; set; }
        public TValue Value { get; set; }
        public string AdditionalData { get; set; }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var o = obj as KVPNew<TKEY, TValue>;
            if (o == null)
                return false;
            return this.Key.Equals(o.Key);

        }
        public override int GetHashCode()
        {
            return this.Key.GetHashCode();
        }
    }
}

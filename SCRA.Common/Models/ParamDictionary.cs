using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SCRA.Common.Utilities;

namespace SCRA.Common.Models
{
    public class ParamDictionary : IDictionary<string, ParamValue>
    {
        public ParamDictionary()
        {
            Dictionary = new Dictionary<string, ParamValue>();
        }

        public static ParamDictionary CopyFrom(IEnumerable<ParamValue> parameters)
        {
            ParamDictionary paramDictionary = new ParamDictionary();
            foreach (ParamValue paramValue in parameters)
            {
                paramDictionary.Add(paramValue);
            }

            return paramDictionary;
        }

        public string ToSignature() => Dictionary.Select(i => i.Value.ToSignature()).ToDelimitedSequence("&");

        public IEnumerator<ParamValue> GetEnumerator()
        {
            return Dictionary.Values.GetEnumerator();
        }

        public bool ContainsKey(string key)
        {
            return Dictionary.ContainsKey(key);
        }

        public void Add(ParamValue item)
        {
            if (!ContainsKey(item.Name))
            {
                Dictionary.Add(item.Name, item);
            }
        }

        public void Add(string name, ParamType paramType, object value)
        {
            Add(ParamValue.New(name, paramType, value));
        }

        public void Add(string name, string value)
        {
            Add(ParamValue.New(name, value));
        }

        public bool Remove(string key)
        {
            return Dictionary.Remove(key);
        }

        public bool Remove(ParamValue item)
        {
            return ContainsKey(item.Name) && Remove(item.Name);
        }

        public bool TryGetValue(string key, out ParamValue value)
        {
            return Dictionary.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<string, ParamValue>>)this).GetEnumerator();
        }

        IEnumerator<KeyValuePair<string, ParamValue>> IEnumerable<KeyValuePair<string, ParamValue>>.GetEnumerator()
        {
            return Dictionary.GetEnumerator();
        }

        void ICollection<KeyValuePair<string, ParamValue>>.Add(KeyValuePair<string, ParamValue> item)
        {
            Dictionary.Add(item);
        }

        void ICollection<KeyValuePair<string, ParamValue>>.Clear()
        {
            Dictionary.Clear();
        }

        bool ICollection<KeyValuePair<string, ParamValue>>.Contains(KeyValuePair<string, ParamValue> item)
        {
            return Dictionary.Contains(item);
        }

        void ICollection<KeyValuePair<string, ParamValue>>.CopyTo(KeyValuePair<string, ParamValue>[] array, int arrayIndex)
        {
            Dictionary.CopyTo(array, arrayIndex);
        }

        bool ICollection<KeyValuePair<string, ParamValue>>.Remove(KeyValuePair<string, ParamValue> item)
        {
            return Dictionary.Remove(item);
        }

        void IDictionary<string, ParamValue>.Add(string key, ParamValue value)
        {
            Dictionary.Add(key, value);
        }

        private IDictionary<string, ParamValue> Dictionary { get; set; }

        public ParamValue this[string key]
        {
            get { return Dictionary[key]; }
            set { Dictionary[key] = value; }
        }

        public ICollection<string> Keys
        {
            get { return Dictionary.Keys; }
        }

        public ICollection<ParamValue> Values
        {
            get { return Dictionary.Values; }
        }

        public int Count
        {
            get { return Dictionary.Count; }
        }

        public bool IsReadOnly
        {
            get { return Dictionary.IsReadOnly; }
        }
    }

    public static class ParamDictionaryExtensions
    {
        public static ParamDictionary ToParamDictionary(this IEnumerable<ParamValue> parameters)
        {
            return ParamDictionary.CopyFrom(parameters);
        }
    }
}

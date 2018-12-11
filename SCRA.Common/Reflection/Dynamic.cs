using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Reflection;
using SCRA.Common.Utilities;

namespace SCRA.Common.Reflection
{
    public class Dynamic : DynamicObject, IDictionary<string, object>, INotifyPropertyChanged
    {
        private Dynamic()
        {
            Properties = new Dictionary<string, object>();
        }

        public static Dynamic New(object instance)
        {
            return new Dynamic().Initialize(instance);
        }

        private Dynamic Initialize(object instance)
        {
            PropertyInfo[] properties = instance.GetType().GetProperties();

            if (properties.Length > 0)
            {
                foreach (PropertyInfo i in properties)
                {
                    Properties.Add(i.Name.ToLower(), instance.GetAt(i.Name));
                }
            }

            return this;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return Properties.TryGetValue(binder.Name.ToLower(), out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            Properties[binder.Name.ToLower()] = value;

            return true;
        }

        IEnumerator<KeyValuePair<string, object>> IEnumerable<KeyValuePair<string, object>>.GetEnumerator()
        {
            return Properties.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Properties).GetEnumerator();
        }

        void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> item)
        {
            Properties.Add(item);
        }

        void ICollection<KeyValuePair<string, object>>.Clear()
        {
            Properties.Clear();
        }

        bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> item)
        {
            return Properties.Contains(item);
        }

        void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            Properties.CopyTo(array, arrayIndex);
        }

        bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> item)
        {
            return Properties.Remove(item);
        }

        int ICollection<KeyValuePair<string, object>>.Count
        {
            get { return Properties.Count; }
        }

        bool ICollection<KeyValuePair<string, object>>.IsReadOnly
        {
            get { return Properties.IsReadOnly; }
        }

        bool IDictionary<string, object>.ContainsKey(string key)
        {
            return Properties.ContainsKey(key);
        }

        void IDictionary<string, object>.Add(string key, object value)
        {
            Properties.Add(key, value);
        }

        bool IDictionary<string, object>.Remove(string key)
        {
            return Properties.Remove(key);
        }

        bool IDictionary<string, object>.TryGetValue(string key, out object value)
        {
            return Properties.TryGetValue(key, out value);
        }

        object IDictionary<string, object>.this[string key]
        {
            get { return Properties[key]; }
            set { Properties[key] = value; }
        }

        ICollection<string> IDictionary<string, object>.Keys
        {
            get { return Properties.Keys; }
        }

        ICollection<object> IDictionary<string, object>.Values
        {
            get { return Properties.Values; }
        }

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add { ((INotifyPropertyChanged)Properties).PropertyChanged += value; }
            remove { ((INotifyPropertyChanged)Properties).PropertyChanged -= value; }
        }

        private IDictionary<string, object> Properties { get; set; }
    }
}

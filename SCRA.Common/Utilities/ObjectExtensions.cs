using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SCRA.Common.Reflection;

namespace SCRA.Common.Utilities
{
    public static class ObjectExtensions
    {
        public static object ConvertTo(this object instance, Type type)
        {
            if (type == typeof(Boolean)) { return Convert.ToBoolean(instance); }
            if (type == typeof(DateTime)) { return Convert.ToDateTime(instance); }
            if (type == typeof(DateTimeOffset)) { return DateTimeOffset.Parse(instance.ToString()); }

            if (type == typeof(Char)) { return Convert.ToChar(instance); }
            if (type == typeof(SByte)) { return Convert.ToSByte(instance); }
            if (type == typeof(Byte)) { return Convert.ToByte(instance); }
            if (type == typeof(Int16)) { return Convert.ToInt16(instance); }
            if (type == typeof(UInt16)) { return Convert.ToUInt16(instance); }
            if (type == typeof(Int32)) { return Convert.ToInt32(instance); }
            if (type == typeof(UInt32)) { return Convert.ToUInt32(instance); }
            if (type == typeof(Int64)) { return Convert.ToInt64(instance); }
            if (type == typeof(UInt64)) { return Convert.ToUInt64(instance); }

            if (type == typeof(Single)) { return Convert.ToSingle(instance); }
            if (type == typeof(Double)) { return Convert.ToDouble(instance); }
            if (type == typeof(Decimal)) { return Convert.ToDecimal(instance); }

            if (type == typeof(String)) { return Convert.ToString(instance); }

            return instance;
        }

        public static T ConvertTo<T>(this object instance)
        {
            return (T)instance.ConvertTo(typeof(T));
        }

        public static PropertyInfo GetProperty(this object instance, string propertyName, BindingFlags bindingFlags)
        {
            return instance.GetType().GetProperty(propertyName, bindingFlags);
        }

        public static PropertyInfo GetProperty(this object instance, string propertyName)
        {
            return instance.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);
        }

        public static PropertyInfo[] GetOrderedProperties(this Type type, BindingFlags bindingFlags)
        {
            return type.GetProperties(bindingFlags).OrderBy(i => i.MetadataToken).ToArray();
        }

        public static PropertyInfo[] GetOrderedProperties(this Type type)
        {
            return type.GetOrderedProperties(BindingFlags.Instance | BindingFlags.Public);
        }

        public static object GetAt(this object instance, PropertyInfo property)
        {
            return property.GetValue(instance, null);
        }

        public static object GetAt(this object instance, string propertyName, BindingFlags bindingFlags)
        {
            PropertyInfo property = instance.GetProperty(propertyName, bindingFlags);

            return instance.GetAt(property);
        }

        public static object GetAt(this object instance, string propertyName)
        {
            return instance.GetAt(propertyName, BindingFlags.Instance | BindingFlags.Public);
        }

        public static T GetAt<T>(this object instance, PropertyInfo property, T defaultValue)
        {
            object value = instance.GetAt(property);

            if (value == null) { return defaultValue; }

            Type type = typeof(T);
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                type = type.GetGenericArguments()[0];
            }

            return (T)value.ConvertTo(type);
        }

        public static T GetAt<T>(this object instance, PropertyInfo property)
        {
            return instance.GetAt(property, default(T));
        }

        public static T GetAt<T>(this object instance, string propertyName, BindingFlags bindingFlags, T defaultValue)
        {
            PropertyInfo property = instance.GetProperty(propertyName, bindingFlags);

            return instance.GetAt(property, defaultValue);
        }

        public static T GetAt<T>(this object instance, string propertyName, BindingFlags bindingFlags)
        {
            return instance.GetAt(propertyName, bindingFlags, default(T));
        }

        public static T GetAt<T>(this object instance, string propertyName, T defaultValue)
        {
            return instance.GetAt(propertyName, BindingFlags.Instance | BindingFlags.Public, default(T));
        }

        public static T GetAt<T>(this object instance, string propertyName)
        {
            return instance.GetAt(propertyName, default(T));
        }

        public static void SetAt(this object instance, PropertyInfo property, object value, BindingFlags bindingFlags)
        {
            property.SetValue(instance, value, bindingFlags, null, null, null);
        }

        public static void SetAt(this object instance, string propertyName, object value, BindingFlags bindingFlags)
        {
            PropertyInfo property = instance.GetProperty(propertyName, bindingFlags);

            instance.SetAt(property, value, bindingFlags);
        }

        public static void SetAt(this object instance, string propertyName, object value)
        {
            instance.SetAt(propertyName, value, BindingFlags.Instance | BindingFlags.Public);
        }

        public static T CopyTo<T>(this object instance) where T : new()
        {
            Type instanceType = instance.GetType();

            Type targetType = typeof(T);
            T target = new T();

            foreach (PropertyInfo prop in instanceType.GetProperties())
            {
                PropertyInfo targetProp = targetType.GetProperty(prop.Name);
                if (targetProp == null) { continue; }

                object value = instance.GetAt(prop.Name);
                if (value == null) { continue; }

                target.SetAt(prop.Name, value);
            }

            return target;
        }

        public static void CopyValues(this object instance, Type type, IList<object> values)
        {
            PropertyInfo[] properties = type.GetOrderedProperties();

            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo prop = properties[i];
                if (prop.GetSetMethod(true) != null)
                {
                    prop.SetValue(instance, values[i], null);
                }
            }
        }

        public static IDictionary<string, object> ToPropertyDictionary(this object instance)
        {
            return instance != null
                ? instance.GetType().GetProperties()
                    .Select(i => new KeyValuePair<string, object>(i.Name, instance.GetAt(i.Name)))
                    .ToDictionary(i => i.Key, i => i.Value)
                : new Dictionary<string, object>();
        }

        public static void ForEachPropertyNameAndValue(this object instance, Action<string, object> action)
        {
            foreach (KeyValuePair<string, object> i in instance.ToPropertyDictionary()) { action(i.Key, i.Value); }
        }

        public static void ForEachPropertyInfo(this IEnumerable<PropertyInfo> properties, Action<PropertyInfo> action)
        {
            foreach (PropertyInfo prop in properties) { action(prop); }
        }

        public static void ForEachPropertyInfo(this Type type, Action<PropertyInfo> action)
        {
            type.GetProperties().ForEachPropertyInfo(action);
        }

        public static object Merge(this object instance1, object instance2)
        {
            if (instance1 != null || instance2 != null)
            {
                if (instance1 == null) { return instance2; }
                if (instance2 == null) { return instance1; }

                IDictionary<string, object> instance1Dictionary = instance1.ToPropertyDictionary();
                IDictionary<string, object> instance2Dictionary = instance2.ToPropertyDictionary();

                foreach (KeyValuePair<string, object> i in instance2Dictionary.Where(i => !instance1Dictionary.Keys.Contains(i.Key)))
                {
                    instance1Dictionary.Add(i);
                }

                PropertyDef[] newInstanceInfo = instance1Dictionary.Select(i => PropertyDef.New(i.Key, i.Value)).ToArray();

                return AnonymousBuilder.CreateInstance(newInstanceInfo);
            }

            return null;
        }
    }
}

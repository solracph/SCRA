using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace SCRA.Common.Utilities
{
    public static class Extensions
    {

        public static object InvokeMethod(this IMethodInvokable instance, string method, params object[] parameters)
        {
            string[] methodParts = method.Split('.');
            string interfaceName = methodParts[0];
            string methodName = methodParts[1];

            Type interfaceType = Assembly
                .GetAssembly(instance.GetType())
                .GetTypes()
                .Single(i => i.IsInterface && i.Name == interfaceName);

            object serviceInstance = instance.GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                .Single(i => i.IsGenericMethod && i.Name == "At" && !i.GetParameters().Any())
                .MakeGenericMethod(new[] { interfaceType })
                .Invoke(instance, null);

            MethodInfo methodInfo = serviceInstance
                .GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
                .Single(i => i.Name == interfaceType.FullName + "." + methodName);

            object data;
            try { data = methodInfo.Invoke(serviceInstance, parameters); }
            catch { data = null; }

            return data;
        }

        public static IEnumerable<TAttribute> GetAttributes<TAttribute>(this MemberInfo type, bool inherit) where TAttribute : Attribute
        {
            return type.GetCustomAttributes(typeof(TAttribute), inherit).OfType<TAttribute>();
        }

        public static IEnumerable<TAttribute> GetAttributes<TAttribute>(this MemberInfo type) where TAttribute : Attribute
        {
            return type.GetAttributes<TAttribute>(false);
        }

        public static TAttribute GetFirstAttribute<TAttribute>(this MemberInfo type, bool inherit) where TAttribute : Attribute
        {
            return type.GetAttributes<TAttribute>(inherit).FirstOrDefault();
        }

        public static TAttribute GetFirstAttribute<TAttribute>(this MemberInfo type) where TAttribute : Attribute
        {
            return type.GetFirstAttribute<TAttribute>(false);
        }

        public static TAttribute GetSingleAttribute<TAttribute>(this MemberInfo type, bool inherit) where TAttribute : Attribute
        {
            return type.GetAttributes<TAttribute>(inherit).SingleOrDefault();
        }

        public static TAttribute GetSingleAttribute<TAttribute>(this MemberInfo type) where TAttribute : Attribute
        {
            return type.GetSingleAttribute<TAttribute>(false);
        }

        public static bool HasAttribute<TAttribute>(this MemberInfo type, bool inherit) where TAttribute : Attribute
        {
            return type.GetAttributes<TAttribute>(inherit).Count() == 1;
        }

        public static bool HasAttribute<TAttribute>(this MemberInfo type) where TAttribute : Attribute
        {
            return type.HasAttribute<TAttribute>(false);
        }

        public static bool Contains(this ICollection collection, string identifier)
        {
            string[] elements = new string[collection.Count];
            collection.CopyTo(elements, 0);

            return elements.Any(e => e.Equals(identifier));
        }

        public static void FullTrace(this Exception exception)
        {
            Trace.WriteLine(exception.Message);
            Trace.WriteLine(exception.StackTrace);

            if (exception.InnerException != null)
            {
                exception.InnerException.FullTrace();
            }
        }

        public static int[] ToIntArray(this string text, char delimiter)
        {
            return text.Split(delimiter).Select(int.Parse).ToArray();
        }

        public static byte[] ToByteArray(this string text)
        {
            return text.ToCharArray().Select(c => (byte)c).ToArray();
        }

        public static decimal ToCurrency(this string text)
        {
            return !string.IsNullOrEmpty(text)
                ? decimal.Parse(text.Replace("$", string.Empty).Replace(",", string.Empty))
                : 0;
        }

        public static string ToPhoneNumber(this string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                string flatText = Regex.Replace(text.InnerTrim(), @"\W", string.Empty);

                return !string.IsNullOrEmpty(flatText) && flatText.Length == 10
                    ? Regex.Replace(flatText, @"(\d{3})(\d{3})(\d{4})", "($1) $2-$3")
                    : text;
            }

            return string.Empty;
        }

        public static int ToAge(this DateTime birthday, DateTime referenceDate)
        {
            referenceDate = referenceDate.Date;
            int age = referenceDate.Year - birthday.Year;

            return birthday > referenceDate.AddYears(-age) ? --age : age;
        }

        public static int ToAge(this DateTime birthday)
        {
            return birthday.ToAge(DateTime.Now);
        }

        public static string ToDescription(this Enum value)
        {
            DescriptionAttribute attribute = value.GetType().GetField(value.ToString()).GetSingleAttribute<DescriptionAttribute>();

            return attribute != null ? attribute.Description : value.ToString().ToSentence();
        }

        public static TV GetValue<TK, TV>(this IDictionary<TK, TV> dictionary, TK key, TV defaultValue)
        {
            return dictionary.ContainsKey(key) ? dictionary[key] : defaultValue;
        }

        public static TV GetValue<TK, TV>(this IDictionary<TK, TV> dictionary, TK key)
        {
            return dictionary.GetValue(key, default(TV));
        }
    }
}

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using SCRA.Common.Utilities;

namespace SCRA.Common.Reflection
{
    public sealed class AnonymousBuilder : DynamicTypeBuilder
    {
        public AnonymousBuilder(params string[] propertyNames)
             : base(null, propertyNames)
        {
        }

        public static object CreateInstance(PropertyDef[] propertyDefs)
        {
            string[] propertyNames = propertyDefs.Select(p => p.Name).ToArray();
            object[] values = propertyDefs.Select(p => p.Value).ToArray();

            return new AnonymousBuilder(propertyNames).CreateInstance(values);
        }

        protected override void DefineCustomAttributes()
        {
            DefineDebuggerDisplayAttribute();
        }

        private void DefineDebuggerDisplayAttribute()
        {
            string pattern = string.Empty;
            IList<string> propertyNames = TypeBuilder.GetGenericArguments().Select(g => GetPropertyName(g.Name)).ToList();

            bool limited = propertyNames.Count > 3;
            if (limited)
            {
                propertyNames = propertyNames.Take(3).ToList();
            }

            pattern = propertyNames.Aggregate(pattern, (current, n) => current + (n + " = {" + n + "}, "));

            TypeBuilder.SetCustomAttribute(new CustomAttributeBuilder(
                typeof(DebuggerDisplayAttribute).GetConstructor(new[] { typeof(string) }),
                new[] { pattern.CutLast(", ") + (limited ? "..." : string.Empty) }));
        }

        protected override string BuilderSignature
        {
            get { return "Anonymous"; }
        }
    }
}

using System.Linq;
using SCRA.Common.Models;
using SCRA.Common.Reflection;

namespace SCRA.Data.Common.Utilities
{
    public static class Extensions
    {
        public static object ToParamObject(this ParamDictionary parameters)
        {
            return parameters.Any()
                ? AnonymousBuilder.CreateInstance(parameters.Values.Select(i => PropertyDef.New(i.Name, i.Value)).ToArray())
                : null;
        }
    }
}

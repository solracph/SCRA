using System.Collections.Generic;

namespace SCRA.Common.Models
{
    public struct ParamValue
    {
        public static ParamValue New(string name, ParamType paramType, object value)
        {
            return new ParamValue { Name = name, ParamType = paramType, Value = value };
        }

        public static ParamValue New(string name, string value)
        {
            return New(name, ParamType.Single, value);
        }

        public static ParamValue Adapt(ParamValue parameter, object value)
        {
            return new ParamValue { Name = parameter.Name, ParamType = parameter.ParamType, Value = value };
        }

        public KeyValuePair<string, object> ToPair()
        {
            return new KeyValuePair<string, object>(Name, Value);
        }

        public string ToSignature()
        {
            return string.Format("{0}={1}", Name, Value);
        }

        public string Name { get; set; }
        public ParamType ParamType { get; set; }

        public object Value { get; set; }
    }
}

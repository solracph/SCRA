
namespace SCRA.Common.Reflection
{
    public struct PropertyDef
    {
        public static PropertyDef New(string name, object value)
        {
            return new PropertyDef { Name = name, Value = value };
        }

        public string Name { get; private set; }

        public object Value { get; private set; }
    }
}

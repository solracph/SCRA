using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using SCRA.Common.Utilities;

namespace SCRA.Common.Reflection
{
    public abstract class DynamicTypeBuilder
    {
        private static readonly object _lock = new object();

        static DynamicTypeBuilder()
        {
            BuiltTypes = new Dictionary<string, Type>();
        }

        protected DynamicTypeBuilder(Type baseType, string[] propertyNames)
        {
            BaseType = baseType;
            PropertyNames = propertyNames;
            Fields = new Dictionary<string, FieldInfo>();
        }

        public Type GetBuiltType()
        {
            string signature = GetTypeSignature();

            lock (_lock)
            {
                if (!BuiltTypes.ContainsKey(signature))
                {
                    BuiltTypes.Add(signature, BuildType(signature));
                }
            }

            return BuiltTypes[signature];
        }

        public object CreateInstance(object[] values)
        {
            Type type = GetBuiltType();

            Type[] parameterTypes = values.Take(type.GetGenericArguments().Count()).Select(i => i != null ? i.GetType() : typeof(Nullable)).ToArray();
            Type actualType = type.MakeGenericType(parameterTypes);
            object instance = Activator.CreateInstance(actualType);

            instance.CopyValues(actualType, values);

            return instance;
        }

        private Type BuildType(string signature)
        {
            string signatureHash = CryptographyHelper.ComputeHash(signature, HashType.MD5);
            AssemblyName assemblyName = new AssemblyName("__DynamicType_" + signatureHash);
            string typeName = "__DynamicType_" + signature;

            AssemblyBuilder assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule(assemblyName.Name);

            CreateTypeBuilder(moduleBuilder, typeName);
            DefineTypeComponents();

            return TypeBuilder.CreateType();
        }

        protected virtual void CreateTypeBuilder(ModuleBuilder moduleBuilder, string typeName)
        {
            TypeBuilder = moduleBuilder.DefineType(typeName,
                TypeAttributes.NotPublic | TypeAttributes.AutoLayout | TypeAttributes.AnsiClass
                | TypeAttributes.Sealed | TypeAttributes.BeforeFieldInit,
                BaseType);
        }

        protected virtual void DefineTypeComponents()
        {
            DefineGenericParameters();
            DefineFields();
            DefineCustomAttributes();
            DefineConstructor();
            DefineProperties();
        }

        protected virtual void DefineGenericParameters()
        {
            if (PropertyNames != null)
            {
                TypeBuilder.DefineGenericParameters(PropertyNames.Select(n => string.Format("<{0}>j__TPar", n)).ToArray());
            }
        }

        protected virtual void DefineFields()
        {
            if (PropertyNames != null)
            {
                foreach (Type g in TypeBuilder.GetGenericArguments())
                {
                    string name = GetPropertyName(g.Name);

                    FieldBuilder field = TypeBuilder.DefineField(string.Format("<{0}>i__Field", name),
                        g.UnderlyingSystemType, FieldAttributes.Private | FieldAttributes.InitOnly);

                    field.SetCustomAttribute(new CustomAttributeBuilder(
                        typeof(DebuggerBrowsableAttribute).GetConstructor(new[] { typeof(DebuggerBrowsableState) }),
                        new[] { (object)DebuggerBrowsableState.Never }));

                    Fields.Add(name, field);
                }
            }
        }

        protected virtual void DefineCustomAttributes()
        {
        }

        protected virtual void DefineConstructor()
        {
            ConstructorBuilder constructorBuilder = TypeBuilder.DefineConstructor(
                MethodAttributes.Public | MethodAttributes.HideBySig, CallingConventions.Standard, Type.EmptyTypes);

            constructorBuilder.SetCustomAttribute(new CustomAttributeBuilder(
                typeof(DebuggerHiddenAttribute).GetConstructor(Type.EmptyTypes), new object[0]));

            ILGenerator il = constructorBuilder.GetILGenerator();

            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Call, typeof(object).GetConstructor(Type.EmptyTypes));
            il.Emit(OpCodes.Ret);
        }

        protected virtual void DefineProperties()
        {
            if (PropertyNames != null)
            {
                foreach (Type g in TypeBuilder.GetGenericArguments())
                {
                    string propertyName = GetPropertyName(g.Name);
                    Type propertyType = g.UnderlyingSystemType;
                    FieldInfo field = Fields[propertyName];

                    DefineProperty(field, propertyName, propertyType);
                }
            }
        }

        protected void DefineProperty(FieldInfo field, string propertyName, Type propertyType)
        {
            PropertyBuilder propertyBuilder = TypeBuilder.DefineProperty(propertyName, PropertyAttributes.HasDefault, propertyType, null);

            DefinePropertyGetter(propertyBuilder, field, propertyName, propertyType);
            DefinePropertySetter(propertyBuilder, field, propertyName, propertyType);
        }

        protected void DefinePropertyGetter(PropertyBuilder propertyBuilder, FieldInfo field, string propertyName, Type propertyType)
        {
            MethodBuilder methodBuilder = TypeBuilder.DefineMethod("get_" + propertyName,
                MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig,
                propertyType, Type.EmptyTypes);

            ILGenerator il = methodBuilder.GetILGenerator();

            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldfld, field);
            il.Emit(OpCodes.Ret);

            propertyBuilder.SetGetMethod(methodBuilder);
        }

        protected void DefinePropertySetter(PropertyBuilder propertyBuilder, FieldInfo field, string propertyName, Type propertyType)
        {
            MethodBuilder methodBuilder = TypeBuilder.DefineMethod("set_" + propertyName,
                MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig,
                null, new[] { propertyType });

            ILGenerator il = methodBuilder.GetILGenerator();

            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Stfld, field);
            il.Emit(OpCodes.Ret);

            propertyBuilder.SetSetMethod(methodBuilder);
        }

        protected virtual string GetTypeSignature()
        {
            string properties = PropertyNames != null
                ? PropertyNames.Aggregate(string.Empty, (current, n) => current + string.Format("'<{0}>j__TPar',", n))
                : string.Empty;

            string signature = string.Format("{0}<{1}>", BuilderSignature,
                ((BaseType != null ? BaseType.Name : string.Empty) + properties).CutLast(","));

            return GetNormalizedTypeSignature(signature);
        }

        private static string GetNormalizedTypeSignature(string signature)
        {
            if (signature.Length <= 512) { return signature; }

            string signatureHash = CryptographyHelper.ComputeHash(signature, HashType.MD5);

            return string.Format("{0}_{1}", signature.Substring(0, 478), signatureHash);
        }

        protected string GetPropertyName(string genericName)
        {
            return genericName.Substring(1).Replace(">j__TPar", string.Empty);
        }

        protected abstract string BuilderSignature { get; }

        protected Type BaseType { get; set; }
        protected string[] PropertyNames { get; set; }

        protected TypeBuilder TypeBuilder { get; set; }
        protected IDictionary<string, FieldInfo> Fields { get; set; }

        private static IDictionary<string, Type> BuiltTypes { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL.Extension
{
    static class InternalExtensions
    {
        public static bool IsConstantable(this Type type)
        {
            if (type.IsEnumEx())
                return true;

            switch (type.GetTypeCodeEx())
            {
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.SByte:
                case TypeCode.Byte:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                case TypeCode.Boolean:
                case TypeCode.String:
                case TypeCode.Char: return true;
            }

            if (type.IsNullable())
                return type.GetGenericArgumentsEx()[0].IsConstantable();

            return false;
        }

        public static bool IsEnumEx(this Type type)
        {
#if NETFX_CORE || NETSTANDARD
			return type.GetTypeInfo().IsEnum;
#else
            return type.IsEnum;
#endif
        }


        public static TypeCode GetTypeCodeEx(this Type type)
        {


            return Type.GetTypeCode(type);

        }


        public static bool IsNullable(this Type type)
        {
            return type.IsGenericTypeEx() && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        public static Type[] GetGenericArgumentsEx(this Type type)
        {

            return type.GetGenericArguments();

        }

        public static bool IsGenericTypeEx(this Type type)
        {

            return type.IsGenericType;

        }
    }
}

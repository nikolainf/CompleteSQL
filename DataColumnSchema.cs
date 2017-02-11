using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompleteSQL
{
    public class DataColumnSchema
    {
        public readonly string Name;

        public readonly Type Type;

        public readonly bool AllowDbNull;
        public DataColumnSchema(string columnName, Type type)
        {
            Name = columnName;

            bool allowDbNull;
            Type = ConvertType(type, out allowDbNull);
            AllowDbNull = allowDbNull;
        }

        private Type ConvertType(Type type, out bool allowDbNull)
        {
            if (type != typeof(string))
            {
                allowDbNull = type.IsGenericType;
                if (allowDbNull)
                    return type.GetGenericArguments()[0];

                return type;

            }
            else
            {
                allowDbNull = true;
                return type;
            }
        }
    }
}

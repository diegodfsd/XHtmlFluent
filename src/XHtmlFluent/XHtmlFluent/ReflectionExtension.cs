using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace XHTML.Lib
{
    public static class ExtensionReflection
    {
        public static PropertyInfo[] Properties(this object instance)
        {
            if (instance != null)
            {
                return instance
                    .GetType()
                    .GetProperties();
            }
            return new PropertyInfo[]{};
        }

        public static object Value(this PropertyInfo property, object instance)
        {
            if (property != null)
            {
                return property
                    .GetValue(instance, null);
            }
            return null;
        }
    }
}

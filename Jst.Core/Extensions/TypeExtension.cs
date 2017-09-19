using Jst.Core.Attributes;
using Jst.UtilStandard;
using System;
using System.Reflection;

namespace Jst.Core.Extensions
{
    public static class TypeExtension
    {
        public static string GetAliasName(this Type type)
        {
            var attributes = type.GetTypeInfo().GetCustomAttribute<RegisterAliasNameAttribute>(false);
            if (attributes.IsNotNull())
            {
                return attributes.AliasName;
            }
            return string.Empty;
        }
    }
}

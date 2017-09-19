using System;

namespace Jst.Core.Attributes
{
    public class RegisterAliasNameAttribute : Attribute
    {

        public string AliasName { get; set; }

        public RegisterAliasNameAttribute(string name)
        {
            AliasName = name;
        }

    }
}

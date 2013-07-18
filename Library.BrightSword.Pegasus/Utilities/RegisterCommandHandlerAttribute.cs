using System;

namespace BrightSword.Pegasus.Utilities
{
    public class RegisterCommandHandlerAttribute : Attribute
    {
        public RegisterCommandHandlerAttribute(Type type)
        {
            Type = type;
        }

        public Type Type { get; set; }
    }
}
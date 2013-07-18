using System;

namespace BrightSword.Pegasus.API
{
    public class FailedToCreateCommandHandlerException : Exception
    {
        public FailedToCreateCommandHandlerException(string handlerTypeAssemblyQualifiedName,
                                                     Exception exception)
            : base("Failed To Create Command Handler",
                   exception)
        {
            HandlerTypeAssemblyQualifiedName = handlerTypeAssemblyQualifiedName;
        }

        public string HandlerTypeAssemblyQualifiedName { get; private set; }
    }
}
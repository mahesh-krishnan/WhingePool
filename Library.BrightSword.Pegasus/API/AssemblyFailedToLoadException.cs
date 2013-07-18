using System;

namespace BrightSword.Pegasus.API
{
    public class AssemblyFailedToLoadException : Exception
    {
        public AssemblyFailedToLoadException(string handlerAssembly)
        {
            HandlerAssembly = handlerAssembly;
        }

        public string HandlerAssembly { get; private set; }
    }
}
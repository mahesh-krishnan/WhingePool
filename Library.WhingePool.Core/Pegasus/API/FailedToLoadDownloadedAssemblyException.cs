using System;

namespace WhingePool.Core.Pegasus.API
{
    public class FailedToLoadDownloadedAssemblyException : Exception
    {
        public FailedToLoadDownloadedAssemblyException(string handlerAssembly,
                                                       Exception exception)
            : base("Failed To Load Downloaded Assembly",
                   exception)
        {
            HandlerAssembly = handlerAssembly;
        }

        public string HandlerAssembly { get; private set; }
    }
}
using System;

namespace WhingePool.Core.Pegasus.API
{
    public class FailedToDownloadAssemblyException : Exception
    {
        public FailedToDownloadAssemblyException(string handlerAssembly,
                                                 Exception exception)
            : base("Failed To Download Assembly",
                   exception)
        {
            HandlerAssembly = handlerAssembly;
        }

        public string HandlerAssembly { get; set; }
    }
}
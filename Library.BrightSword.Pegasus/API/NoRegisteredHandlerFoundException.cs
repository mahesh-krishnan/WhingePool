using System;

namespace BrightSword.Pegasus.API
{
    public class NoRegisteredHandlerFoundException : Exception
    {
        public NoRegisteredHandlerFoundException(string taskHandlerName)
        {
            TaskHandlerName = taskHandlerName;
        }

        public string TaskHandlerName { get; set; }
    }
}
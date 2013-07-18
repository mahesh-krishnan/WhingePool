namespace WhingePool.Core.Configuration
{
    public enum CompletionStatus
    {
        Pending,

        Queued,

        Completed,

        Warning_NoHandlerSpecified,

        Error_HandlerCouldNotBeLoaded,

        Error_HandlerNotInvokedSuccessfully
    }
}
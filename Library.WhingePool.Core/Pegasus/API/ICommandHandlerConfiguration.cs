namespace WhingePool.Core.Pegasus.API
{
    public interface ICommandHandlerConfiguration : IAzureStorageConfiguration
    {
        string RegisteredCommandHandlersTableName { get; }

        string RegisteredCommandHandlersBlobContainerName { get; }
    }
}
using BrightSword.Pegasus.Configuration;

using Microsoft.WindowsAzure.Storage.Blob;

namespace BrightSword.Pegasus.API
{
    public interface ICommandHandlerContext : IKeyValueStore, IAzureStorageContext
    {
        CommandHandlersTable RegisteredCommandHandlersTable { get; }

        CloudBlobContainer RegisteredCommandHandlersBlobContainer { get; }
    }
}
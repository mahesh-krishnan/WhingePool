using Microsoft.WindowsAzure.Storage.Blob;

using WhingePool.Core.Pegasus.Configuration;

namespace WhingePool.Core.Pegasus.API
{
    public interface ICommandHandlerContext : IKeyValueStore
    {
        CommandHandlersTable RegisteredCommandHandlersTable { get; }

        CloudBlobContainer RegisteredCommandHandlersBlobContainer { get; }
    }
}
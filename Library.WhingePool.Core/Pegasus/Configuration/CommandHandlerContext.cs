using System;

using Microsoft.ApplicationServer.Caching;
using Microsoft.WindowsAzure.Storage.Blob;

using WhingePool.Core.Pegasus.API;

namespace WhingePool.Core.Pegasus.Configuration
{
    public class CommandHandlerContext : AzureStorageContext,
                                         ICommandHandlerContext
    {
        private static readonly DataCache _dataCache = GetDefaultDataCache();

        private readonly CloudBlobContainer _assembliesBlobContainer;

        private readonly CommandHandlersTable _registeredHandlersTable;

        protected CommandHandlerContext(ICommandHandlerConfiguration configuration)
            : base(configuration)
        {
            _registeredHandlersTable = new CommandHandlersTable(CloudStorageAccount,
                                                                configuration.RegisteredCommandHandlersTableName);

            _assembliesBlobContainer = new CloudBlobClient(CloudStorageAccount.BlobEndpoint,
                                                           CloudStorageAccount.Credentials).GetContainerReference(configuration.RegisteredCommandHandlersBlobContainerName);
            _assembliesBlobContainer.CreateIfNotExists();
        }

        private static DataCache Cache
        {
            get { return _dataCache; }
        }

        public CommandHandlersTable RegisteredCommandHandlersTable
        {
            get { return _registeredHandlersTable; }
        }

        public CloudBlobContainer RegisteredCommandHandlersBlobContainer
        {
            get { return _assembliesBlobContainer; }
        }

        public T GetOrAdd<T>(string key,
                             Func<T> valueFactory)
        {
            if (Cache == null)
            {
                return valueFactory();
            }

            lock (Cache)
            {
                if (Cache[key] == null)
                {
                    Cache[key] = valueFactory();
                }

                return (T) Cache[key];
            }
        }

        private static DataCache GetDefaultDataCache()
        {
            try
            {
                return new DataCache("default",
                                     "default");
            }
            catch
            {
                return null;
            }
        }
    }
}
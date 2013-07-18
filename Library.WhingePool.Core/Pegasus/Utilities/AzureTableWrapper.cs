using System.Collections.Generic;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace WhingePool.Core.Pegasus.Utilities
{
    public abstract class AzureTableWrapper<T>
        where T : class, ITableEntity, new()
    {
        protected AzureTableWrapper(CloudStorageAccount cloudStorageAccount,
                                    string tableName)
        {
            CloudStorageAccount = cloudStorageAccount;

            CloudTableClient = new CloudTableClient(CloudStorageAccount.TableEndpoint,
                                                    CloudStorageAccount.Credentials);

            TableName = tableName;

            Table = CloudTableClient.GetTableReference(TableName);
            Table.CreateIfNotExists();
        }

        internal CloudStorageAccount CloudStorageAccount { get; private set; }

        internal CloudTableClient CloudTableClient { get; private set; }

        internal string TableName { get; private set; }

        internal CloudTable Table { get; private set; }

        public virtual T EnsureInstance(T instance,
                                        bool fReplaceIfExists = false)
        {
            Table.Execute(fReplaceIfExists
                              ? TableOperation.InsertOrReplace(instance)
                              : TableOperation.InsertOrMerge(instance));

            return RetrieveInstance(instance);
        }

        public virtual T RetrieveInstance(T instance)
        {
            var retrievedRow = Table.Execute(TableOperation.Retrieve<T>(instance.PartitionKey,
                                                                        instance.RowKey));

            return (T) retrievedRow.Result;
        }

        public virtual void DeleteInstances(TableQuery<T> filter = null)
        {
            foreach (var instance in Table.ExecuteQuery(filter ?? new TableQuery<T>()))
            {
                DeleteInstance(instance);
            }
        }

        public virtual void DeleteInstance(T instance)
        {
            var existingInstance = RetrieveInstance(instance);

            if (existingInstance != null)
            {
                if (string.IsNullOrWhiteSpace(existingInstance.ETag))
                {
                    existingInstance.ETag = "*";
                }

                Table.Execute(TableOperation.Delete(existingInstance));
            }
        }

        public virtual IEnumerable<T> GetInstances(TableQuery<T> query = null)
        {
            return Table.ExecuteQuery(query ?? new TableQuery<T>());
        }
    }
}
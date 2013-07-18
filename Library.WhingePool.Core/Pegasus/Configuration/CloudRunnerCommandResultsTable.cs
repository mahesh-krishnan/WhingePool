using Microsoft.WindowsAzure.Storage;

using WhingePool.Core.Pegasus.Utilities;

namespace WhingePool.Core.Pegasus.Configuration
{
    public class CloudRunnerCommandResultsTable : AzureTableWrapper<CloudRunnerCommandResult>
    {
        public CloudRunnerCommandResultsTable(CloudStorageAccount cloudStorageAccount,
                                              string tableName)
            : base(cloudStorageAccount,
                   tableName) {}
    }
}
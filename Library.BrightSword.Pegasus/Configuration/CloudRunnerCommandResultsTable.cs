using BrightSword.Pegasus.Utilities;

using Microsoft.WindowsAzure.Storage;

namespace BrightSword.Pegasus.Configuration
{
    public class CloudRunnerCommandResultsTable : AzureTableWrapper<CloudRunnerCommandResult>
    {
        public CloudRunnerCommandResultsTable(CloudStorageAccount cloudStorageAccount,
                                              string tableName)
            : base(cloudStorageAccount,
                   tableName) {}
    }
}
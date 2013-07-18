using Microsoft.WindowsAzure.Storage;

using WhingePool.Core.Pegasus.Utilities;

namespace WhingePool.Core.Pegasus.Configuration
{
    public class CloudRunnerRuntimeErrorsTable : AzureTableWrapper<CloudRunnerRuntimeError>
    {
        public CloudRunnerRuntimeErrorsTable(CloudStorageAccount cloudStorageAccount,
                                             string tableName)
            : base(cloudStorageAccount,
                   tableName) {}
    }
}
using Microsoft.WindowsAzure.Storage;

using WhingePool.Core.Entities;
using WhingePool.Core.Pegasus.Utilities;

namespace WhingePool.Core.Tables
{
    public class WhingePoolsTable : AzureTableWrapper<WhingePoolEntity>
    {
        public WhingePoolsTable(CloudStorageAccount cloudStorageAccount,
                                string tableName)
            : base(cloudStorageAccount,
                   tableName) {}
    }
}
using BrightSword.Pegasus.Core.AzureTable;
using BrightSword.Pegasus.Utilities;

using Microsoft.WindowsAzure.Storage;

using WhingePool.Core.Entities;

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
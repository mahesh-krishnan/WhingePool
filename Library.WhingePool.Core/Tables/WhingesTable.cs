using BrightSword.Pegasus.Utilities;

using Microsoft.WindowsAzure.Storage;

using WhingePool.Core.Entities;

namespace WhingePool.Core.Tables
{
    public class WhingesTable : AzureTableWrapper<WhingeEntity>
    {
        public WhingesTable(CloudStorageAccount cloudStorageAccount,
                            string tableName)
            : base(cloudStorageAccount,
                   tableName) {}
    }
}
using BrightSword.Pegasus.Utilities;

using Microsoft.WindowsAzure.Storage;

using WhingePool.Core.Entities;

namespace WhingePool.Core.Tables
{
    public class WhingersTable : AzureTableWrapper<WhingerEntity>
    {
        public WhingersTable(CloudStorageAccount cloudStorageAccount,
                             string tableName)
            : base(cloudStorageAccount,
                   tableName) {}
    }
}
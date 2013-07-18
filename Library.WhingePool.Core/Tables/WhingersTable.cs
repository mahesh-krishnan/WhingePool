using Microsoft.WindowsAzure.Storage;

using WhingePool.Core.Entities;
using WhingePool.Core.Pegasus.Utilities;

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
using BrightSword.Pegasus.Core.AzureTable;
using BrightSword.Pegasus.Utilities;

using Microsoft.WindowsAzure.Storage;

using WhingePool.Core.Entities;

namespace WhingePool.Core.Tables
{
    public class WhingesByWhingePoolTable : AzureTableWrapper<WhingesByWhingePoolEntity>
    {
        public WhingesByWhingePoolTable(CloudStorageAccount cloudStorageAccount,
                                        string tableName)
            : base(cloudStorageAccount,
                   tableName) {}
    }
}
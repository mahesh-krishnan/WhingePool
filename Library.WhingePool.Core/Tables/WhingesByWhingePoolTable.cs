using Microsoft.WindowsAzure.Storage;

using WhingePool.Core.Entities;
using WhingePool.Core.Pegasus.Utilities;

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
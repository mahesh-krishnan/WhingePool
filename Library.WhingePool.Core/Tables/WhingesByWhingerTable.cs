using Microsoft.WindowsAzure.Storage;

using WhingePool.Core.Entities;
using WhingePool.Core.Pegasus.Utilities;

namespace WhingePool.Core.Tables
{
    public class WhingesByWhingerTable : AzureTableWrapper<WhingesByWhingerEntity>
    {
        public WhingesByWhingerTable(CloudStorageAccount cloudStorageAccount,
                                     string tableName)
            : base(cloudStorageAccount,
                   tableName) {}
    }
}
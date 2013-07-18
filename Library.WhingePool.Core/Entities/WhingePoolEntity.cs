using Microsoft.WindowsAzure.Storage.Table;

using WhingePool.Core.API;

namespace WhingePool.Core.Entities
{
    public class WhingePoolEntity : TableEntity,
                                    IWhingePool
    {
        public WhingePoolEntity()
        {
            PartitionKey = "WhingePools";
        }

        public string Name
        {
            get { return RowKey; }
            set { RowKey = value; }
        }
    }
}
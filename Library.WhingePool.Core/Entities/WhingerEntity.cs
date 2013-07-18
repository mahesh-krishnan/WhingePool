using BrightSword.Pegasus.API;

using Microsoft.WindowsAzure.Storage.Table;

namespace WhingePool.Core.Entities
{
    public class WhingerEntity : TableEntity,
                                 ICommandArgument
    {
        public WhingerEntity()
        {
            PartitionKey = "Whingers";
        }

        public string TwitterHandle
        {
            get { return RowKey; }
            set { RowKey = value; }
        }
    }
}
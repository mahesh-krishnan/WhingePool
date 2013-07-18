using System;

using Microsoft.WindowsAzure.Storage.Table;

using WhingePool.Core.Pegasus.API;

namespace WhingePool.Core.Entities
{
    public class WhingerEntity : TableEntity,
                                 ICommandArgument
    {
        public WhingerEntity()
        {
            PartitionKey = DateTime.Today.ToString("s");
        }

        public string TwitterHandle
        {
            get { return RowKey; }
            set { RowKey = value; }
        }
    }
}
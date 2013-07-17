using System;

using Microsoft.WindowsAzure.Storage.Table;

namespace WhingePool.Core.Entities
{
    public class WhingerEntity : TableEntity
    {
        public WhingerEntity()
        {
            PartitionKey = DateTime.Today.ToString("s");
        }

        public string TwitterHandle
        {
            get
            {
                return RowKey;
            }
            set
            {
                RowKey = value;
            }
        }
    }
}
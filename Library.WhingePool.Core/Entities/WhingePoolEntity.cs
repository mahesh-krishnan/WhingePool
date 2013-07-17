using System;

using Microsoft.WindowsAzure.Storage.Table;

namespace WhingePool.Core.Entities
{
    public class WhingePoolEntity : TableEntity
    {
        public WhingePoolEntity()
        {
            PartitionKey = DateTime.Today.ToString("s");
        }

        public string Name
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
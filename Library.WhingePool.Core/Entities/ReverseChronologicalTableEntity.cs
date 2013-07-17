using System;

using Microsoft.WindowsAzure.Storage.Table;

namespace WhingePool.Core.Entities
{
    public class ReverseChronologicalTableEntity : TableEntity
    {
        public ReverseChronologicalTableEntity()
        {
            RowKey = String.Format("{0:d19}",
                                   DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks);
            PartitionKey = DateTime.Today.ToString("s");
        }
    }
}
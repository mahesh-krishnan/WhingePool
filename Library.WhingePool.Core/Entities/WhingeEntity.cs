using System;

namespace WhingePool.Core.Entities
{
    public class WhingeEntity : ReverseChronologicalTableEntity
    {
        public WhingeEntity()
        {
            PartitionKey = DateTime.Today.ToString("s");
        }

        public string Whinge { get; set; }

        public string WhingePool { get; set; }
    }
}
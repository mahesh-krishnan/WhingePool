using BrightSword.Pegasus.Entities;

namespace WhingePool.Core.Entities
{
    public class WhingesByWhingePoolEntity : ReverseChronologicalTableEntity
    {
        public string Whinge { get; set; }

        public string Whinger { get; set; }

        public string WhingePool
        {
            get { return PartitionKey; }
            set { PartitionKey = value; }
        }
    }
}
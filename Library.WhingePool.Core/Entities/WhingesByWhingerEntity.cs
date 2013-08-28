using BrightSword.Pegasus.Core.AzureTable;

namespace WhingePool.Core.Entities
{
    public class WhingesByWhingerEntity : ReverseChronologicalTableEntity
    {
        public string Whinge { get; set; }

        public string WhingePool { get; set; }

        public string Whinger
        {
            get { return PartitionKey; }
            set { PartitionKey = value; }
        }
    }
}
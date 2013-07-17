namespace WhingePool.Core.Entities
{
    public class WhingesByWhingerEntity : ReverseChronologicalTableEntity
    {
        public string Whinge { get; set; }

        public string WhingePool
        {
            get
            {
                return PartitionKey;
            }
            set
            {
                PartitionKey = value;
            }
        }
    }
}
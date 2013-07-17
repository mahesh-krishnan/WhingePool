using System;

using Newtonsoft.Json;

using WhingePool.Core.API;

namespace WhingePool.Core.Entities
{
    public class WhingeEntity : ReverseChronologicalTableEntity,
                                IWhinge
    {
        public WhingeEntity()
        {
            PartitionKey = DateTime.Today.ToString("s");
        }

        public string Whinge { get; set; }

        public string WhingePool { get; set; }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
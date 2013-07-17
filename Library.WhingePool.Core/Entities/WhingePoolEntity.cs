using System;

using Microsoft.WindowsAzure.Storage.Table;

using Newtonsoft.Json;

using WhingePool.Core.API;

namespace WhingePool.Core.Entities
{
    public class WhingePoolEntity : TableEntity, IWhingePool
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

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
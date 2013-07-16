using System;
using System.Collections.Generic;
using System.Linq;
using BrightSword.SwissKnife;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.Table.DataServices;
using BrightSword.Pegasus.Utilities;

namespace WhingePool.Models
{
    public class Whinge : TableEntity
    {
        public string Id { get; set; }

        public string WhingePool { get; set; }
        public DateTime WhingeTime { get; set; }
        public string Text { get; set; }

        public Whinge() {}

        public Whinge(string user, string text, string whingePool)
        {
            PartitionKey = user;
            RowKey = string.Format("{0:D19}", DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks); 
            Text = text;
            WhingePool = whingePool;
            WhingeTime = DateTime.Now;

        }
    }

    public class WhingeByPool : TableEntity
    {
        public string Id { get; set; }

        public string User { get; set; }
        public DateTime WhingeTime { get; set; }
        public string Text { get; set; }

        public WhingeByPool(string user, string text, string whingePool)
        {
            PartitionKey = whingePool;
            RowKey = string.Format("{0:D19}", DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks);
            Text = text;
            User = user;
            WhingeTime = DateTime.Now;

        }
    }

    //public class CloudRunnerTasksTable : BrightSword.Pegasus.Utilities AzureTableWrapper<WhingePool>
    //{
    //    public CloudRunnerTasksTable(CloudStorageAccount cloudStorageAccount,
    //                                 string tableName)
    //        : base(cloudStorageAccount,
    //               tableName) { }

    //    public virtual IEnumerable<Whinge> GetPendingTasks()
    //    {
    //        var filter = TableQuery.GenerateFilterCondition();

    //        var query = new TableQuery<Whinge>().Where(filter);

    //        return GetInstances(query);
    //    }
    //}
    public class WhingesDataContext : TableServiceContext
    {
        public WhingesDataContext(CloudTableClient client) : base(client)
        {
        }

        public IEnumerable<Whinge> GetWhingesByUsers(string user)
        {
            var rowKeyToUse = string.Format("{0:D19}", DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks);
 
            var results = (from whinge in CreateQuery<Whinge>("WhingesByUser")
                where whinge.PartitionKey == user
                && String.Compare(whinge.RowKey, rowKeyToUse, StringComparison.Ordinal) > 0
                    select whinge).Take(100);
            return results;
        }

        public IEnumerable<WhingeByPool> GetWhingesByPool(string whingePool)
        {
            var rowKeyToUse = string.Format("{0:D19}", DateTime.MaxValue.Ticks - DateTime.UtcNow.Ticks);

            var results = (from whinge in CreateQuery<WhingeByPool>("WhingesByWhingePool")
                           where whinge.PartitionKey == whingePool
                           && String.Compare(whinge.RowKey, rowKeyToUse, StringComparison.Ordinal) > 0
                           select whinge).Take(100);
            return results;
        }
    }
}
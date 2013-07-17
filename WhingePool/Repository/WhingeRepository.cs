using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Storage.Table;
using WhingePool.Core;
using WhingePool.Core.Configuration;
using WhingePool.Core.Entities;
using WhingePool.Models;

namespace WhingePool.Repository
{

    
    public class WhingeRepository
    {
        public WhingePoolApplicationContext ApplicationContext { get; set; }

        public WhingeRepository()
        {
            ApplicationContext = new WhingePoolApplicationContext(new WhingePoolConfiguration()
            {
                StorageAccount = "myobpdqaart",
                StorageAccountKey = "MHDYieseAgGX6HbE8yWK4e0L2eKkUt+an6UbX1/6o0nC2FK2pmgxi/OVW+WEVyH50ROBRMtw0wxf057KDTaDfA==",
                RegisteredHandlersBlobContainerName = "whingepool-test-handler-assemblies",
                RegisteredHandlersTableName = "WhingePoolTestHandlers",
                RuntimeErrorsTableName = "WhingePoolTestWhingePoolRuntimeErrors",
                ScheduledTasksQueueName = "whingepool-test-whinge-queue",
                WhingesTableName = "WhingePoolTestWhinges",
                WhingersTableName = "WhingePoolTestWhingers",
                WhingePoolsTableName = "WhingePoolTestWhingePools",
                WhingesByWhingerTableName = "WhingePoolTestWhingesByWhinger",
                WhingesByWhingePoolTableName = "WhingePoolTestWhingesByWhingePool"
            });


        }
        public IEnumerable<Whinge> GetWhinges(string userName)
        {
            var query = new TableQuery<WhingesByWhingerEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, userName));

            return
                ApplicationContext.WhingesByWhingerTable.GetInstances(query).Select(_ => new Whinge() { Text = _.Whinge, WhingePool = _.WhingePool });
        }
        public IEnumerable<Whinge> GetWhingesInWhingePool(string whingePoolName)
        {
            var query = new TableQuery<WhingesByWhingePoolEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, whingePoolName));

            return
                ApplicationContext.WhingesByWhingePoolTable.GetInstances(query).Select(_ => new Whinge() { Text = _.Whinge, WhingePool = _.WhingePool });
        }

        public IEnumerable< Models.WhingePool> GetWhingePools()
        {
            return
                ApplicationContext.WhingePoolsTable.GetInstances().Select(_ => new Models.WhingePool() { Title = _.Name});
        }

        public void Whinge(Whinge whinge)
        {
            var service = new WhingeService(ApplicationContext);
            service.Save(new WhingeEntity()
            {
                Whinge = whinge.Text,
                WhingePool = whinge.WhingePool,
                Whinger = whinge.User
            });

        }
    }
}
using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Table;
using WhingePool.Core;
using WhingePool.Core.Configuration;
using WhingePool.Core.Entities;

namespace WhingePool.Repository
{
    public class WhingeRepository
    {
        public WhingePoolApplicationContext ApplicationContext { get; set; }

        public WhingeRepository()
        {
            ApplicationContext = new WhingePoolApplicationContext(new WhingePoolConfiguration
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
        public IEnumerable<WhingesByWhingerEntity> GetWhinges(string userName)
        {
            var query = new TableQuery<WhingesByWhingerEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, userName));

            return ApplicationContext.WhingesByWhingerTable.GetInstances(query);
        }
        public IEnumerable<WhingesByWhingePoolEntity> GetWhingesInWhingePool(string whingePoolName)
        {
            var query = new TableQuery<WhingesByWhingePoolEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, whingePoolName));

            return ApplicationContext.WhingesByWhingePoolTable.GetInstances(query);
        }

        public IEnumerable<WhingePoolEntity> GetWhingePools()
        {
            return ApplicationContext.WhingePoolsTable.GetInstances();
        }

        public void Whinge(WhingeEntity whinge)
        {
            var service = new WhingeService(ApplicationContext);
            service.Save(whinge);

        }
    }
}
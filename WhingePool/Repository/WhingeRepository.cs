using System.Collections.Generic;

using Microsoft.WindowsAzure.Storage.Table;

using WhingePool.Core.Configuration;
using WhingePool.Core.Entities;
using WhingePool.Core.Services;

namespace WhingePool.Repository
{
    public class WhingeRepository
    {
        public WhingeRepository()
        {
            ApplicationContext = new WhingePoolApplicationContext();
        }

        public WhingePoolApplicationContext ApplicationContext { get; set; }

        public IEnumerable<WhingesByWhingerEntity> GetWhinges(string userName)
        {
            var query = new TableQuery<WhingesByWhingerEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey",
                                                                                                          QueryComparisons.Equal,
                                                                                                          userName));

            return ApplicationContext.WhingesByWhingerTable.GetInstances(query);
        }

        public IEnumerable<WhingesByWhingePoolEntity> GetWhingesInWhingePool(string whingePoolName)
        {
            var query = new TableQuery<WhingesByWhingePoolEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey",
                                                                                                             QueryComparisons.Equal,
                                                                                                             whingePoolName));

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
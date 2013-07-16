using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using WhingePool.Models;

namespace WhingePool.Repository
{
    public class WhingeRepository
    {
        public WhingesDataContext WhingesDataContext { get; set; }

        public WhingeRepository()
        {
            var tableClient = new CloudTableClient(new Uri("tables"),  CloudStorageAccount.DevelopmentStorageAccount.Credentials);
            WhingesDataContext = new WhingesDataContext(tableClient);
            
            //WhingesDataContext.

        }
        public IEnumerable<Whinge> GetWhinges(string userName)
        {
            return WhingesDataContext.GetWhingesByUsers(userName);
        }
        public IEnumerable<WhingeByPool> GetWhingesInWhingePool(string whingePoolName)
        {
            return WhingesDataContext.GetWhingesByPool(whingePoolName);
        }
    }
}
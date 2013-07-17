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
    public class Whinge 
    {
        public string WhingePool { get; set; }
        public DateTime WhingeTime { get; set; }
        public string Text { get; set; }
        public string User { get; set; }

        public Whinge() {}

        public Whinge(string user, string text, string whingePool)
        {
            User = user;
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

 
}
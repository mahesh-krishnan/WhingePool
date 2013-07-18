using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;

using WhingePool.Core.Configuration;
using WhingePool.Core.Pegasus.API;
using WhingePool.Core.Pegasus.CommandProcessor;

namespace Worker.WhingePool.Main
{
    public class WorkerRole : ForeverRunningRole
    {
        protected override ICommandQueueConfiguration Configuration
        {
            get { return new WhingePoolConfiguration(); }
        }

        protected override int PeriodInMilliseconds
        {
            get { throw new NotImplementedException(); }
        }

        protected override void Action()
        {
            throw new NotImplementedException();
        }

        public override void Run()
        {
            // This is a sample worker implementation. Replace with your logic.
            Trace.TraceInformation("Worker.WhingePool.Main entry point called", "Information");

            while (true)
            {
                Thread.Sleep(10000);
                Trace.TraceInformation("Working", "Information");
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections 
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            return base.OnStart();
        }
    }
}

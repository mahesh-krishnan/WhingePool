using System.Net;

using Microsoft.WindowsAzure.ServiceRuntime;

using WhingePool.Core.Configuration;
using WhingePool.Core.Pegasus.API;

namespace WhingePool.Core.Pegasus.CommandProcessor
{
    public abstract class ForeverRunningRole : RoleEntryPoint
    {
        private WhingePoolApplicationContext _context;

        private ForeverRunner _foreverRunner;

        protected abstract ICommandQueueConfiguration Configuration { get; }

        protected virtual WhingePoolApplicationContext Context
        {
            get { return _context ?? (_context = new WhingePoolApplicationContext()); }
        }

        protected ForeverRunner ForeverRunner
        {
            get
            {
                return _foreverRunner ?? (_foreverRunner = new ForeverRunner(Action,
                                                                             PeriodInMilliseconds));
            }
        }

        protected abstract int PeriodInMilliseconds { get; }

        protected abstract void Action();

        public override void Run()
        {
            ForeverRunner.Run();
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
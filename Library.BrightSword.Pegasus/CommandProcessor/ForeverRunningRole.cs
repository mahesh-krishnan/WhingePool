using System.Net;

using BrightSword.Pegasus.API;

using Microsoft.WindowsAzure.ServiceRuntime;

namespace BrightSword.Pegasus.CommandProcessor
{
    public abstract class ForeverRunningRole : RoleEntryPoint
    {
        private ForeverRunner _foreverRunner;

        protected abstract ICloudRunnerContext Context { get; }

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
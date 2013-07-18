using System;

using BrightSword.Pegasus.API;
using BrightSword.Pegasus.CommandProcessor;

using WhingePool.Core.Configuration;

namespace Worker.WhingePool.Main
{
    public class WorkerRole : RoleBase
    {
        private readonly WhingePoolApplicationContext _whingePoolApplicationContext;

        public WorkerRole()
        {
            _whingePoolApplicationContext = new WhingePoolApplicationContext();
        }

        protected override ICloudRunnerContext Context
        {
            get { return _whingePoolApplicationContext; }
        }

        protected override int PeriodInMilliseconds
        {
            get { return 3*1000; }
        }
    }
}
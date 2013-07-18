using System;

using WhingePool.Core.Pegasus.API;

namespace WhingePool.Core.Pegasus.Configuration
{
    public class CloudRunnerCommand : ICommand<string>
    {
        public string CommandArgument { get; private set; }

        public Guid CommandId { get; private set; }
    }
}
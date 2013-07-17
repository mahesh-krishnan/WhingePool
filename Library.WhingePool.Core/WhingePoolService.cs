using WhingePool.Core.API;
using WhingePool.Core.Commands;
using WhingePool.Core.Configuration;

namespace WhingePool.Core
{
    public class WhingePoolService : IWhingePoolService
    {
        public WhingePoolService(WhingePoolApplicationContext context)
        {
            Context = context;
        }

        public WhingePoolApplicationContext Context { get; private set; }

        public ISaveResult Save(IWhingePool whinge)
        {
            var command = new EnsureWhingePoolCommand(whinge);

            Context.ScheduledTasksQueue.AddMessage(command);

            return new SaveResult(command.CommandId);
        }
    }
}
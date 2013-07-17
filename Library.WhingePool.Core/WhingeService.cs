using WhingePool.Core.API;
using WhingePool.Core.Commands;
using WhingePool.Core.Configuration;

namespace WhingePool.Core
{
    public class WhingeService : IWhingeService
    {
        public WhingeService(WhingePoolApplicationContext context)
        {
            Context = context;
        }

        public WhingePoolApplicationContext Context { get; private set; }

        public ISaveResult Save(IWhinge whinge)
        {
            var command = new WhingeCommand(whinge);

            Context.ScheduledTasksQueue.AddMessage(command);

            return new SaveResult(command.CommandId);
        }
    }
}
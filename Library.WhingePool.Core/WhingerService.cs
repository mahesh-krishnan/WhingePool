using WhingePool.Core.API;
using WhingePool.Core.Commands;
using WhingePool.Core.Configuration;

namespace WhingePool.Core
{
    public class WhingerService : IWhingerService
    {
        public WhingerService(WhingePoolApplicationContext context)
        {
            Context = context;
        }

        public WhingePoolApplicationContext Context { get; private set; }

        public ISaveResult Save(IWhinger whinger)
        {
            var command = new EnsureWhingerCommand(whinger);

            Context.ScheduledTasksQueue.AddMessage(command);

            return new SaveResult(command.CommandId);
        }
    }
}
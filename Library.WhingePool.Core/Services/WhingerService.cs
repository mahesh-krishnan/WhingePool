using WhingePool.Core.API;
using WhingePool.Core.Commands;
using WhingePool.Core.Configuration;
using WhingePool.Core.Entities;
using WhingePool.Core.Pegasus.API;
using WhingePool.Core.Pegasus.Commands;

namespace WhingePool.Core.Services
{
    public class WhingerService : IWhingerService
    {
        public WhingerService(WhingePoolApplicationContext context)
        {
            Context = context;
        }

        public WhingePoolApplicationContext Context { get; private set; }

        public ISaveResult Save(WhingerEntity whinger)
        {
            var command = new EnsureWhingerCommand(whinger);

            Context.CommandsQueue.EnqueueCommand<EnsureWhingerCommand, WhingerEntity>(command);

            return new SaveResult(command.CommandId);
        }
    }
}
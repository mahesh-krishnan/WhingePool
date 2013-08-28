using BrightSword.Pegasus.API;
using BrightSword.Pegasus.Commands;
using BrightSword.Pegasus.Commands.Core;
using WhingePool.Core.API;
using WhingePool.Core.Commands;
using WhingePool.Core.Configuration;
using WhingePool.Core.Entities;

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

            Context.CommandQueue.EnqueueCommand<EnsureWhingerCommand, WhingerEntity>(command);

            return new SaveResult(command.CommandId);
        }
    }
}
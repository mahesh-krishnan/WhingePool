using BrightSword.Pegasus.API;
using BrightSword.Pegasus.Commands;
using BrightSword.Pegasus.Commands.Core;
using WhingePool.Core.API;
using WhingePool.Core.Commands;
using WhingePool.Core.Configuration;
using WhingePool.Core.Entities;

namespace WhingePool.Core.Services
{
    public class WhingePoolService : IWhingePoolService
    {
        public WhingePoolService(WhingePoolApplicationContext context)
        {
            Context = context;
        }

        public WhingePoolApplicationContext Context { get; private set; }

        public ISaveResult Save(WhingePoolEntity whinge)
        {
            var command = new EnsureWhingePoolCommand(whinge);

            Context.CommandQueue.EnqueueCommand<EnsureWhingePoolCommand, WhingePoolEntity>(command);

            return new SaveResult(command.CommandId);
        }
    }
}
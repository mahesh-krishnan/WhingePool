using WhingePool.Core.API;
using WhingePool.Core.Commands;
using WhingePool.Core.Configuration;
using WhingePool.Core.Entities;
using WhingePool.Core.Pegasus.API;
using WhingePool.Core.Pegasus.Commands;

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

            Context.CommandsQueue.EnqueueCommand<EnsureWhingePoolCommand, WhingePoolEntity>(command);

            return new SaveResult(command.CommandId);
        }
    }
}
using BrightSword.Pegasus.API;
using BrightSword.Pegasus.Commands;

using WhingePool.Core.API;
using WhingePool.Core.Commands;
using WhingePool.Core.Configuration;
using WhingePool.Core.Entities;

namespace WhingePool.Core.Services
{
    public class WhingeService : IWhingeService
    {
        public WhingeService(WhingePoolApplicationContext context)
        {
            Context = context;
        }

        public WhingePoolApplicationContext Context { get; private set; }

        public ISaveResult Save(WhingeEntity whinge)
        {
            var command = new SaveWhingeCommand(whinge);

            Context.CommandsQueue.EnqueueCommand<SaveWhingeCommand, WhingeEntity>(command);

            return new SaveResult(command.CommandId);
        }
    }
}
using BrightSword.Pegasus.API;
using BrightSword.Pegasus.Utilities;

using Newtonsoft.Json;

using WhingePool.Core.Commands;
using WhingePool.Core.Configuration;
using WhingePool.Core.Entities;

namespace Library.WhingePool.CommandHandlers
{
    [RegisterCommandHandler(typeof (SaveWhingeCommand))]
    public class SaveWhingeCommandHandler : ICommandHandler
    {
        public void ProcessCommand(ICommand command,
                                   ICloudRunnerContext context)
        {
            var applicationContext = (WhingePoolApplicationContext) context;

            var whinge = JsonConvert.DeserializeObject<WhingeEntity>(command.SerializedCommandArgument);

            var whingePool = applicationContext.WhingePoolsTable.RetrieveInstanceByRowKey(whinge.WhingePool);
            if (whingePool == null)
            {
                context.CommandsQueue.EnqueueCommand(new EnsureWhingePoolCommand(new WhingePoolEntity
                                                                                 {
                                                                                     Name = whinge.WhingePool
                                                                                 }));
            }

            context.CommandsQueue.EnqueueCommand(new RecordWhingeAgainstWhingerCommand(whinge));
            context.CommandsQueue.EnqueueCommand(new RecordWhingeAgainstWhingePoolCommand(whinge));
        }
    }
}
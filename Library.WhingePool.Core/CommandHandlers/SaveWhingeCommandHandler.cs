using BrightSword.Pegasus.API;
using BrightSword.Pegasus.API.Attributes;

using Newtonsoft.Json;

using WhingePool.Core.Commands;
using WhingePool.Core.Configuration;
using WhingePool.Core.Entities;

namespace WhingePool.Core.CommandHandlers
{
    [RegisterCommandHandler(typeof (SaveWhingeCommand))]
    public class SaveWhingeCommandHandler : ICommandHandler
    {
        public void ProcessCommand(ICommand command,
                                   ICommandHandlerContext context)
        {
            var applicationContext = (WhingePoolApplicationContext) context;

            var whinge = JsonConvert.DeserializeObject<WhingeEntity>(command.SerializedCommandArgument);

            var whingePool = applicationContext.WhingePoolsTable.RetrieveInstanceByRowKey(whinge.WhingePool);
            if (whingePool == null)
            {
                applicationContext.CommandQueue.EnqueueCommand(new EnsureWhingePoolCommand(new WhingePoolEntity
                                                                                 {
                                                                                     Name = whinge.WhingePool
                                                                                 }));
            }

            applicationContext.CommandQueue.EnqueueCommand(new RecordWhingeAgainstWhingerCommand(whinge));
            applicationContext.CommandQueue.EnqueueCommand(new RecordWhingeAgainstWhingePoolCommand(whinge));
        }


    }
}
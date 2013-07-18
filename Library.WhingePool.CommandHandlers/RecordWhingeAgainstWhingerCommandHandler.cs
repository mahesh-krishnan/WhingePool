using Newtonsoft.Json;

using WhingePool.Core.Configuration;
using WhingePool.Core.Entities;
using BrightSword.Pegasus.API;
using BrightSword.Pegasus.Utilities;

namespace Library.WhingePool.CommandHandlers
{
    [RegisterCommandHandler(typeof(RecordWhingeAgainstWhingerCommand))]
    public class RecordWhingeAgainstWhingerCommandHandler : ICommandHandler
    {
        public void ProcessCommand(ICommand command,
        ICloudRunnerContext context)
        {
            var applicationContext = (WhingePoolApplicationContext)context;

            var whinge = JsonConvert.DeserializeObject<WhingeEntity>(command.SerializedCommandArgument);

            applicationContext.WhingesByWhingerTable.EnsureInstance(new WhingesByWhingerEntity
                                                         {
                                                             Whinge = whinge.Whinge,
                                                             WhingePool = whinge.WhingePool,
                                                             Whinger = whinge.Whinger
                                                         });
        }
    }
}
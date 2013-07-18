using Newtonsoft.Json;

using WhingePool.Core.Configuration;
using WhingePool.Core.Entities;
using BrightSword.Pegasus.API;
using BrightSword.Pegasus.Utilities;

namespace Library.WhingePool.CommandHandlers
{
    [RegisterCommandHandler(typeof(RecordWhingeAgainstWhingePoolCommand))]
    public class RecordWhingeAgainstWhingePoolCommandHandler : ICommandHandler
    {
        public void ProcessCommand(ICommand command,
 ICloudRunnerContext context)
        {
            var applicationContext = (WhingePoolApplicationContext)context;
            var whinge = JsonConvert.DeserializeObject<WhingeEntity>(command.SerializedCommandArgument);
            applicationContext.WhingesByWhingePoolTable.EnsureInstance(new WhingesByWhingePoolEntity
                                                            {
                                                                Whinge = whinge.Whinge,
                                                                WhingePool = whinge.WhingePool,
                                                                Whinger = whinge.Whinger
                                                            });
        }
    }
}
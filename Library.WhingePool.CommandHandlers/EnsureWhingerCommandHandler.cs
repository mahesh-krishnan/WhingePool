using Newtonsoft.Json;

using WhingePool.Core.Commands;
using WhingePool.Core.Configuration;
using WhingePool.Core.Entities;
using BrightSword.Pegasus.API;
using BrightSword.Pegasus.Utilities;

namespace Library.WhingePool.CommandHandlers
{
    //[RegisterCommandHandler(typeof(EnsureWhingerCommand))]
    //public class EnsureWhingerCommandHandler : ICommandHandler
    //{
    //    public void ProcessCommand(ICommand command,
    //                               ICloudRunnerContext context)
    //    {
    //        var applicationContext = (WhingePoolApplicationContext)context;

    //        var whingePool = JsonConvert.DeserializeObject<WhingerEntity>(command.SerializedCommandArgument);

    //        applicationContext.WhingersTable.EnsureInstance(whingePool);
    //    }
    //}
}
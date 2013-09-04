using BrightSword.Pegasus.API;
using BrightSword.Pegasus.API.Attributes;

using Newtonsoft.Json;

using WhingePool.Core.Commands;
using WhingePool.Core.Configuration;
using WhingePool.Core.Entities;

namespace WhingePool.Core.CommandHandlers
{
    [RegisterCommandHandler(typeof (EnsureWhingePoolCommand))]
    public class EnsureWhingePoolCommandHandler : ICommandHandler
    {
        public void ProcessCommand(ICommand command,
                                   ICommandHandlerContext context)
        {
            var applicationContext = (WhingePoolApplicationContext) context;
            var whingePool = JsonConvert.DeserializeObject<WhingePoolEntity>(command.SerializedCommandArgument);
            if (string.IsNullOrWhiteSpace(whingePool.Name))
            {
                whingePool.Name = "default";
            }
            whingePool.Name = whingePool.Name.ToUpperInvariant();
 
            applicationContext.WhingePoolsTable.EnsureInstance(whingePool);
        }
    }
}
﻿using BrightSword.Pegasus.API;
using BrightSword.Pegasus.Utilities;

using Newtonsoft.Json;

using WhingePool.Core.Commands;
using WhingePool.Core.Configuration;
using WhingePool.Core.Entities;

namespace Library.WhingePool.CommandHandlers
{
    [RegisterCommandHandler(typeof (EnsureWhingePoolCommand))]
    public class EnsureWhingePoolCommandHandler : ICommandHandler
    {
        public void ProcessCommand(ICommand command,
                                   ICloudRunnerContext context)
        {
            var applicationContext = (WhingePoolApplicationContext) context;
            var whingePool = JsonConvert.DeserializeObject<WhingePoolEntity>(command.SerializedCommandArgument);

            applicationContext.WhingePoolsTable.EnsureInstance(whingePool);
        }
    }
}
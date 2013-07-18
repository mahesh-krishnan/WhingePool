using System.Linq;

using Microsoft.WindowsAzure.Storage.Table;

using Newtonsoft.Json;

using WhingePool.Core.Commands;
using WhingePool.Core.Configuration;
using WhingePool.Core.Entities;
using WhingePool.Core.Pegasus.API;
using WhingePool.Core.Pegasus.Commands;

namespace Library.WhingePool.CommandHandlers
{
    public class SaveWhingeCommandHandler : ICommandHandler
    {
        public void ProcessCommand(ICommand command,
                                   WhingePoolApplicationContext context)
        {
            var whinge = JsonConvert.DeserializeObject<WhingeEntity>(command.SerializedCommandArgument);


            var whingePool = context.WhingePoolsTable.GetInstances(new TableQuery<WhingePoolEntity>().Where(TableQuery.GenerateFilterCondition("Name",
                                                                                                                                               QueryComparisons.Equal,
                                                                                                                                               whinge.WhingePool)))
                                    .FirstOrDefault();

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
    public class EnsureWhingePoolCommandHandler : ICommandHandler
    {
        public void ProcessCommand(ICommand command,
                                   WhingePoolApplicationContext context)
        {
            var whingePool = JsonConvert.DeserializeObject<WhingePoolEntity>(command.SerializedCommandArgument);

            context.WhingePoolsTable.EnsureInstance(whingePool);
        }
    }

    public class RecordWhingeAgainstWhingerCommandHandler : ICommandHandler
    {
        public void ProcessCommand(ICommand command,
                                   WhingePoolApplicationContext context)
        {
            var whinge = JsonConvert.DeserializeObject<WhingeEntity>(command.SerializedCommandArgument);

            context.WhingesByWhingerTable.EnsureInstance(new WhingesByWhingerEntity
                                                         {
                                                             Whinge = whinge.Whinge,
                                                             WhingePool = whinge.WhingePool,
                                                             Whinger = whinge.Whinger
                                                         });
        }
    }

    public class RecordWhingeAgainstWhingePoolCommandHandler : ICommandHandler
    {
        public void ProcessCommand(ICommand command,
                                   WhingePoolApplicationContext context)
        {
            var whinge = JsonConvert.DeserializeObject<WhingeEntity>(command.SerializedCommandArgument);
            context.WhingesByWhingePoolTable.EnsureInstance(new WhingesByWhingePoolEntity
                                                            {
                                                                Whinge = whinge.Whinge,
                                                                WhingePool = whinge.WhingePool,
                                                                Whinger = whinge.Whinger
                                                            });
        }
    }

    public class RecordWhingeAgainstWhingerCommand : Command<WhingeEntity>
    {
        public RecordWhingeAgainstWhingerCommand(WhingeEntity whinge)
            : base(whinge) {}
    }

    public class RecordWhingeAgainstWhingePoolCommand : Command<WhingeEntity>
    {
        public RecordWhingeAgainstWhingePoolCommand(WhingeEntity whinge)
            : base(whinge) {}
    }
}
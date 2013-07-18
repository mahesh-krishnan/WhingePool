using System;
using System.IO;

using Microsoft.WindowsAzure.Storage.Table;

using WhingePool.Core.Pegasus.API;

namespace WhingePool.Core.Pegasus.Configuration
{
    public class CommandHandler : TableEntity
    {
        public CommandHandler()
        {
            PartitionKey = "TaskHandlers";
            RowKey = Guid.NewGuid()
                         .ToString("D");
            Timestamp = DateTime.Now;
        }

        public CommandHandler(string commandName,
                              Type commandHandlerType)
            : this()
        {
            CommandName = commandName;
            CommandHandlerTypeAssembly = Path.GetFileNameWithoutExtension(commandHandlerType.Assembly.CodeBase);
            CommandHandlerTypeAssemblyQualifiedName = commandHandlerType.FullName;
        }

        public string CommandName
        {
            get { return RowKey; }
            set { RowKey = value; }
        }

        public string CommandHandlerTypeAssembly { get; set; }

        public string CommandHandlerTypeAssemblyQualifiedName { get; set; }

        public void ProcessCommand(ICommand command,
                                   ICommandHandlerContext context)
        {
        }
    }
}
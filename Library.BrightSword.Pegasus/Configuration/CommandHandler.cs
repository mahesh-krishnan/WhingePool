using System;
using System.IO;

using BrightSword.Pegasus.API;

using Microsoft.WindowsAzure.Storage.Table;

namespace BrightSword.Pegasus.Configuration
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

        public CommandHandler(string commandName,
                              string commandHandlerTypeAssembly,
                              string commandHandlerTypeAssemblyQualifiedName)
            : this()
        {
            CommandName = commandName;
            CommandHandlerTypeAssembly = commandHandlerTypeAssembly;
            CommandHandlerTypeAssemblyQualifiedName = commandHandlerTypeAssemblyQualifiedName;
        }

        public string CommandName
        {
            get { return RowKey; }
            set { RowKey = value; }
        }

        public string CommandHandlerTypeAssembly { get; set; }

        public string CommandHandlerTypeAssemblyQualifiedName { get; set; }

        public void ProcessCommand(ICommand command,
                                   ICommandHandlerContext context) {}
    }
}
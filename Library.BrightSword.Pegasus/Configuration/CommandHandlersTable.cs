using BrightSword.Pegasus.Utilities;

using Microsoft.WindowsAzure.Storage;

namespace BrightSword.Pegasus.Configuration
{
    public class CommandHandlersTable : AzureTableWrapper<CommandHandler>
    {
        public CommandHandlersTable(CloudStorageAccount cloudStorageAccount,
                                    string tableName)
            : base(cloudStorageAccount,
                   tableName) {}
    }
}
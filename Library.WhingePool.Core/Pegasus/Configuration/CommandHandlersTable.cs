using Microsoft.WindowsAzure.Storage;

using WhingePool.Core.Pegasus.Utilities;

namespace WhingePool.Core.Pegasus.Configuration
{
    public class CommandHandlersTable : AzureTableWrapper<CommandHandler>
    {
        public CommandHandlersTable(CloudStorageAccount cloudStorageAccount,
                                    string tableName)
            : base(cloudStorageAccount,
                   tableName) {}
    }
}
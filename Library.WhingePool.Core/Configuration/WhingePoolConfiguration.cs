using BrightSword.Pegasus.API;

using Microsoft.WindowsAzure;

using WhingePool.Core.Properties;

namespace WhingePool.Core.Configuration
{
    public class WhingePoolConfiguration : IWhingePoolConfiguration
    {
        public WhingePoolConfiguration() {}

        public WhingePoolConfiguration(IAzureStorageConfiguration azureStorageConfiguration,
                                       ICommandHandlerConfiguration commandHandlerConfiguration,
                                       ICloudRunnerConfiguration commandQueue,
                                       IWhingePoolConfiguration whingePoolConfiguration)
        {
            StorageAccount = azureStorageConfiguration.StorageAccount;
            StorageAccountKey = azureStorageConfiguration.StorageAccountKey;
            RegisteredCommandHandlersBlobContainerName = commandHandlerConfiguration.RegisteredCommandHandlersBlobContainerName;
            RegisteredCommandHandlersTableName = commandHandlerConfiguration.RegisteredCommandHandlersTableName;
            CommandResultsTableName = commandQueue.CommandResultsTableName;
            CommandQueueName = commandQueue.CommandQueueName;
            WhingesTableName = whingePoolConfiguration.WhingesTableName;
            WhingersTableName = whingePoolConfiguration.WhingersTableName;
            WhingePoolsTableName = whingePoolConfiguration.WhingePoolsTableName;
            WhingesByWhingerTableName = whingePoolConfiguration.WhingesByWhingerTableName;
            WhingesByWhingePoolTableName = whingePoolConfiguration.WhingesByWhingePoolTableName;
        }

        public string WhingesTableName { get; set; }

        public string WhingersTableName { get; set; }

        public string WhingePoolsTableName { get; set; }

        public string WhingesByWhingerTableName { get; set; }

        public string WhingesByWhingePoolTableName { get; set; }

        public string StorageAccount { get; set; }

        public string StorageAccountKey { get; set; }

        public string RegisteredCommandHandlersTableName { get; set; }

        public string RegisteredCommandHandlersBlobContainerName { get; set; }

        public string CommandQueueName { get; set; }

        public string CommandResultsTableName { get; set; }

        public static WhingePoolConfiguration CreateFromApplicationSettings()
        {
            return new WhingePoolConfiguration
                   {
                       StorageAccount = Settings.Default.StorageAccount,
                       StorageAccountKey = Settings.Default.StorageAccountKey,
                       RegisteredCommandHandlersTableName = Settings.Default.RegisteredCommandHandlersTableName,
                       RegisteredCommandHandlersBlobContainerName = Settings.Default.RegisteredCommandHandlersBlobContainerName,
                       CommandQueueName = Settings.Default.CommandQueueName,
                       CommandResultsTableName = Settings.Default.CommandResultsTableName,
                       WhingesTableName = Settings.Default.WhingesTableName,
                       WhingersTableName = Settings.Default.WhingersTableName,
                       WhingePoolsTableName = Settings.Default.WhingePoolsTableName,
                       WhingesByWhingerTableName = Settings.Default.WhingesByWhingerTableName,
                       WhingesByWhingePoolTableName = Settings.Default.WhingesByWhingePoolTableName,
                   };
        }

        public static WhingePoolConfiguration CreateFromCloudConfiguration()
        {
            return new WhingePoolConfiguration
                   {
                       StorageAccount = CloudConfigurationManager.GetSetting("StorageAccount"),
                       StorageAccountKey = CloudConfigurationManager.GetSetting("StorageAccountKey"),
                       RegisteredCommandHandlersTableName = CloudConfigurationManager.GetSetting("RegisteredCommandHandlersTableName"),
                       RegisteredCommandHandlersBlobContainerName = CloudConfigurationManager.GetSetting("RegisteredCommandHandlersBlobContainerName"),
                       CommandQueueName = CloudConfigurationManager.GetSetting("CommandQueueName"),
                       CommandResultsTableName = CloudConfigurationManager.GetSetting("CommandResultsTableName"),
                       WhingesTableName = CloudConfigurationManager.GetSetting("WhingesTableName"),
                       WhingersTableName = CloudConfigurationManager.GetSetting("WhingersTableName"),
                       WhingePoolsTableName = CloudConfigurationManager.GetSetting("WhingePoolsTableName"),
                       WhingesByWhingerTableName = CloudConfigurationManager.GetSetting("WhingesByWhingerTableName"),
                       WhingesByWhingePoolTableName = CloudConfigurationManager.GetSetting("WhingesByWhingePoolTableName"),
                   };
        }
    }
}
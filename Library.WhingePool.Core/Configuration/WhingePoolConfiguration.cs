namespace WhingePool.Core.Configuration
{
    internal class WhingePoolConfiguration : IWhingePoolConfiguration
    {
        internal WhingePoolConfiguration(IAzureStorageConfiguration azureStorageConfiguration,
                                         IPegasusConfiguration pegasusConfiguration,
                                         IWhingePoolConfiguration whingePoolConfiguration)
        {
            StorageAccount = azureStorageConfiguration.StorageAccount;
            StorageAccountKey = azureStorageConfiguration.StorageAccountKey;
            RegisteredHandlersBlobContainerName = pegasusConfiguration.RegisteredHandlersBlobContainerName;
            RegisteredHandlersTableName = pegasusConfiguration.RegisteredHandlersTableName;
            RuntimeErrorsTableName = pegasusConfiguration.RuntimeErrorsTableName;
            ScheduledTasksQueueName = pegasusConfiguration.ScheduledTasksQueueName;
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

        public string ScheduledTasksQueueName { get; set; }

        public string RegisteredHandlersTableName { get; set; }

        public string RegisteredHandlersBlobContainerName { get; set; }

        public string RuntimeErrorsTableName { get; set; }
    }
}
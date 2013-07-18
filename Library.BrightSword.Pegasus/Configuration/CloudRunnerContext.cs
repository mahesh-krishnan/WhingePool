using BrightSword.Pegasus.API;
using BrightSword.Pegasus.Properties;

namespace BrightSword.Pegasus.Configuration
{
    public class CloudRunnerContext : CommandHandlerContext,
                                      ICloudRunnerContext
    {
        private readonly CloudRunnerCommandResultsTable _runtimeErrorsTable;

        private readonly CloudRunnerCommandsQueue _scheduledTasksQueue;

        public CloudRunnerContext()
            : this(new CloudRunnerConfiguration()) {}

        public CloudRunnerContext(ICloudRunnerConfiguration configuration)
            : base(configuration)
        {
            _scheduledTasksQueue = new CloudRunnerCommandsQueue(CloudStorageAccount,
                                                                configuration.CommandQueueName);
            _runtimeErrorsTable = new CloudRunnerCommandResultsTable(CloudStorageAccount,
                                                                     configuration.CommandResultsTableName);
        }

        public CloudRunnerCommandResultsTable CommandResultsTable
        {
            get { return _runtimeErrorsTable; }
        }

        public CloudRunnerCommandsQueue CommandsQueue
        {
            get { return _scheduledTasksQueue; }
        }

        internal class CloudRunnerConfiguration : ICloudRunnerConfiguration
        {
            public string StorageAccount
            {
                get { return Settings.Default.StorageAccount; }
            }

            public string StorageAccountKey
            {
                get { return Settings.Default.StorageAccountKey; }
            }

            public string RegisteredCommandHandlersTableName
            {
                get { return Settings.Default.RegisteredCommandHandlersTableName; }
            }

            public string RegisteredCommandHandlersBlobContainerName
            {
                get { return Settings.Default.RegisteredCommandHandlersBlobContainerName; }
            }

            public string CommandQueueName
            {
                get { return Settings.Default.CommandQueueName; }
            }

            public string CommandResultsTableName
            {
                get { return Settings.Default.CommandResultsTableName; }
            }
        }
    }
}
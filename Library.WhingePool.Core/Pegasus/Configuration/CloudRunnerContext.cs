using WhingePool.Core.Pegasus.API;

namespace WhingePool.Core.Pegasus.Configuration
{
    public class CloudRunnerContext : CommandHandlerContext,
                                      ICloudRunnerContext
    {
        private readonly CloudRunnerCommandResultsTable _runtimeErrorsTable;

        private readonly CloudRunnerCommandsQueue _scheduledTasksQueue;

        public CloudRunnerContext(ICommandQueueConfiguration configuration)
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
    }
}
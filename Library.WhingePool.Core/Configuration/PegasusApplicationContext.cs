using BrightSword.Pegasus.Entities;

using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;

namespace WhingePool.Core.Configuration
{
    public class PegasusApplicationContext : AzureApplicationContext
    {
        private readonly CloudBlobContainer _assembliesBlobContainer;

        private readonly CloudRunnerTaskHandlersTable _registeredHandlersTable;

        private readonly CloudRunnerRuntimeErrorsTable _runtimeErrorsTable;

        private readonly CloudQueue _scheduledTasksQueue;

        protected PegasusApplicationContext(IPegasusConfiguration configuration)
            : base(configuration)
        {
            PegasusConfiguration = configuration;

            _runtimeErrorsTable = new CloudRunnerRuntimeErrorsTable(CloudStorageAccount,
                                                                    configuration.RuntimeErrorsTableName);

            _registeredHandlersTable = new CloudRunnerTaskHandlersTable(CloudStorageAccount,
                                                                        configuration.RegisteredHandlersTableName);
            _scheduledTasksQueue = new CloudQueueClient(CloudStorageAccount.QueueEndpoint,
                                                        CloudStorageAccount.Credentials).GetQueueReference(configuration.ScheduledTasksQueueName);
            _scheduledTasksQueue.CreateIfNotExists();

            _assembliesBlobContainer = new CloudBlobClient(CloudStorageAccount.BlobEndpoint,
                                                           CloudStorageAccount.Credentials).GetContainerReference(configuration.RegisteredHandlersBlobContainerName);
            _assembliesBlobContainer.CreateIfNotExists();
        }

        public CloudRunnerRuntimeErrorsTable RuntimeErrorsTable
        {
            get
            {
                return _runtimeErrorsTable;
            }
        }

        public CloudQueue ScheduledTasksQueue
        {
            get
            {
                return _scheduledTasksQueue;
            }
        }

        public CloudRunnerTaskHandlersTable RegisteredHandlersTable
        {
            get
            {
                return _registeredHandlersTable;
            }
        }

        public CloudBlobContainer RegisteredHandlersBlobContainer
        {
            get
            {
                return _assembliesBlobContainer;
            }
        }

        public IPegasusConfiguration PegasusConfiguration { get; private set; }
    }
}
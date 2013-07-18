using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace WhingePool.Core.Pegasus.Utilities
{
    public abstract class AzureCommandQueue
    {
        protected AzureCommandQueue(CloudStorageAccount cloudStorageAccount,
                                    string queueName)
        {
            CloudStorageAccount = cloudStorageAccount;

            CloudQueueClient = new CloudQueueClient(CloudStorageAccount.QueueEndpoint,
                                                    CloudStorageAccount.Credentials);

            QueueName = queueName;

            Queue = CloudQueueClient.GetQueueReference(queueName);
            Queue.CreateIfNotExists();
        }

        public CloudQueue Queue { get; private set; }

        public CloudStorageAccount CloudStorageAccount { get; private set; }

        public CloudQueueClient CloudQueueClient { get; private set; }

        public string QueueName { get; private set; }
    }
}
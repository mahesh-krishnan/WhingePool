using System;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

using WhingePool.Core.Pegasus.API;
using WhingePool.Core.Pegasus.Commands;
using WhingePool.Core.Pegasus.Utilities;

namespace WhingePool.Core.Pegasus.Configuration
{
    public class CloudRunnerCommandsQueue : AzureCommandQueue
    {
        public CloudRunnerCommandsQueue(CloudStorageAccount cloudStorageAccount,
                                        string queueName)
            : base(cloudStorageAccount,
                   queueName) {}

        public void EnqueueCommand<TCommand, TCommandArgument>(TCommand command) where TCommand : Command<TCommandArgument> where TCommandArgument : class, ICommandArgument, new()
        {
            EnqueueCommand(command);
        }

        public void EnqueueCommand(Command command)
        {
            Queue.AddMessage((CloudQueueMessage) command);
        }

        public Tuple<Command, CloudQueueMessage> DequeueCommand()
        {
            var message = Queue.GetMessage();
            return new Tuple<Command, CloudQueueMessage>((Command) message,
                                                         message);
        }

        public void DeleteCommandMessage(CloudQueueMessage message)
        {
            Queue.DeleteMessage(message);
        }
    }
}
using System;

using BrightSword.Pegasus.API;
using BrightSword.Pegasus.Commands;
using BrightSword.Pegasus.Utilities;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace BrightSword.Pegasus.Configuration
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
            if (message == null)
            {
                return null;
            }

            return new Tuple<Command, CloudQueueMessage>((Command) message,
                                                         message);
        }

        public void DeleteCommandMessage(CloudQueueMessage message)
        {
            Queue.DeleteMessage(message);
        }
    }
}
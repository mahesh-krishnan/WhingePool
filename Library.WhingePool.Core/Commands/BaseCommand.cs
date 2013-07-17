using System;

using Microsoft.WindowsAzure.Storage.Queue;

namespace WhingePool.Core.Commands
{
    public class BaseCommand<T> : ICommand<T>
        where T : ICommandArgument
    {
        protected BaseCommand(T argument)
        {
            CommandArgument = argument;
            CommandId = Guid.NewGuid();
        }

        public T CommandArgument { get; private set; }

        public Guid CommandId { get; private set; }

        public static implicit operator CloudQueueMessage(BaseCommand<T> _this)
        {
            return new CloudQueueMessage(_this.CommandArgument.ToJson());
        }
    }
}
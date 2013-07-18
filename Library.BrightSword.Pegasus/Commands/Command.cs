using System;

using BrightSword.Pegasus.API;

using Microsoft.WindowsAzure.Storage.Queue;

using Newtonsoft.Json;

namespace BrightSword.Pegasus.Commands
{
    public class Command : ICommand
    {
        protected Command(string commandArgumentTypeName,
                          string serializedCommandArgument,
                          string commandName = null)
        {
            CommandId = Guid.NewGuid();
            CommandName = commandName ?? GetType()
                                             .FullName;
            CommandArgumentTypeName = commandArgumentTypeName;
            SerializedCommandArgument = serializedCommandArgument;
        }

        public Guid CommandId { get; private set; }

        public virtual string CommandName { get; private set; }

        public string CommandArgumentTypeName { get; private set; }

        public string SerializedCommandArgument { get; private set; }

        public static explicit operator CloudQueueMessage(Command _this)
        {
            return new CloudQueueMessage(JsonConvert.SerializeObject(_this));
        }

        public static explicit operator Command(CloudQueueMessage _this)
        {
            return JsonConvert.DeserializeObject<Command>(_this.AsString);
        }
    }

    public abstract class Command<T> : Command,
                                       ICommand<T>
        where T : class, ICommandArgument, new()
    {
        protected Command(T argument)
            : base(typeof (T).FullName,
                   JsonConvert.SerializeObject(argument))
        {
            CommandArgument = argument;
        }

        protected Command(CloudQueueMessage message)
            : base(typeof (T).FullName,
                   JsonConvert.SerializeObject(message.AsString))
        {
            CommandArgument = JsonConvert.DeserializeObject<T>(message.AsString);
        }

        public T CommandArgument { get; private set; }

        public static TCommand CreateFromCloudQueueMessage<TCommand, TCommandArgument>(CloudQueueMessage message) where TCommand : Command<TCommandArgument>, new() where TCommandArgument : class, ICommandArgument, new()
        {
            var command = new TCommand
                          {
                              CommandArgument = JsonConvert.DeserializeObject<TCommandArgument>(message.AsString)
                          };

            return command;
        }

        public static explicit operator CloudQueueMessage(Command<T> _this)
        {
            return new CloudQueueMessage(JsonConvert.SerializeObject(_this));
        }
    }
}
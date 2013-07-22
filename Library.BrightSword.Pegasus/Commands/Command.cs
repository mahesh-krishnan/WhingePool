using System;
using System.Globalization;

using BrightSword.Pegasus.API;

using Microsoft.WindowsAzure.Storage.Queue;

using Newtonsoft.Json;

namespace BrightSword.Pegasus.Commands
{
    public class Command : ICommand
    {
        public Command() {}

        protected Command(string commandArgumentTypeName,
                          string serializedCommandArgument,
                          string commandName = null)
        {
            CommandId = DateTime.UtcNow.Ticks.ToString(CultureInfo.InvariantCulture);
            CommandName = commandName ?? GetType()
                                             .FullName;
            CommandArgumentTypeName = commandArgumentTypeName;
            SerializedCommandArgument = serializedCommandArgument;
        }

        public string CommandId { get; set; }

        public string CommandName { get; set; }

        public string CommandArgumentTypeName { get; set; }

        public string SerializedCommandArgument { get; set; }

        public static explicit operator CloudQueueMessage(Command _this)
        {
            return new CloudQueueMessage(JsonConvert.SerializeObject(_this));
        }

        public static explicit operator Command(CloudQueueMessage _this)
        {
            return _this == null
                       ? null
                       : JsonConvert.DeserializeObject<Command>(_this.AsString);
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
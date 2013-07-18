using System;

using BrightSword.Pegasus.API;

using Microsoft.WindowsAzure.Storage.Table;

namespace BrightSword.Pegasus.Configuration
{
    public class CloudRunnerCommandResult : TableEntity
    {
        public CloudRunnerCommandResult()
        {
            RowKey = Guid.NewGuid()
                         .ToString("D");
            Timestamp = DateTime.UtcNow;
            PartitionKey = "Error";
        }

        public CloudRunnerCommandResult(ICommand command,
                                        CompletionStatus completionStatus)
            : this()
        {
            InternalCompletionStatus = completionStatus;

            CommandName = command.CommandName;
            CommandArgumentType = command.CommandArgumentTypeName;
            SerializedCommandArgument = command.SerializedCommandArgument;
            CommandId = command.CommandId;
            PartitionKey = command.CommandName;
        }

        internal CompletionStatus InternalCompletionStatus { get; set; }

        public Guid CommandId { get; set; }

        public string CommandName { get; set; }

        public string SerializedCommandArgument { get; set; }

        public string CommandArgumentType { get; set; }

        public string CompletionStatus
        {
            get { return InternalCompletionStatus.ToString(); }
            set
            {
                InternalCompletionStatus = (CompletionStatus) Enum.Parse(typeof (CompletionStatus),
                                                                         value);
            }
        }
    }
}
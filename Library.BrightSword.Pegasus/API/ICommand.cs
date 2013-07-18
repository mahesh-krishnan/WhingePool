using System;

namespace BrightSword.Pegasus.API
{
    public interface ICommand
    {
        Guid CommandId { get; }

        string CommandName { get; }

        string CommandArgumentTypeName { get; }

        string SerializedCommandArgument { get; }
    }

    public interface ICommand<out TCommandArgument> : ICommand
    {
        TCommandArgument CommandArgument { get; }
    }
}
using System;

namespace WhingePool.Core.Commands
{
    public interface ICommand<out T>
    {
        T CommandArgument { get; }

        Guid CommandId { get; }
    }
}
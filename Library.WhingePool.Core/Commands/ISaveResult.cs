using System;

namespace WhingePool.Core.Commands
{
    public interface ISaveResult
    {
        Guid CommandId { get; }
    }
}
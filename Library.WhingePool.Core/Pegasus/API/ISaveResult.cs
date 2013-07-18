using System;

namespace WhingePool.Core.Pegasus.API
{
    public interface ISaveResult
    {
        Guid CommandId { get; }
    }
}
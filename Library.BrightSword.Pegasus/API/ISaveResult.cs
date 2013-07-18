using System;

namespace BrightSword.Pegasus.API
{
    public interface ISaveResult
    {
        Guid CommandId { get; }
    }
}
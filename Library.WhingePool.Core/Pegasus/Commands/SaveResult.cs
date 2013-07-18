using System;

using WhingePool.Core.Pegasus.API;

namespace WhingePool.Core.Pegasus.Commands
{
    public class SaveResult : ISaveResult
    {
        public SaveResult(Guid commandId)
        {
            CommandId = commandId;
        }

        public Guid CommandId { get; set; }
    }
}
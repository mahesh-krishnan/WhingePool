using System;

namespace WhingePool.Core.Commands
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
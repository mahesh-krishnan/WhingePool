using System;

using BrightSword.Pegasus.API;

namespace BrightSword.Pegasus.Commands
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
using BrightSword.Pegasus.API;

namespace BrightSword.Pegasus.Commands
{
    public class SaveResult : ISaveResult
    {
        public SaveResult(string commandId)
        {
            CommandId = commandId;
        }

        public string CommandId { get; set; }
    }
}
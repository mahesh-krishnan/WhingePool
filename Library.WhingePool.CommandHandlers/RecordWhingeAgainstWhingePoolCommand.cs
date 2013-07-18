using BrightSword.Pegasus.Commands;

using WhingePool.Core.Entities;

namespace Library.WhingePool.CommandHandlers
{
    public class RecordWhingeAgainstWhingePoolCommand : Command<WhingeEntity>
    {
        public RecordWhingeAgainstWhingePoolCommand(WhingeEntity whinge)
            : base(whinge) {}
    }
}
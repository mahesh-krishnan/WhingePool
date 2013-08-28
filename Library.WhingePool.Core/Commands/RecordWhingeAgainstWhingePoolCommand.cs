using BrightSword.Pegasus.Commands;

using WhingePool.Core.Entities;

namespace WhingePool.Core.Commands
{
    public class RecordWhingeAgainstWhingePoolCommand : Command<WhingeEntity>
    {
        public RecordWhingeAgainstWhingePoolCommand(WhingeEntity whinge)
            : base(whinge) {}
    }
}
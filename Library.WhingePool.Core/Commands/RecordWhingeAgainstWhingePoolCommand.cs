using BrightSword.Pegasus.Commands;
using BrightSword.Pegasus.Commands.Core;
using WhingePool.Core.Entities;

namespace WhingePool.Core.Commands
{
    public class RecordWhingeAgainstWhingePoolCommand : Command<WhingeEntity>
    {
        public RecordWhingeAgainstWhingePoolCommand(WhingeEntity whinge)
            : base(whinge) {}
    }
}
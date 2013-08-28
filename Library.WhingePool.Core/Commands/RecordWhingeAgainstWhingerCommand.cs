using BrightSword.Pegasus.Commands;
using BrightSword.Pegasus.Commands.Core;
using WhingePool.Core.Entities;

namespace WhingePool.Core.Commands
{
    public class RecordWhingeAgainstWhingerCommand : Command<WhingeEntity>
    {
        public RecordWhingeAgainstWhingerCommand(WhingeEntity whinge)
            : base(whinge) {}
    }
}
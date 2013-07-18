using BrightSword.Pegasus.Commands;

using WhingePool.Core.Entities;

namespace Library.WhingePool.CommandHandlers
{
    public class RecordWhingeAgainstWhingerCommand : Command<WhingeEntity>
    {
        public RecordWhingeAgainstWhingerCommand(WhingeEntity whinge)
            : base(whinge) {}
    }
}
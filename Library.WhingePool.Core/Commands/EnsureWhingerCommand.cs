using BrightSword.Pegasus.Commands;
using BrightSword.Pegasus.Commands.Core;
using WhingePool.Core.Entities;

namespace WhingePool.Core.Commands
{
    public class EnsureWhingerCommand : Command<WhingerEntity>
    {
        public EnsureWhingerCommand(WhingerEntity whinger)
            : base(whinger) {}
    }
}
using WhingePool.Core.Entities;
using WhingePool.Core.Pegasus.Commands;

namespace WhingePool.Core.Commands
{
    public class EnsureWhingerCommand : Command<WhingerEntity>
    {
        public EnsureWhingerCommand(WhingerEntity whinger)
            : base(whinger) {}
    }
}
using BrightSword.Pegasus.Commands;

using WhingePool.Core.Entities;

namespace WhingePool.Core.Commands
{
    public class EnsureWhingePoolCommand : Command<WhingePoolEntity>
    {
        public EnsureWhingePoolCommand(WhingePoolEntity whingePool)
            : base(whingePool) {}
    }
}
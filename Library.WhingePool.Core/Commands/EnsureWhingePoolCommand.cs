using WhingePool.Core.Entities;
using WhingePool.Core.Pegasus.Commands;

namespace WhingePool.Core.Commands
{
    public class EnsureWhingePoolCommand : Command<WhingePoolEntity>
    {
        public EnsureWhingePoolCommand(WhingePoolEntity whingePool)
            : base(whingePool) {}
    }
}
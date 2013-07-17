using WhingePool.Core.API;

namespace WhingePool.Core.Commands
{
    public class EnsureWhingePoolCommand : BaseCommand<IWhingePool>
    {
        public EnsureWhingePoolCommand(IWhingePool whingePool)
            : base(whingePool) { }
    }
}
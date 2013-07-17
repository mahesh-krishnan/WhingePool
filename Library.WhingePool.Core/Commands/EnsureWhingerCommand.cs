using WhingePool.Core.API;

namespace WhingePool.Core.Commands
{
    public class EnsureWhingerCommand : BaseCommand<IWhinger>
    {
        public EnsureWhingerCommand(IWhinger whinger)
            : base(whinger) { }
    }
}
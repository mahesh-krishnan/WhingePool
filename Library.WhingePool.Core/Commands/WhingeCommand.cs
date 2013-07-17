using WhingePool.Core.API;

namespace WhingePool.Core.Commands
{
    public class WhingeCommand : BaseCommand<IWhinge>
    {
        public WhingeCommand(IWhinge whinge)
            : base(whinge) {}
    }
}
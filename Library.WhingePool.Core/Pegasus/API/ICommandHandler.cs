using WhingePool.Core.Configuration;

namespace WhingePool.Core.Pegasus.API
{
    public interface ICommandHandler
    {
        void ProcessCommand(ICommand command,
                            WhingePoolApplicationContext context);
    }
}
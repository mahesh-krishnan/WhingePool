using WhingePool.Core.Commands;

namespace WhingePool.Core.API
{
    public interface IWhinge : ICommandArgument
    {
        string WhingeText { get; set; }
    }
}
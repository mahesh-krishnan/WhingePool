using WhingePool.Core.Commands;

namespace WhingePool.Core.API
{
    public interface IWhingePool : ICommandArgument
    {
        string Name { get; set; }
    }
}
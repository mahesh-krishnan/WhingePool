using WhingePool.Core.Commands;

namespace WhingePool.Core.API
{
    public interface IWhinger : ICommandArgument
    {
        string Name { get; set; }
    }
}
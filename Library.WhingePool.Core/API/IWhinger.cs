using BrightSword.Pegasus.API;

namespace WhingePool.Core.API
{
    public interface IWhinger : ICommandArgument
    {
        string Name { get; set; }
    }
}
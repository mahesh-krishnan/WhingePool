using WhingePool.Core.Commands;

namespace WhingePool.Core.API
{
    public interface ICommandService<T>
        where T : ICommandArgument
    {
        ISaveResult Save(T instance);
    }
}
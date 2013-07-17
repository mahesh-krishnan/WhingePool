using WhingePool.Core.Commands;

namespace WhingePool.Core.API
{
    public interface IWhingeService
    {
        ISaveResult Save(IWhinge whinge);
    }
}
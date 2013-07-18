using WhingePool.Core.Entities;
using WhingePool.Core.Pegasus.API;

namespace WhingePool.Core.API
{
    public interface IWhingerService : ICommandService<WhingerEntity> { }
}
using BrightSword.Pegasus.API;

using WhingePool.Core.Entities;

namespace WhingePool.Core.API
{
    public interface IWhingeService : ICommandService<WhingeEntity> {}
}
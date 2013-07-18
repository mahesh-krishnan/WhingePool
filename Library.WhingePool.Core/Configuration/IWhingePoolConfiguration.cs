using WhingePool.Core.Pegasus.API;

namespace WhingePool.Core.Configuration
{
    public interface IWhingePoolConfiguration : ICommandQueueConfiguration
    {
        string WhingesTableName { get; }

        string WhingersTableName { get; }

        string WhingePoolsTableName { get; }

        string WhingesByWhingerTableName { get; }

        string WhingesByWhingePoolTableName { get; }
    }
}
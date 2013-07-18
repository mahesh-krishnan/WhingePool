using BrightSword.Pegasus.API;

namespace WhingePool.Core.Configuration
{
    public interface IWhingePoolConfiguration : ICloudRunnerConfiguration
    {
        string WhingesTableName { get; }

        string WhingersTableName { get; }

        string WhingePoolsTableName { get; }

        string WhingesByWhingerTableName { get; }

        string WhingesByWhingePoolTableName { get; }
    }
}
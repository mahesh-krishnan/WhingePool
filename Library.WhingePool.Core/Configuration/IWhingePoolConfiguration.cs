namespace WhingePool.Core.Configuration
{
    public interface IWhingePoolConfiguration : IPegasusConfiguration
    {
        string WhingesTableName { get; set; }

        string WhingersTableName { get; set; }

        string WhingePoolsTableName { get; set; }

        string WhingesByWhingerTableName { get; set; }

        string WhingesByWhingePoolTableName { get; set; }
    }
}
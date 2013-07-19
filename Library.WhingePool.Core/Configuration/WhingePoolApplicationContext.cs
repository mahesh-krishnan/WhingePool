using BrightSword.Pegasus.Configuration;

using WhingePool.Core.Tables;

namespace WhingePool.Core.Configuration
{
    public class WhingePoolApplicationContext : CloudRunnerContext
    {
        private readonly WhingePoolsTable _whingePoolsTable;

        private readonly WhingersTable _whingersTable;

        private readonly WhingesByWhingePoolTable _whingesByWhingePoolTable;

        private readonly WhingesByWhingerTable _whingesByWhingerTable;

        public WhingePoolApplicationContext(IWhingePoolConfiguration configuration)
            : base(configuration)
        {
            _whingersTable = new WhingersTable(CloudStorageAccount,
                                               configuration.WhingersTableName);

            _whingePoolsTable = new WhingePoolsTable(CloudStorageAccount,
                                                     configuration.WhingePoolsTableName);

            _whingesByWhingerTable = new WhingesByWhingerTable(CloudStorageAccount,
                                                               configuration.WhingesByWhingerTableName);

            _whingesByWhingePoolTable = new WhingesByWhingePoolTable(CloudStorageAccount,
                                                                     configuration.WhingesByWhingePoolTableName);
        }

        public WhingersTable WhingersTable
        {
            get { return _whingersTable; }
        }

        public WhingePoolsTable WhingePoolsTable
        {
            get { return _whingePoolsTable; }
        }

        public WhingesByWhingerTable WhingesByWhingerTable
        {
            get { return _whingesByWhingerTable; }
        }

        public WhingesByWhingePoolTable WhingesByWhingePoolTable
        {
            get { return _whingesByWhingePoolTable; }
        }

        public static WhingePoolApplicationContext CreateFromApplicationSettings()
        {
            return new WhingePoolApplicationContext(WhingePoolConfiguration.CreateFromCloudConfiguration());
        }

        public static WhingePoolApplicationContext CreateFromCloudConfiguration()
        {
            return new WhingePoolApplicationContext(WhingePoolConfiguration.CreateFromCloudConfiguration());
        }
    }
}
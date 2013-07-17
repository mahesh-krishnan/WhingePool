using WhingePool.Core.Tables;

namespace WhingePool.Core.Configuration
{
    public class WhingePoolApplicationContext : PegasusApplicationContext
    {
        private readonly WhingePoolsTable _whingePoolsTable;

        private readonly WhingersTable _whingersTable;

        private readonly WhingesByWhingePoolTable _whingesByWhingePoolTable;

        private readonly WhingesByWhingerTable _whingesByWhingerTable;

        private readonly WhingesTable _whingesTable;

        public WhingePoolApplicationContext(IWhingePoolConfiguration configuration)
            : base(configuration)
        {
            WhingePoolConfiguration = configuration;

            _whingesTable = new WhingesTable(CloudStorageAccount,
                                             configuration.WhingesTableName);

            _whingersTable = new WhingersTable(CloudStorageAccount,
                                               configuration.WhingersTableName);

            _whingePoolsTable = new WhingePoolsTable(CloudStorageAccount,
                                                     configuration.WhingePoolsTableName);

            _whingesByWhingerTable = new WhingesByWhingerTable(CloudStorageAccount,
                                                               configuration.WhingesByWhingerTableName);

            _whingesByWhingePoolTable = new WhingesByWhingePoolTable(CloudStorageAccount,
                                                                     configuration.WhingesByWhingePoolTableName);
        }

        public WhingesTable WhingesTable
        {
            get
            {
                return _whingesTable;
            }
        }

        public WhingersTable WhingersTable
        {
            get
            {
                return _whingersTable;
            }
        }

        public WhingePoolsTable WhingePoolsTable
        {
            get
            {
                return _whingePoolsTable;
            }
        }

        public WhingesByWhingerTable WhingesByWhingerTable
        {
            get
            {
                return _whingesByWhingerTable;
            }
        }

        public WhingesByWhingePoolTable WhingesByWhingePoolTable
        {
            get
            {
                return _whingesByWhingePoolTable;
            }
        }

        public IWhingePoolConfiguration WhingePoolConfiguration { get; private set; }
    }
}
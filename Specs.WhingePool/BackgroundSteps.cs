using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

using WhingePool.Core.Configuration;
using WhingePool.Core.Entities;
using WhingePool.Core.Pegasus.API;

namespace Specs.WhingePool
{
    [Binding]
    public class BackgroundSteps
    {
        private IAzureStorageConfiguration _azureStorageConfiguration;

        private ICommandHandlerConfiguration _commandHandlerConfiguration;

        private ICommandQueueConfiguration _commandQueue;

        private WhingePoolApplicationContext _whingePoolApplicationContext;
        private IWhingePoolConfiguration _whingePoolConfiguration;

        public WhingePoolApplicationContext WhingePoolApplicationContext
        {
            get { return _whingePoolApplicationContext; }
        }

        [Given(@"An Azure Storage Configuration of")]
        public void GivenAnAzureStorageConfigurationOf(Table table)
        {
            _azureStorageConfiguration = table.CreateInstance<WhingePoolConfiguration>();
        }

        [Given(@"A Dynamic Command Handler Configuration of")]
        public void GivenADynamicCommandHandlerConfigurationOf(Table table)
        {
            _commandHandlerConfiguration = table.CreateInstance<WhingePoolConfiguration>();
        }

        [Given(@"A Command Queue Configuration of")]
        public void GivenACommandQueueConfigurationOf(Table table)
        {
            _commandQueue = table.CreateInstance<WhingePoolConfiguration>();
        }

        [Given(@"A WhingePool Configuration of")]
        public void GivenAWhingePoolConfigurationOf(Table table)
        {
            _whingePoolConfiguration = table.CreateInstance<WhingePoolConfiguration>();
        }

        [Given(@"An ApplicationContext")]
        public void GivenAnApplicationContext()
        {
            var configuration = new WhingePoolConfiguration(_azureStorageConfiguration,
                                                            _commandHandlerConfiguration,
                                                            _commandQueue,
                                                            _whingePoolConfiguration);

            ScenarioContext.Current["ApplicationContext"] = new WhingePoolApplicationContext(configuration);

            _whingePoolApplicationContext = ScenarioContext.Current.Get<WhingePoolApplicationContext>("ApplicationContext");
        }

        [Given(@"An Empty WhingersTable")]
        public void GivenAnEmptyWhingersTable()
        {
            WhingePoolApplicationContext.WhingersTable.DeleteInstances();
        }

        [Given(@"A Default Set Of Whingers")]
        public void GivenADefaultSetOfWhingers(Table table)
        {
            foreach (var item in table.CreateSet<WhingerEntity>())
            {
                WhingePoolApplicationContext.WhingersTable.EnsureInstance(item);
            }
        }

        [Given(@"An Empty WhingePoolsTable")]
        public void GivenAnEmptyWhingePoolsTable()
        {
            WhingePoolApplicationContext.WhingePoolsTable.DeleteInstances();
        }

        [Given(@"A Default Set Of WhingePools")]
        public void GivenADefaultSetOfWhingePools(Table table)
        {
            foreach (var item in table.CreateSet<WhingePoolEntity>())
            {
                WhingePoolApplicationContext.WhingePoolsTable.EnsureInstance(item);
            }
        }

        [Given(@"The Current Whinger")]
        public void GivenTheCurrentWhinger(Table table)
        {
            ScenarioContext.Current["CurrentWhinger"] = WhingePoolApplicationContext.WhingersTable.RetrieveInstance(table.CreateInstance<WhingerEntity>());
        }
    }
}
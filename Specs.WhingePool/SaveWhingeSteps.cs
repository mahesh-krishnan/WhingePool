using System;

using NUnit.Framework;

using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

using WhingePool.Core;
using WhingePool.Core.Configuration;
using WhingePool.Core.Entities;

namespace Specs.WhingePool
{
    [Binding]
    public class SaveWhingeSteps
    {
        public SaveWhingeSteps()
        {
            ApplicationContext = ScenarioContext.Current.Get<WhingePoolApplicationContext>("ApplicationContext");
            Assert.IsNotNull(ApplicationContext);

            WhingeService = new WhingeService(ApplicationContext);
            WhingePoolService = new WhingePoolService(ApplicationContext);
        }

        public WhingePoolService WhingePoolService { get; private set; }

        public WhingeService WhingeService { get; private set; }

        public WhingePoolApplicationContext ApplicationContext { get; private set; }

        public Exception ThrownException { get; private set; }

        [When(@"A whinge is saved")]
        public void WhenAWhingeIsSaved(Table table)
        {
            try
            {
                var whinge = table.CreateInstance<WhingeEntity>();
                WhingeService.Save(whinge);                
            }
            catch (Exception exception)
            {
                ThrownException = exception;
            }
        }

        [Then(@"An instance of ""(.*)"" exception should be thrown")]
        public void ThenAnInstanceOfExceptionShouldBeThrown(string exceptionTypeName)
        {
            Assert.IsNotNull(ThrownException);
            Assert.AreEqual(exceptionTypeName,
                            ThrownException.GetType()
                                           .Name);
        }

        [Then(@"The save should succeed")]
        public void ThenTheSaveShouldSucceed()
        {
            Assert.IsNull(ThrownException);
        }

        [Then(@"A WhingePool should be created")]
        public void ThenAWhingePoolShouldBeCreated(Table table)
        {
            var whingePool = table.CreateInstance<WhingePoolEntity>();
            WhingePoolService.Save(whingePool);
        }
    }
}
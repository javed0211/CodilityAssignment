using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace DemoShop.Steps
{
    [Binding]
    public sealed class DemoShopSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public DemoShopSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        

        

        [Then(@"I am able to verify the item in my cart")]
        public void ThenIAmAbleToVerifyTheItemInMyCart()
        {
            ScenarioContext.Current.Pending();
        }

    }
}

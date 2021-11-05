using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace DemoShop.Steps
{
    [Binding]
    public sealed class CategoriesPageSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public CategoriesPageSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I add '(.*)' different products to my wish list")]
        public void GivenIAddDifferentProductsToMyWishList(int noOfItems)
        {
            BaseSteps.DemoShopDriver.categories.SelectCategory("Clothing");
            for (int i = 0; i < noOfItems; i++)
            {
                BaseSteps.DemoShopDriver.clothing.SelectWishList();
            }
        }

    }
}

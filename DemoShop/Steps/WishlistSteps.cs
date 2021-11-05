using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace DemoShop.Steps
{
    [Binding]
    public sealed class WishlistSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public WishlistSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [When(@"I view my wishlist table")]
        public void WhenIViewMyWishlistTable()
        {
            BaseSteps.DemoShopDriver.wishList.GotoWishListPage();
        }

        [Then(@"I find total '(.*)' selected items in my wishlist")]
        public void ThenIFindTotalSelectedItemsInMyWishlist(int items)
        {
            int itemsFromWishlist = BaseSteps.DemoShopDriver.wishList.GetWishlistItems();
            Assert.AreEqual(items, itemsFromWishlist, "Wishlist product count doesnt match");
        }

        [When(@"I search for lowest price product")]
        public void WhenISearchForLowestPriceProduct()
        {
            var lowestProduct = BaseSteps.DemoShopDriver.wishList.GetLowestPriceProduct();
            _scenarioContext["lowestProduct"] = lowestProduct.Text;

        }

        [When(@"I am able to add the lowest price to my cart")]
        public void WhenIAmAbleToAddTheLowestPriceToMyCart()
        {
            var lowestPriceProduct = (string)(_scenarioContext["lowestProduct"]);
            BaseSteps.DemoShopDriver.wishList.AddProductInCart(lowestPriceProduct);
        }
    }
}

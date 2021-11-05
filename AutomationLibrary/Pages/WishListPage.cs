using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationLibrary
{
  public  class WishListPage
    {
        private readonly WebClient _client;
        public WishListPage(WebClient client) : base()
        {
            _client = client;
        }

        public T GetElement<T>(WebClient client)
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { client });
        }

        public void GotoWishListPage()
        {
            _client.SelectWishlistPage();
        }

        public int GetWishlistItems()
        {
            return _client.GetWishlistItems();
        }

        public IWebElement GetLowestPriceProduct()
        {
            return _client.GetLowestPriceProduct();
        }
        public void AddProductInCart(string productName)
        {
            _client.AddProductToCart(productName);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationLibrary
{
    public class DemoShopDriver : WebClient
    {
        internal WebClient _client;

        public DemoShopDriver(WebClient client) : base(client.Driver)
        {
            _client = client;
        }

        public CategoriesPage categories => this.GetElement<CategoriesPage>(_client);
        public ClothingPage clothing => this.GetElement<ClothingPage>(_client);
        public WishListPage wishList => this.GetElement<WishListPage>(_client);
        public CartPage Cart => this.GetElement<CartPage>(_client);

        public T GetElement<T>(WebClient client)
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { client });
        }
    }
}

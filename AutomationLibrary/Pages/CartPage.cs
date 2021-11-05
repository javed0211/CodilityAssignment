using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationLibrary
{
   public class CartPage
    {
        private readonly WebClient _client;
        public CartPage(WebClient client) : base()
        {
            _client = client;
        }

        public T GetElement<T>(WebClient client)
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { client });
        }

        public bool VerifyItemInCart(string product)
        {
            return _client.VerifyItemInCart(product);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationLibrary
{
   public class ClothingPage
    {
        private readonly WebClient _client;
        public ClothingPage(WebClient client) : base()
        {
            _client = client;
        }

        public T GetElement<T>(WebClient client)
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { client });
        }

        public void SelectWishList()
        {
            _client.MarkAsWishList();
        }
    }
}

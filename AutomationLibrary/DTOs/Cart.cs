using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationLibrary
{
    public class Cart
    {
        public static Dictionary<string, string> Xpath = new Dictionary<string, string>()
        {

            { "btnWishlist","//div[@class='header-wishlist']/a[@title='Wishlist']" },

        };
    }
}

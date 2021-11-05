using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationLibrary
{
    public class Elements
    {

        public static Dictionary<string, string> Xpath = new Dictionary<string, string>()
        {
            //Categories
            { "lblCategories","//ul[contains(@class,'envo-categories')]" },
            { "clothing", "//li/a[@title='Clothing']" },
            {"menClothing", "//li/a[contains(@title,\"Men's Clothing\")]"},
            {"womenClothing", "//li/a[contains(@title,\"Women's Clothing\")]"},
            {"watches", "//li/a[contains(@title,\"Women's Clothing\")]"},
            {"lstCategories", "//ul[contains(@class,'envo-categories')]//li/a"}
        }
    }
}

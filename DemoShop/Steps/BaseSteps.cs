using AutomationLibrary;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace DemoShop
{
   public class BaseSteps
    {
        public static DemoShopDriver DemoShopDriver;
        private readonly IWebDriver _driver;
        public BaseSteps()
        {
            
        }
        public void InitDemoShopDriver()
        {
            var client = new WebClient(_driver);
            DemoShopDriver = new DemoShopDriver(client);
        }
    }
}

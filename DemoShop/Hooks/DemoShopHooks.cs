using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace DemoShop.Hooks
{
    [Binding]
    public sealed class DemoShopHooks
    {

        [BeforeScenario(Order =1)]
        public void CreateDriverInstance()
        {
            BaseSteps baseSteps = new BaseSteps();
            baseSteps.InitDemoShopDriver();
        }

        [BeforeScenario(Order = 2)]
        public void GotoDemoShopURL()
        {
            BaseSteps.DemoShopDriver.Driver.Url = GetURL();
        }

        public String GetURL()
        {
            dynamic type = JsonConvert.DeserializeObject(File.ReadAllText(@"C:\Users\apple\source\repos\DemoShop\AutomationLibrary\Data\PreSetup.json"));
            return type.URL;
        }

        [AfterScenario]
        public void DisposeDrivers()
        {
            BaseSteps.DemoShopDriver.Driver.Quit();
        }
    }
}

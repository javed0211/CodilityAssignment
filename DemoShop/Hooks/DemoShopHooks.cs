using Newtonsoft.Json;
using OpenQA.Selenium;
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
        public static Allure.Commons.AllureLifecycle allureInstance = Allure.Commons.AllureLifecycle.Instance;
        private static ScenarioContext _scenarioContext;

        public DemoShopHooks(ScenarioContext sc)
        {
            _scenarioContext = sc;
        }

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
        
        [AfterStep]
        public void TakeScreenShot()
        {
            Screenshot screenshot = ((ITakesScreenshot)BaseSteps.DemoShopDriver.Driver).GetScreenshot();
            string title = _scenarioContext.StepContext.StepInfo.Text;
            var filepath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            var imagePath = Path.Combine(filepath, "Screenshots");
            screenshot.SaveAsFile(title, ScreenshotImageFormat.Jpeg);
            allureInstance.AddAttachment(imagePath + "\\" + title);
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

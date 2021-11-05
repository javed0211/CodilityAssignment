using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AutomationLibrary
{
    public class WebClient
    {
        private IWebDriver driver;

        public WebClient(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebDriver Driver
        {
            get
            {
                if (this.driver == null)
                    this.driver = CreateWebDriver();
                return driver;
            }
        }

        public static string GetBrowserType()
        {
            dynamic type = JsonConvert.DeserializeObject(File.ReadAllText(@"C:\Users\apple\source\repos\DemoShop\AutomationLibrary\Data\PreSetup.json"));
            return type.browser;
        }
        public static IWebDriver CreateWebDriver()
        {
            IWebDriver driver;

            switch (GetBrowserType().ToString())
            {
                case "Chrome":
                    var chromeService = ChromeDriverService.CreateDefaultService(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    driver = new ChromeDriver(chromeService, ToChrome(), CommandTimeout);
                    break;
                case "IE":
                    var ieService = InternetExplorerDriverService.CreateDefaultService(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    driver = new InternetExplorerDriver(ieService, ToInternetExplorer(), CommandTimeout);
                    break;
                case "Firefox":
                    var ffService = FirefoxDriverService.CreateDefaultService(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    driver = new FirefoxDriver(ffService, ToFireFox());
                    driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 5);
                    break;
                case "Edge":
                    var edgeService = EdgeDriverService.CreateDefaultService(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    driver = new EdgeDriver(edgeService, ToEdge(), CommandTimeout);
                    break;
                default:
                    throw new InvalidOperationException(
                        $"The browser type '{GetBrowserType()}' is not recognized.");
            }

            driver.Manage().Timeouts().PageLoad = PageLoadTimeout;

            return driver;
        }


        public static string DriversPath
        {
            get
            {
                return DriversPath;
            }
            set
            {
                DriversPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }
        }

        public static TimeSpan CommandTimeout { get; set; } = TimeSpan.FromMinutes(20);
        public static TimeSpan PageLoadTimeout { get; set; } = new TimeSpan(0, 3, 0);
        public static ChromeOptions ToChrome()
        {
            var options = new ChromeOptions();
            options.AddArguments(
             "--disable-extensions",
             "--disable-features",
             "--disable-popup-blocking",
             "--disable-settings-window",
             "--disable-impl-side-painting",
             "--enable-javascript",
             "--start-maximized",
             "--no-sandbox",
             //"--headless",
             "--disable-gpu",
             "--dump-dom",
             "test-type=browser",
             "disable-infobars",
             "test-type",
             "--enable-automation");
            options.AcceptInsecureCertificates = true;
            options.PageLoadStrategy = PageLoadStrategy.Normal;
            return options;
        }

        public static InternetExplorerOptions ToInternetExplorer()
        {
            var options = new InternetExplorerOptions()
            {
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                EnsureCleanSession = true,
                ForceCreateProcessApi = false,
                //page = InternetExplorerPageLoadStrategy.Eager,
                IgnoreZoomLevel = true,
                EnablePersistentHover = true,
            };
            return options;
        }

        public static FirefoxOptions ToFireFox()
        {
            var options = new FirefoxOptions()
            {
                UseLegacyImplementation = false
            };

            if (!string.IsNullOrEmpty(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)))
            {
                options.SetPreference("browser.download.folderList", 2);
                options.SetPreference("browser.download.dir", Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                options.SetPreference("browser.helperApps.neverAsk.saveToDisk", "text/csv,application/java-archive, application/x-msexcel,application/excel,application/vnd.openxmlformats-officedocument.wordprocessingml.document,application/x-excel,application/vnd.ms-excel,image/png,image/jpeg,text/html,text/plain,application/msword,application/xml,application/vnd.microsoft.portable-executable");
            }

            return options;
        }

        public static EdgeOptions ToEdge()
        {
            var options = new EdgeOptions()
            {
                PageLoadStrategy = PageLoadStrategy.Normal,
            };
            return options;
        }

        internal void SelectCategory(string name)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(driver.FindElement(By.XPath(Categories.Xpath["lblCategories"]))).Perform();
            IEnumerable<IWebElement> categories = driver.FindElements(By.XPath(Categories.Xpath["lstCategories"]));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            categories.Where(x => x.Text == name).FirstOrDefault().Click();
        }

        internal void MarkAsWishList()
        {
            IWebElement wishList = driver.FindElement(By.XPath(Clothing.Xpath["btnWishlist"]));
            wishList.Click();
        }

        internal void SelectWishlistPage()
        {
            driver.FindElement(By.XPath(Wishlist.Xpath["btnWishlist"])).Click();
        }

        internal int GetWishlistItems()
        {
            return driver.FindElements(By.XPath("//table[contains(@class,'wishlist_table')]//tr")).Count - 1;

        }

        internal string GetLowestPriceProduct()
        {

        }

        internal void AddProductToCart()
        {

        }

        internal string GetItemsFromCart()
        {

        }
    }
}

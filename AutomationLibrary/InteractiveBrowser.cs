using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationLibrary
{
    public class InteractiveBrowser
    {
        private IWebDriver driver;
        /// <summary>
        /// Constructs a new instance of an Interactive InteractiveBrowser.
        /// </summary>
        /// <param name="type">The type of browser instance to create.</param>

        public InteractiveBrowser(BrowserOptions options)
        {
            this.Options = options;
            this.Options = new BrowserOptions
            {
                BrowserType = options.BrowserType
            };
        }

        public InteractiveBrowser(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebDriver Driver
        {
            get
            {
                if (this.driver == null)
                    this.driver = CreateWebDriver(this.Options);
                return driver;
            }
        }
        public BrowserOptions Options { get; private set; }
        public static IWebDriver CreateWebDriver(BrowserOptions options)
        {
            IWebDriver driver;

            switch (options.BrowserType)
            {
                case "Chrome":
                    var chromeService = ChromeDriverService.CreateDefaultService(options.DriversPath);
                    driver = new ChromeDriver(chromeService, options.ToChrome(), options.CommandTimeout);
                    break;
                case "IE":
                    var ieService = InternetExplorerDriverService.CreateDefaultService(options.DriversPath);
                    driver = new InternetExplorerDriver(ieService, options.ToInternetExplorer(), options.CommandTimeout);
                    break;
                case "Firefox":
                    var ffService = FirefoxDriverService.CreateDefaultService(options.DriversPath);
                    driver = new FirefoxDriver(ffService, options.ToFireFox());
                    driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 0, 5);
                    break;
                case "Edge":
                    var edgeService = EdgeDriverService.CreateDefaultService(options.DriversPath);
                    driver = new EdgeDriver(edgeService, options.ToEdge(), options.CommandTimeout);
                    break;
                case "Remote":
                    ICapabilities capabilities = null;
                    switch (options.RemoteBrowserType)
                    {
                        case "Chrome":
                            capabilities = options.ToChrome().ToCapabilities();
                            break;
                        case "Firefox":
                            capabilities = options.ToFireFox().ToCapabilities();
                            break;
                    }
                    driver = new RemoteWebDriver(options.RemoteHubServer, capabilities, options.CommandTimeout);
                    break;
                default:
                    throw new InvalidOperationException(
                        $"The browser type '{options.BrowserType}' is not recognized.");
            }

            driver.Manage().Timeouts().PageLoad = options.PageLoadTimeout;

            return driver;
        }
        public void Dispose()
        {
            if (driver != null)
            {
                try
                {
                    driver.Close();
                }
                // If the user has closed the window aleady, this exception would be thrown.
                catch (NoSuchWindowException) { }
                finally
                {
                    try
                    {
                        driver.Quit();
                    }
                    finally
                    {
                        driver = null;
                    }
                }
            }
        }
    }
}

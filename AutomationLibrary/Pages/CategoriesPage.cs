using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using System.Linq;
namespace AutomationLibrary
{
    public class CategoriesPage 
    {
        private readonly WebClient _client;
        IWebDriver _driver;
        ScenarioContext _scenarioContext;
        public CategoriesPage(WebClient client) : base()
        {
            _client = client;
        }

        public T GetElement<T>(WebClient client)
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { client });
        }
        public void SelectCategory(string categoryName)
        {
            _client.SelectCategory(categoryName);
        }


    }
}

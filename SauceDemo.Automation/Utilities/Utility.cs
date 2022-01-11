using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SauceDemo.Automation.Utilities
{
    public class Utility
    {
        protected ScenarioContext _scenarioContext;
        public Utility(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public bool VerifyPageUrl(string url, IWebDriver driver)
        {
            bool isValid = false;
            driver.Navigate().GoToUrl(url);
            if (driver.Url.Contains(url)) isValid = true;
            return isValid;
        }
    }
}

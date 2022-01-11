using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SauceDemo.Automation.Utilities;
using SauceDemo.Automation.Pages;
using OpenQA.Selenium;

namespace SauceDemo.Automation.Steps
{
    [Binding]
    public abstract class BaseSteps
    {
        protected ScenarioContext _scenarioContext;
        protected IWebDriver _driver;
        protected Utility _utility;
        protected CommonPage _commonPage;

        public BaseSteps(IWebDriver driver, ScenarioContext scenarioContext)
        {
            _driver = driver;
            _scenarioContext = scenarioContext;
            _utility = new Utility(scenarioContext);
            _commonPage = new CommonPage(driver);
        }
    }
}

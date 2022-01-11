using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SauceDemo.Automation.Drivers;
using BoDi;

namespace SauceDemo.Automation.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver _driver;
        private readonly IObjectContainer _objectContainer;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        public Hooks(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            this._objectContainer = objectContainer;
            this._scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            string device = ConfigurationManager.AppSettings["device"];
            string browser = ConfigurationManager.AppSettings["browser"];
            _driver = WebdriverFactory.WebDriver(_scenarioContext, device, browser);
            _objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Close();
            _driver.Quit();
            _scenarioContext.Clear();
        }
    }
}

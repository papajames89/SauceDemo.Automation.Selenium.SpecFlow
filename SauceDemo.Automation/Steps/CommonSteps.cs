using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SauceDemo.Automation.Steps
{
    [Binding]
    public sealed class CommonSteps : BaseSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public CommonSteps(IWebDriver driver, ScenarioContext scenarioContext) : base(driver, scenarioContext)
        {
            _driver = driver;
            _scenarioContext = scenarioContext;
        }

        [Given(@"I am on expected URL: '(.*)'")]
        [Then(@"I am on expected URL: '(.*)'")]
        public void GivenIAmOnExpectedURL(string url)
        {
            Assert.IsTrue(_utility.VerifyPageUrl(ConfigurationManager.AppSettings[url], _driver));
        }
    }
}

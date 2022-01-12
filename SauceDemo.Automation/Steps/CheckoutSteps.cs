using OpenQA.Selenium;
using SauceDemo.Automation.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SauceDemo.Automation.Steps
{
    [Binding]
    public sealed class CheckoutSteps : BaseSteps
    {

        private readonly ScenarioContext _scenarioContext;
        private CheckoutStep1Page _checkoutStep1Page;
        private CheckoutStep2Page _checkoutStep2Page;

        public CheckoutSteps(IWebDriver driver, ScenarioContext scenarioContext) : base(driver, scenarioContext)
        {
            _driver = driver;
            _checkoutStep1Page = new CheckoutStep1Page(driver);
            _checkoutStep2Page = new CheckoutStep2Page(driver);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SauceDemo.Automation.Pages;
using OpenQA.Selenium;

namespace SauceDemo.Automation.Steps
{
    [Binding]
    public sealed class LoginSteps : BaseSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private HomePage _homePage;

        public LoginSteps(IWebDriver driver, ScenarioContext scenarioContext) : base(driver, scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _homePage = new HomePage(driver);
        }

        [Given(@"I enter '(.*)' and '(.*)'")]
        public void GivenIEnterAnd(string login, string password)
        {
            Assert.IsTrue(_homePage.SetLoginAndPassword(login, password));
        }

        [When(@"I press Login button")]
        public void WhenIPressLoginButton()
        {
            _homePage.LoginButtonClick();
        }

        [Then(@"I can see '(.*)' message")]
        public void ThenICanSeeMessage(string message)
        {
            Assert.IsTrue(_homePage.GetErrorMessage(message));
        }

    }
}

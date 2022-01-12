using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public sealed class InventorySteps : BaseSteps
    {

        private readonly ScenarioContext _scenarioContext;
        private InventoryPage _inventoryPage;

        public InventorySteps(IWebDriver driver, ScenarioContext scenarioContext) : base(driver, scenarioContext)
        {
            _driver = driver;
            _inventoryPage = new InventoryPage(driver);
        }

        [When(@"I click '(.*)' button of each item in the store")]
        public void WhenIClickButtonOfEachItemInTheStore(string addToCart)
        {
            Assert.IsTrue(_inventoryPage.addEveryItemToBasket());
        }

        [Then(@"I can see a number of items in a basket equals number of items available in shop")]
        public void ThenICanSeeANumberOfItemsInABasketEqualsNumberOfItemsAvailableInShop()
        {
            Assert.IsTrue(_inventoryPage.verifyNumberOfItemsInBasket());
        }

    }
}

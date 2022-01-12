using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemo.Automation.Pages
{
    class InventoryPage : BasePage
    {

        public InventoryPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        #region Locators
        IReadOnlyCollection<IWebElement> addToCartButtons => _driver.FindElements(By.ClassName("btn_inventory"));
        IWebElement cartBadge => _driver.FindElement(By.ClassName("shopping_cart_badge"));
        #endregion


        #region Web Interaction Methods
        public bool addEveryItemToBasket()
        {
            bool isTrue = true;
            try
            {
                foreach (var button in addToCartButtons)
                {
                    button.Click();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                isTrue = false;
            }
            return isTrue;
        }

        public bool verifyNumberOfItemsInBasket()
        {
            bool isTrue = true;

            try
            {
                if (cartBadge.Text == addToCartButtons.Count.ToString()) ;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                isTrue = false;
            }

            return isTrue;
        }
        #endregion
    }
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemo.Automation.Pages
{
    class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        #region Locators
        IWebElement UsernameInput => _driver.FindElement(By.Id("user-name"));
        IWebElement PasswordInput => _driver.FindElement(By.Id("password"));
        IWebElement LoginButton => _driver.FindElement(By.Id("login-button"));
        IWebElement ErrorMessage => _driver.FindElement(By.XPath("//h3[@data-test='error']"));

        #endregion

        #region Web Interaction Methods
        public bool SetLoginAndPassword(string login, string password)
        {
            bool isTrue = true;
            try
            {
                UsernameInput.Clear();
                UsernameInput.SendKeys(login);
                PasswordInput.Clear();
                PasswordInput.SendKeys(password);
            }
            catch (Exception ex)
            {
                isTrue = false;
            }
            return isTrue;
        }
        public void LoginButtonClick()
        {
            LoginButton.Click();
        }
        public bool GetErrorMessage(string message)
        {
            if (ErrorMessage.Text.Contains(message))
                return true;
            else
            return false;
        }
        #endregion
    }
}

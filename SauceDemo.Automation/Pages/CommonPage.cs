using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SauceDemo.Automation.Pages
{
    public class CommonPage : BasePage
    {
        public CommonPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }
    }
}

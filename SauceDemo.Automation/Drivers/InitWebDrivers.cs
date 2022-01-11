using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SauceDemo.Automation.Drivers
{
    public class WebdriverFactory
    {
        public static IWebDriver Driver;
        private ScenarioContext _scenarioContext;


        public static IWebDriver WebDriver(ScenarioContext scenarioContext, string device, string browser)
        {
            switch (device.ToLower() + browser.ToLower())
            {
                case "desktopchrome":
                    Driver = ChromeDriver();
                    break;
                case "mobilechrome":
                    break;
                case "mobilesafari":
                    break;
                default:
                    Driver = ChromeDriver();
                    break;
            }
            return Driver;
        }

        private static IWebDriver ChromeDriver()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            return Driver;
        }

    }
}

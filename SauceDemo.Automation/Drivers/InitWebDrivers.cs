using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using System;
using System.Collections.Generic;
using System.Configuration;
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
                case "desktopsafari":
                    Driver = BrowserStackDesktopSafari();
                    break;
                case "mobilechrome":
                    Driver = BrowserStackMobileChrome();
                    break;
                case "mobilesafari":
                    Driver = BrowserStackMobileSafari();
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

        private static IWebDriver BrowserStackMobileSafari()
        {
            string username = ConfigurationManager.AppSettings["browserStackLogin"];
            string key = ConfigurationManager.AppSettings["browserStackKey"];

            ChromeOptions capabilities = new ChromeOptions();

            Dictionary<string, object> browserstackOptions = new Dictionary<string, object>();
            browserstackOptions.Add("deviceName", "iPhone 13 Pro");
            browserstackOptions.Add("realMobile", "true");
            browserstackOptions.Add("local", "false");
            browserstackOptions.Add("userName", username);
            browserstackOptions.Add("accessKey", key);

            capabilities.AddAdditionalOption("bstack:options", browserstackOptions);

            Driver = new RemoteWebDriver(new Uri("https://hub-cloud.browserstack.com/wd/hub/"), capabilities);
            return Driver;
        }

        private static IWebDriver BrowserStackMobileChrome()
        {
            string username = ConfigurationManager.AppSettings["browserStackLogin"];
            string key = ConfigurationManager.AppSettings["browserStackKey"];

            ChromeOptions capabilities = new ChromeOptions();

            Dictionary<string, object> browserstackOptions = new Dictionary<string, object>();
            browserstackOptions.Add("deviceName", "Samsung Galaxy S21");
            browserstackOptions.Add("realMobile", "true");
            browserstackOptions.Add("local", "false");
            browserstackOptions.Add("userName", username);
            browserstackOptions.Add("accessKey", key);

            capabilities.AddAdditionalOption("bstack:options", browserstackOptions);

            Driver = new RemoteWebDriver(new Uri("https://hub-cloud.browserstack.com/wd/hub/"), capabilities);
            return Driver;
        }

        private static IWebDriver BrowserStackDesktopSafari()
        {
            string username = ConfigurationManager.AppSettings["browserStackLogin"];
            string key = ConfigurationManager.AppSettings["browserStackKey"];

            SafariOptions capabilities = new SafariOptions();

            Dictionary<string, object> browserstackOptions = new Dictionary<string, object>();
            browserstackOptions.Add("os", "OS X");
            browserstackOptions.Add("local", "false");
            browserstackOptions.Add("userName", username);
            browserstackOptions.Add("accessKey", key);

            capabilities.AddAdditionalOption("bstack:options", browserstackOptions);

            Driver = new RemoteWebDriver(new Uri("https://hub-cloud.browserstack.com/wd/hub/"), capabilities);
            return Driver;
        }

    }
}

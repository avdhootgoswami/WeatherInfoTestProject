using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeatherInfo.Base
{
    [TestClass]
    public class BaseClass
    {
        private static IWebDriver GetFirefoxDriver()
        {
            IWebDriver driver = new FirefoxDriver();
            return driver;
        }
        private static IWebDriver GetChromeDriver()
        {
            IWebDriver driver = new ChromeDriver();
            return driver;
        }
        private static IWebDriver GetIEDriver()
        {
            IWebDriver driver = new InternetExplorerDriver();
            return driver;
        }

        [AssemblyInitialize]
        public static void InitWebDriver(TestContext testContext)
        {
            ObjectRepository.Config = new AppConfigReader();
            switch (ObjectRepository.Config.GetBrowser())
            {
                case "Chrome":
                    ObjectRepository.Driver = GetChromeDriver();
                    ObjectRepository.Driver.Manage().Window.Maximize();
                    break;
                case "Firefox":
                    ObjectRepository.Driver = GetFirefoxDriver();
                    ObjectRepository.Driver.Manage().Window.Maximize();
                    break;
                case "IE":
                    ObjectRepository.Driver = GetIEDriver();
                    ObjectRepository.Driver.Manage().Window.Maximize();
                    break;
                default:
                    throw new Exception("Invalid browser selected, failed to initialize drive object");
            }
        }

        [AssemblyCleanup]
        public static void TearDown()
        {
            if (ObjectRepository.Driver != null)
            {
                ObjectRepository.Driver.Close();
                ObjectRepository.Driver.Quit();
            }
        }
    }
}

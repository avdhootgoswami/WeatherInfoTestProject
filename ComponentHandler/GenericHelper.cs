using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWeatherInfo.Base;

namespace TestWeatherInfo.ComponentHandler
{
    public class GenericHelper
    {
        public static bool IsElementPresent(By locator)
        {
            try
            {
                var wait = new WebDriverWait(ObjectRepository.Driver, TimeSpan.FromSeconds(ObjectRepository.Config.GetExplicitWaitInSeconds()));
                wait.Until(drv => drv.FindElement(locator));

                if (ObjectRepository.Driver.FindElements(locator).Count != 0)
                    return true;
                else
                    return false;
                //return ObjectRepository.Driver.FindElements(locator).Count == 1;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static IWebElement GetElement(By locator)
        {
            if (IsElementPresent(locator))
                return ObjectRepository.Driver.FindElement(locator);
            else
                throw new Exception("Element not found");
        }

        public static IReadOnlyCollection<IWebElement> GetElements(By locator)
        {
            if (IsElementPresent(locator))
                return ObjectRepository.Driver.FindElements(locator);
            else
                throw new Exception("Element not found");
        }

        public static void NavigateToURL(string url)
        {
            ObjectRepository.Driver.Navigate().GoToUrl(url);
        }
    }
}

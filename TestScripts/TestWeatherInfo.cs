using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWeatherInfo.Base;
using TestWeatherInfo.ComponentHandler;

namespace TestWeatherInfo.TestScripts
{
    [TestClass]
    public class TestWeatherInfo
    {
        //Test case - Navigate to website and find a element on the page 
        [TestMethod]
        public void TestNavigateToWebsite()
        {
            GenericHelper.NavigateToURL(ObjectRepository.Config.GetWebsite());
            Assert.IsTrue(GenericHelper.IsElementPresent(By.XPath("//h2[contains(text(),'Find a forecast')]")));
        }

        //Test case - Navigate to website and search weather for a location using search input field
        [TestMethod]
        public void TestSearchWeatherForALocation()
        {
            bool isCriteriaOneValid = false;
            bool isCriteriaTwoValid = false;

            string searchLocation = ObjectRepository.Config.GetLocation();
            string todayDate = DateTime.Now.ToString("yyyy-MM-dd");

            GenericHelper.NavigateToURL(ObjectRepository.Config.GetWebsite());
            
            //Home page
            GenericHelper.GetElement(By.Id("location-search-input")).SendKeys(searchLocation);
            GenericHelper.GetElement(By.XPath("//button[@id='location-search-submit']")).Click();

            //Next page
            if (searchLocation.Equals(GenericHelper.GetElement(By.Id("location-search-input")).GetAttribute("value")))
                isCriteriaOneValid = true;

            GenericHelper.GetElement(By.XPath("//li[@id='tabDay0']")).GetAttribute("data-tab-id");
            if (todayDate.Equals(GenericHelper.GetElement(By.XPath("//li[@id='tabDay0']")).GetAttribute("data-tab-id")))
                isCriteriaTwoValid = true;

            Assert.IsTrue(isCriteriaOneValid && isCriteriaTwoValid);
        }

        //Test case - Compare humidity values for a location for today and tomorrow for same time
        [TestMethod]
        public void TestCompareTodayTomorrowHumidityForALocationForATime()
        {
            #region Declerations
            string searchLocation = ObjectRepository.Config.GetLocation();
            string todayDate = DateTime.Now.ToString("yyyy-MM-dd");
            string currentHour = DateTime.Now.ToString("HH:00");
            string tomorrowDate = DateTime.Now.AddHours(24).ToString("yyyy-MM-dd");

            int todayHourCount = 1;
            int nextDayHourCount = 1;
            int todayHumidityValueForCurrentHour;
            int nextDayHumidityValueForCurrentHour;

            IReadOnlyCollection<IWebElement> todayHourValues;
            IReadOnlyCollection<IWebElement> nextDayHourValues;

            IDictionary<string, int> dictTodayTimeAndHumidity = new Dictionary<string, int>();
            IDictionary<string, int> dictNextDayTimeAndHumidity = new Dictionary<string, int>();
            #endregion

            //Home page
            GenericHelper.NavigateToURL(ObjectRepository.Config.GetWebsite());
            GenericHelper.GetElement(By.Id("location-search-input")).SendKeys(searchLocation);
            GenericHelper.GetElement(By.XPath("//button[@id='location-search-submit']")).Click();

            //Next page 
            //Console.WriteLine("Humidity data for: {0}", todayDate);
            //Console.WriteLine(String.Format("| {0,-8} | {1,-8} | {2,-100}", "Hour", "Humidity", "XPath"));
            //Console.WriteLine("------------------------------------------------------------------------");
            
            //Get Todays Time & humidity Values
            todayHourValues = GenericHelper.GetElements(By.XPath("//th[contains(@id,'d0t')]"));
            foreach (var hourValue in todayHourValues)
            {
                string dynamicXpathForHumidityValue = "//div[@id='" + todayDate + "']//tr[@class='detailed-view step-humidity']//td[" + todayHourCount + "]//span";
                IWebElement humidityValue = GenericHelper.GetElement(By.XPath(dynamicXpathForHumidityValue));
                //Console.WriteLine(String.Format("| {0,-8} | {1,-8} | {2,-100} ", hourValue.Text, Convert.ToInt32(humidityValue.GetAttribute("data-value")), dynamicXpathForHumidityValue));

                if (hourValue.Text.Equals("Now"))
                    dictTodayTimeAndHumidity.Add(currentHour, Convert.ToInt32(humidityValue.GetAttribute("data-value")));
                else
                {
                    if(!dictTodayTimeAndHumidity.ContainsKey(hourValue.Text))
                        dictTodayTimeAndHumidity.Add(hourValue.Text, Convert.ToInt32(humidityValue.GetAttribute("data-value")));
                }
                todayHourCount++;
            }
            //Console.WriteLine("------------------------------------------------------------------------");

            //Console.WriteLine("Humidity data for: {0}", tomorrowDate);
            //Console.WriteLine(String.Format("| {0,-8} | {1,-8} | {2,-100}", "Hour", "Humidity", "XPath"));
            //Console.WriteLine("------------------------------------------------------------------------");
            
            // Get Next Day Time & humidity Values
            nextDayHourValues = GenericHelper.GetElements(By.XPath("//th[contains(@id,'d1t')]"));
            foreach (var hourValue in nextDayHourValues)
            {
                string dynamicXpathForHumidityValue = "//div[@id='" + tomorrowDate + "']//tr[@class='detailed-view step-humidity']//td[" + nextDayHourCount + "]//span";
                IWebElement humidityValue = GenericHelper.GetElement(By.XPath(dynamicXpathForHumidityValue));
                //Console.WriteLine(String.Format("| {0,-8} | {1,-8} | {2,-100} ", hourValue.Text, Convert.ToInt32(humidityValue.GetAttribute("data-value")), dynamicXpathForHumidityValue));
                if (!dictNextDayTimeAndHumidity.ContainsKey(hourValue.Text))
                    dictNextDayTimeAndHumidity.Add(hourValue.Text, Convert.ToInt32(humidityValue.GetAttribute("data-value")));
                nextDayHourCount++;
            }
            //Console.WriteLine("------------------------------------------------------------------------");

            todayHumidityValueForCurrentHour = dictTodayTimeAndHumidity[currentHour];
            nextDayHumidityValueForCurrentHour = dictNextDayTimeAndHumidity[currentHour];

            Console.WriteLine("Humidity for {0} for {1} hr is : {2}", todayDate, currentHour, todayHumidityValueForCurrentHour);
            Console.WriteLine("Humidity for {0} for {1} hr is : {2}", tomorrowDate, currentHour, nextDayHumidityValueForCurrentHour);
            Console.WriteLine("Difference in humidity is : {0}", todayHumidityValueForCurrentHour - nextDayHumidityValueForCurrentHour);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWeatherInfo.Interfaces;

namespace TestWeatherInfo.Base
{
    public class AppConfigReader : IConfig
    {
        public string GetBrowser()
        {
            return ConfigurationManager.AppSettings.Get("BrowserType");
        }

        public int GetExplicitWaitInSeconds()
        {
            return Convert.ToInt32(ConfigurationManager.AppSettings.Get("ExplicitWaitInSeconds"));
        }

        public string GetLocation()
        {
            return ConfigurationManager.AppSettings.Get("Location");
        }

        public string GetWebsite()
        {
            return ConfigurationManager.AppSettings.Get("WebsiteURL");
        }
    }
}

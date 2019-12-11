using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeatherInfo.Interfaces
{
    public interface IConfig
    {
        string GetBrowser();
        string GetWebsite();
        string GetLocation();

        int GetExplicitWaitInSeconds();
    }
}

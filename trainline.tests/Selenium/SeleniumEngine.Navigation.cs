using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trainline.tests.Selenium.IControls;

namespace trainline.tests.Selenium
{
    public partial class SeleniumEngine : IControls.INavigation
    {
        public void GetURL(string url)
        {
            driver.Url = url;
        }

        public void CloseAndQuit()
        {
            driver.Close();
            driver.Quit();
            driver.Dispose();
        }
    }
}


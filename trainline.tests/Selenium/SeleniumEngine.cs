using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trainline.tests.Selenium
{
    public partial  class SeleniumEngine
    {
        private IWebDriver driver;

        public SeleniumEngine()
        {
           this.driver =  GetChromeDriver();
        }

        IWebDriver GetChromeDriver()
        {
            try
            {
                var driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
              
                return driver;

            }
            catch(Exception e)
            {
                Console.WriteLine("Not able to initialize ChromeDriver");
                throw e;
            }
        }
    }
}

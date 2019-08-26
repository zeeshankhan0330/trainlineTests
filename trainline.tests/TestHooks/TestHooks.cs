using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using trainline.tests.Selenium;
using trainline.tests.Selenium.IControls;

namespace trainline.tests.TestHooks
{
    [Binding]
    public sealed class TestHooks
    {

        private IObjectContainer container;
        private SeleniumEngine driver;


        public TestHooks(ObjectContainer container)
        {
            this.container = container;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
             driver = new SeleniumEngine();
            container.RegisterInstanceAs<IElement>(driver);
            container.RegisterInstanceAs<Selenium.IControls.INavigation>(driver);
            container.RegisterInstanceAs<IDropdown>(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.CloseAndQuit();
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trainline.tests.Selenium.IControls;

namespace trainline.tests.Selenium
{
    public partial class SeleniumEngine : IElement
    {
        public void Click(IWebElement element)
        {
            element.Click();
        }



        public void EnterText(IWebElement element,string text)
        {
            element.SendKeys(text);
        }




        public IWebElement Find(string location, ElementLocator locator)
        {
   
            IWebElement element = null;
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(15);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            if (locator == ElementLocator.Id)
            {
                element = fluentWait.Until(x => x.FindElement(By.Id(location)));
            }
            else if (locator == ElementLocator.Css)
            {
                element = fluentWait.Until(x => x.FindElement(By.CssSelector(location)));
            }

            else if (locator == ElementLocator.XPath)
            {
                element = fluentWait.Until(x => x.FindElement(By.XPath(location)));
            }

            else if (locator == ElementLocator.Name)
            {
                element = fluentWait.Until(x => x.FindElement(By.Name(location)));
            }

            else if (locator == ElementLocator.PartialText)
            {
                element = fluentWait.Until(x => x.FindElement(By.PartialLinkText(location)));
            }
            if (element == null)
                throw new NoSuchElementException();
            return element;
        }



        public IList<IWebElement> FindAll(string location, ElementLocator locator)
        {
      
            IList<IWebElement> element = null; ;
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(15);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            if (locator == ElementLocator.Id)
            {
                element = fluentWait.Until(x => x.FindElements(By.Id(location)));
            }
            else if (locator == ElementLocator.Css)
            {
                element = fluentWait.Until(x => x.FindElements(By.CssSelector(location)));
            }

            else if (locator == ElementLocator.XPath)
            {
                element = fluentWait.Until(x => x.FindElements(By.XPath(location)));
            }

            else if (locator == ElementLocator.Name)
            {
                element = fluentWait.Until(x => x.FindElements(By.Name(location)));
            }

            else if (locator == ElementLocator.PartialText)
            {
                element = fluentWait.Until(x => x.FindElements(By.PartialLinkText(location)));
            }

            return element;
        }

        public void JavaScriptClick(IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].click();", element);
        }

        public void PressEnter(IWebElement element)
        {
            element.SendKeys(Keys.Return);
        }


        public void WaitForAnElement(string xpath)
        {
            DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            fluentWait.Timeout = TimeSpan.FromSeconds(15);
            fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentWait.Until(x => x.FindElement(By.XPath(xpath)));
        }


        public void MouseClick(IWebElement element)
        {
            Actions act = new Actions(driver);
            act.MoveToElement(element).Build().Perform();
        }
    }

}


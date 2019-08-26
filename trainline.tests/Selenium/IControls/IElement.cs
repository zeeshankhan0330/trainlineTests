using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trainline.tests.Selenium.IControls
{
   public  interface IElement
    {

        void Click(IWebElement element);

        void JavaScriptClick(IWebElement element);

        void EnterText(IWebElement element, string text);

        IWebElement Find(string location, ElementLocator locator);

        IList<IWebElement> FindAll(string location, ElementLocator locator);

        void PressEnter(IWebElement element);

        void WaitForAnElement(string xpath);

        void MouseClick(IWebElement element);

    }
}

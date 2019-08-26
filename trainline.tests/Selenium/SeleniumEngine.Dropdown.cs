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
    public partial class SeleniumEngine : IDropdown
    {

        public void SelectElement(IWebElement element, int index)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByIndex(index);
        }

        public void SelectElement(IWebElement element, string value)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByValue(value);
        }
    }
}

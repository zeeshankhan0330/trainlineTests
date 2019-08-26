using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trainline.tests.Selenium.IControls
{
    public interface IDropdown
    {
        void SelectElement(IWebElement element,int index);

        void SelectElement(IWebElement element, string value);
    }
}

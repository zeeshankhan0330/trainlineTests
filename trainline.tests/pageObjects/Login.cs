using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trainline.tests.Selenium.IControls;

namespace trainline.tests.pageObjects
{
    public class LoginPage
    {
        private INavigation navigate;
        public LoginPage(INavigation navigate)
        {
            this.navigate = navigate;
        }


        public void LoginIntoApp()
        {
            navigate.GetURL("https://www.thetrainline.com/");
        }
    }
}

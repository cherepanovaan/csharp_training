using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class MenuHelper : HelperBase
    {
        public MenuHelper(ApplicationManager manager) : base(manager) { }

        public void GoToControlMenu()
        {
            driver.FindElement(By.XPath("//a[@href='" + hrefBase + "/manage_overview_page.php']")).Click();
        }
    }
}

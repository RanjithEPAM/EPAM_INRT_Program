using INRT.Support;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INRT.POM
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement dashboard => driver.FindElement(By.XPath("//h6[text()='Dashboard']"));

        public void VerifyHomepage()
        {
           HelperMethods.VerifyElementPresence(dashboard);
        }
        
    }
}
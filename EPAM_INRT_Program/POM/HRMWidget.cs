using INRT.Support;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INRT.POM
{
    public class HRMWidget
    {
        public HRMWidget(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebDriver driver;


        protected private IWebElement Myinfo => driver.FindElement(By.XPath("//span[text()='My Info']"));


        
    }
}

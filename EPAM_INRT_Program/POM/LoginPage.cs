using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INRT.POM
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        

      private IWebElement username => driver.FindElement(By.Name("username"));
      private IWebElement password => driver.FindElement(By.Name("password"));
      private IWebElement SubmitButton => driver.FindElement(By.XPath("//button[@type='submit']"));

      public void login()
        {
            username.SendKeys(HooksAPI.UserName);
            password.SendKeys(HooksAPI.Password);
            SubmitButton.Click();
        }

    }
}

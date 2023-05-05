using INRT.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V110.Target;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INRT.POM
{
    public class PersonalDetailsPage : HRMWidget
    {
        private IWebDriver driver;
        public PersonalDetailsPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }
        private IWebElement PersonalDetailsLink => driver.FindElement(By.XPath("//a[text()='Personal Details']"));
        private IWebElement FirstNameTextBox => driver.FindElement(By.XPath("//input[@name='firstName']"));
        private IWebElement LastNameTextBox => driver.FindElement(By.XPath("//input[@name='lastName']"));
       

        private IWebElement saveButton => driver.FindElement(By.XPath("//button[@type='submit']"));
        public void NavigateToPersonalDetailsPage()
        {
            HelperMethods.ClickOnElement(Myinfo);
            HelperMethods.VerifyElementPresence(PersonalDetailsLink);
        }
        public void EnterPersonalDetails(string Firstname, string LastName)
        {
            HelperMethods.EnterGivenText(FirstNameTextBox, Firstname);
            HelperMethods.EnterGivenText(LastNameTextBox, LastName);
            scrollDown();
            HelperMethods.ClickOnElement(saveButton);
        }
        public void scrollDown()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,550)", "");
        }
    }
}
using INRT.Support;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INRT.POM
{
    public class ContactDetailsPage : HRMWidget
    {

        private IWebDriver driver;
        public ContactDetailsPage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }
        private IWebElement ContactDetailsLink => driver.FindElement(By.XPath("//a[text()='Contact Details']"));
        private IWebElement Street1TextBox => driver.FindElement(By.XPath("//label[text()='Street 1']//parent::div//following-sibling::div/input"));
        private IWebElement Street2TextBox => driver.FindElement(By.XPath("//label[text()='Street 2']//parent::div//following-sibling::div/input"));
        private IWebElement CityTextBox => driver.FindElement(By.XPath("//label[text()='City']//parent::div//following-sibling::div/input"));
        private IWebElement saveButton => driver.FindElement(By.XPath("//button[@type='submit']"));
        public void NavigateToContactDetailsPage()
        {
            HelperMethods.ClickOnElement(Myinfo);
            HelperMethods.VerifyElementPresence(ContactDetailsLink);
            HelperMethods.ClickOnElement(ContactDetailsLink);
        }


        public void EnterContactDetails(string Street1, string Street2, string City)
        {
            HelperMethods.EnterGivenText(Street1TextBox, Street1);
            HelperMethods.EnterGivenText(Street2TextBox, Street2);
            HelperMethods.EnterGivenText(CityTextBox, City);
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
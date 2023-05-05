using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INRT.Support
{
    public static class HelperMethods
    {
        public static IWebDriver driver;

        public static void VerifyElementPresence(IWebElement element)
        {
            Assert.IsTrue(element.Displayed);
        }

        public static void ClickOnElement(IWebElement element)
        {
            try
            {
                element.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void EnterGivenText(IWebElement element, string text)
        {
            try
            {
                element.Clear();
                element.SendKeys(text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }


        
    }
}

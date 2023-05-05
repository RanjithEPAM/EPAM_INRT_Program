using INRT.POM;
using INRT.Support;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace INRT.StepDefinitions
{
    [Binding]
    public class ContactDetailsSteps
    {
        public IWebDriver driver;
        public readonly ScenarioContext scenarioContext;
        LoginPage loginPage;
        HomePage homePage;
        ContactDetailsPage contactDetailsPage;
        public ContactDetailsSteps(ScenarioContext _scenarioContext)
        {
            scenarioContext = _scenarioContext;
            this.driver = HooksAPI.driver;
        }

        [When(@"I navigate to Contact Details page")]
        public void WhenINavigateToContactDetailsPage()
        {
            contactDetailsPage = new ContactDetailsPage(driver);
            contactDetailsPage.NavigateToContactDetailsPage();
        }

        [Then(@"I should be able to enter below data in Contact details page")]
        public void ThenIShouldBeAbleToEnterBelowDataInContactDetailsPage(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            contactDetailsPage.EnterContactDetails(dictionary["Street1"], dictionary["Street2"], dictionary["City"]);
        }
    }
}
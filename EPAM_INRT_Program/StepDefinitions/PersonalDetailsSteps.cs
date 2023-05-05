using INRT.POM;
using INRT.Support;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Assist;

namespace INRT.StepDefinitions
{
    [Binding]
    public class PersonalDetailsSteps
    {
        public readonly ScenarioContext scenarioContext;
        public IWebDriver driver;
        LoginPage loginPage;
        HomePage homePage;
        PersonalDetailsPage personalDetailsPage;
        public PersonalDetailsSteps(ScenarioContext _scenarioContext)
        {
            scenarioContext = _scenarioContext;
            this.driver = HooksAPI.driver;
        }

        [Given(@"I launch the Orange HRM url")]
        public void GivenILaunchTheOrangeHRMUrl()
        {
            driver.Url = HooksAPI.HRMURL;
        }

        [When(@"I enter the HRM user credentials")]
        public void WhenIEnterTheHRMUserCredentials()
        {
            loginPage = new LoginPage(driver);
            loginPage.login();
        }

        [Then(@"OrangeHRM home page should be displayed")]
        public void ThenOrangeHRMHomePageShouldBeDisplayed()
        {
            homePage = new HomePage(driver);
            homePage.VerifyHomepage();
        }

        [Given(@"I am on OrangeHRM home page")]
        public void GivenIAmOnOrangeHRMHomePage()
        {
            homePage.VerifyHomepage();
        }

        [When(@"I navigate to Personal Details page")]
        public void WhenINavigateToPersonalDetailsPage()
        {
            personalDetailsPage = new PersonalDetailsPage(driver);
            personalDetailsPage.NavigateToPersonalDetailsPage();
        }

        [Then(@"I should be able to enter below data in personal details page")]
        public void ThenIShouldBeAbleToEnterBelowDataInPersonalDetailsPage(Table table)
        {
            var dictionary = TableExtensions.ToDictionary(table);
            personalDetailsPage.EnterPersonalDetails(dictionary["FirstName"], dictionary["LastName"]);
        }
    }
}
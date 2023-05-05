using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using INRT.Support;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NUnit.Framework.Internal.Execution;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V110.Cast;
using System.Reflection;
using TechTalk.SpecFlow;

namespace INRT
{
    [Binding]
    public static class HooksAPI
    {
        [ThreadStatic]
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        public static IWebDriver driver;
        public static string HRMURL;
        public static string UserName;
        public static string Password;
        static AventStack.ExtentReports.ExtentReports extent;
        static AventStack.ExtentReports.ExtentTest feature;
        static AventStack.ExtentReports.ExtentTest scenario;
        static ExtentTest step;
        public static string repoPath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Support\Report.html");


        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            LoadJson();
            InitializeReport();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            feature = extent.CreateTest(featureContext.FeatureInfo.Title);
            feature.Log(Status.Info, "Feature is started");
        }


        [BeforeStep]
        public static void BeforeStep()
        {
            step = scenario;
        }

        [AfterStep]
        public static void AfterScenario(ScenarioContext Context)
        {
            if(Context.TestError == null)
            {
                step.Log(Status.Pass, Context.StepContext.StepInfo.Text);
            }
            else if (Context.TestError != null)
            {
                var screenshot = CaptureScreenshot(Context.StepContext.StepInfo.Text);
                step.Log(Status.Fail, Context.StepContext.StepInfo.Text, screenshot);
            }
        }

        [BeforeScenario]
        public static void BeforeScenario(ScenarioContext _scenarioContext)
        {
            LaunchBrowser();
            scenario = feature.CreateNode(_scenarioContext.ScenarioInfo.Title);
            
        }
        public static void LaunchBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }

        public static void InitializeReport()
        {
            ExtentHtmlReporter htmlReport = new ExtentHtmlReporter(repoPath);
            htmlReport.Config.DocumentTitle = "Test Execution Report";
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReport);
        }

        [AfterScenario]
        public static void CloseBrowser()
        {
            /*
            driver.Close();
            driver.Quit();
            */
        }
        [AfterFeature]
        public static void TearDownReport()
        {
            extent.Flush();
        }
        public static void LoadJson()
        {
            string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Support\Config.json"));
            using (StreamReader reader = new StreamReader(path))
            {
                string jsonString = reader.ReadToEnd();
                JsonDTO dto = JsonConvert.DeserializeObject<JsonDTO>(jsonString);
                HRMURL = dto.HRM_URL;
                UserName = dto.Username;
                Password = dto.Password;
            }
        }

        public static MediaEntityModelProvider CaptureScreenshot(string name)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, name).Build();
        }


    }
}
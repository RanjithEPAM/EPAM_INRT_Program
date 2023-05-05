using APIAutomation.Support;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NUnit.Framework.Internal.Execution;

using System.Reflection;
using TechTalk.SpecFlow;

namespace INRT
{
    [Binding]
    public static class HooksAPI
    {
        [ThreadStatic]
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

       public static string DummyBaseURL;
       public static string ResreqBaseURL;
        public static string CreateEmployeesEndpoint;
       public static string GetEmployeesEndpoint;
        static AventStack.ExtentReports.ExtentReports extent;
        static AventStack.ExtentReports.ExtentTest feature;
        static AventStack.ExtentReports.ExtentTest scenario;
        static ExtentTest step;
        public static string repoPath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Support\APIReport.html");


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

        public static void ReportLogs(String Description)
        {
           step.Log(Status.Pass, Description);
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
                step.Log(Status.Fail, Context.StepContext.StepInfo.Text);
            }
        }

        [BeforeScenario]
        public static void BeforeScenario(ScenarioContext _scenarioContext)
        {
            scenario = feature.CreateNode(_scenarioContext.ScenarioInfo.Title);
        }
        

        public static void InitializeReport()
        {
            ExtentHtmlReporter htmlReport = new ExtentHtmlReporter(repoPath);
            htmlReport.Config.DocumentTitle = "Test Execution Report";
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReport);
        }

        [AfterScenario]
        

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
                ApiJSONdto dto = JsonConvert.DeserializeObject<ApiJSONdto>(jsonString);
                DummyBaseURL = dto.DummyBaseURL;
                ResreqBaseURL = dto.ResReqBaseURL;
                CreateEmployeesEndpoint = dto.DummyCreateEmployeesEndpoint;
                GetEmployeesEndpoint = dto.ResReqGetEmployeesEndpoint;

            }
        }
    }
}
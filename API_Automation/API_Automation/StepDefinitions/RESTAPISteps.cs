using APIAutomation.Support;
using APITesting.Utilites;
using FluentAssertions.Equivalency.Steps;
using NUnit.Framework;
using RestSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Assist;

namespace INRT.StepDefinitions
{
    [Binding]
    public class RESTAPISteps
    {
        public ScenarioContext _scenarioContext;
        public RESTAPISteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        RestClient restClient;
        RestRequest restRequest;
        RestResponse restResponse;


        [Given(@"I have a POST request for the REST API as")]
        public void GivenIHaveAPOSTRequestForTheRESTAPIAs(Table table)
        {
            var inputdata = table.CreateInstance<RequestData>();
            var JsonData = HelperClass.GetRequestData(inputdata.Age, inputdata.Name, inputdata.Salary);
            _scenarioContext["RequestJsonData"] = JsonData;
            restClient = new RestClient(HooksAPI.DummyBaseURL);
        }


        [When(@"I send the POST request for REST API")]
        public void WhenISendThePOSTRequestForRESTAPI()
        {
            restRequest = new RestRequest(HooksAPI.CreateEmployeesEndpoint);
            restRequest.AddBody(_scenarioContext["RequestJsonData"]);
            restResponse = restClient.Post(restRequest);
        }

        [Then(@"I receive the response")]
        public void ThenIReceiveTheResponse()
        {
            Console.WriteLine(restResponse.ToString());
        }

        [Then(@"the status code should be (.*)")]
        public void ThenTheStatusCodeShouldBe(int code)
        {
            Console.WriteLine(restResponse.StatusCode);
            Assert.AreEqual(code, (int)restResponse.StatusCode);
        }



        [Given(@"I have a GET request for the REST API")]
        public void GivenIHaveAGETRequestForTheRESTAPI()
        {
            restClient = new RestClient(HooksAPI.ResreqBaseURL);
        }


        [When(@"I send the GET request for REST API")]
        public void WhenISendTheGETRequestForRESTAPI()
        {
            restRequest = new RestRequest(HooksAPI.GetEmployeesEndpoint);
            restResponse = restClient.Get(restRequest);
            _scenarioContext["ResponseData"] = restResponse.Content;
        }

        [Then(@"the response should contain data as")]
        public void ThenTheResponseShouldContainDataAs(Table table)
        {
            var expectedData = table.CreateInstance<User>();
            var ResponseData = JsonConvert.DeserializeObject<ListofUsersDTO>(_scenarioContext["ResponseData"].ToString());
            Console.WriteLine(ResponseData.data);
            Assert.AreEqual(ResponseData.data.Id, expectedData.Id);
            HooksAPI.ReportLogs("Actual response: " + ResponseData.data.Id + "  Expected response: " + expectedData.Id);
            Assert.AreEqual(ResponseData.data.first_name, expectedData.first_name);
            HooksAPI.ReportLogs("Actual response: " + ResponseData.data.first_name + "  Expected response: " + expectedData.last_name);
            Assert.AreEqual(ResponseData.data.last_name, expectedData.last_name);
            Assert.AreEqual(ResponseData.data.email, expectedData.email);
        }
    }
}
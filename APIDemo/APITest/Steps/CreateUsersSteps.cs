using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpDemo;
using RestSharpDemo.Models;
using TechTalk.SpecFlow;

namespace APITest.Steps
{
    [Binding]
    public class CreateUsersSteps
    {
        public const string BASE_URL = "https://reqres.in/";
        public AddUserReq payload; // request
        public Demo api = new Demo();
        public AddUserRes actualResult; // response

        public CreateUsersSteps(AddUserReq payload)
        {
            this.payload = payload;
        }
        [Given(@"I input name ""(.*)""")]
        public void GivenIInputName(string name)
        {
            payload.Name = name;
        }

        [Given(@"I input job ""(.*)""")]
        public void GivenIInputJob(string job)
        {
            payload.Job = job;
        }

        [When(@"I send request to create user")]
        public void WhenISendRequestToCreateUserAsync()
        {
            actualResult = api.AddUsers(BASE_URL, payload);

        }

        [Then(@"Validate user is created")]
        public void ThenValidateUserIsCreated()
        {
            Assert.AreEqual(payload.Name, actualResult.Name);
        }
    }
}

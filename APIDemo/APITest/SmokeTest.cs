using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharpDemo;
using RestSharpDemo.Models;

namespace APITest
{
    [TestClass]
    public class SmokeTest
    {
        public TestContext TestContext { get; set; }
        public const string BASE_URL = "https://reqres.in/";

        [ClassInitialize]
        public static void SetUp(TestContext testContext)
        {
            Reporter.SetUpReport(testContext.TestRunDirectory, "SmokeTest", "API Test Automation Report");
        }

        [TestInitialize]
        public void CreateTest()
        {
            Reporter.CreateTest(TestContext.TestName);
        }

        [TestCleanup]
        public void TearDownTest()
        {
            var testStatus = TestContext.CurrentTestOutcome;
            Status status;

            switch (testStatus)
            {
                case UnitTestOutcome.Failed:
                    status = Status.Fail;
                    Reporter.TestStatus(status.ToString());
                    break;
                case UnitTestOutcome.Inconclusive:
                    break;
                case UnitTestOutcome.Passed:
                    status = Status.Pass;
                    Reporter.TestStatus(status.ToString());
                    break;
                case UnitTestOutcome.InProgress:
                    break;
                case UnitTestOutcome.Error:
                    break;
                case UnitTestOutcome.Timeout:
                    break;
                case UnitTestOutcome.Aborted:
                    break;
                case UnitTestOutcome.Unknown:
                    break;
                case UnitTestOutcome.NotRunnable:
                    break;
            }
        }

        [ClassCleanup]
        public static void CleanUp()
        {
            Reporter.FlushReport();
        }

        [TestMethod]
        public void GetUserLists()
        {
            var api = new Demo();
            var actualResult = api.GetUsers(BASE_URL);
            Assert.AreEqual(2, actualResult.Page);
            Reporter.LogToReport(Status.Pass, "All users are listed");
        }

        [TestMethod]
        public void AddNewSingleUser()
        {
            var api = new Demo();
            string payload = @"{
                                ""name"": ""morpheus"",
                                ""job"": ""leader""
                            }";
            var actualResult = api.AddUsers(BASE_URL, payload);
            Assert.AreEqual("morpheus", actualResult.Name);
        }

        [TestMethod]
        [DeploymentItem("Test Data\\NewUser.csv"), DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "NewUser.csv", "NewUser#csv", DataAccessMethod.Sequential)]
        public void AddNewUsersUsingCSVFile()
        {
            var api = new Demo();
            var payload = new AddUserReq
            {
                Name = TestContext.DataRow["Name"].ToString(),
                Job = TestContext.DataRow["Job"].ToString()
            };

            var actualResult = api.AddUsers(BASE_URL, payload);
            Assert.AreEqual(payload.Name, actualResult.Name);
        }

        [TestMethod]
        [DeploymentItem("Test Data")] //will see all json files under this folder
        public void AddNewUsersUsingJsonFile()
        {
            var api = new Demo();
            var payload = HandleContent.GetContentFile<AddUserReq>("NewUser.json");

            var actualResult = api.AddUsers(BASE_URL, payload);
            Assert.AreEqual(payload.Name, actualResult.Name);
        }

        [TestMethod]
        [DeploymentItem("Test Data")] //will see all json files under this folder
        public void UpdateUserUsingJsonFile()
        {
            var api = new Demo();
            var payload = HandleContent.GetContentFile<AddUserReq>("NewUser.json");

            var actualResult = api.UpdateUser(BASE_URL, payload, "2");
            Assert.AreEqual(payload.Name, actualResult.Name);
        }

        [TestMethod]
        public void DeleteUser()
        {
            var api = new Demo();
            var actualResult = api.DeleteUser(BASE_URL, "2");
            var statusCode = (int)actualResult;
            Assert.AreEqual(200, statusCode);
        }
    }
}

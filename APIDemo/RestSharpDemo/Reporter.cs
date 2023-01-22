using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpDemo
{
    public static class Reporter
    {
        private static ExtentReports extentReport;
        private static ExtentHtmlReporter htmlReport;
        private static ExtentTest extentTest;

        public static void SetUpReport(dynamic path,string documentTitle, string reportName){
            htmlReport = new ExtentHtmlReporter(path);
            htmlReport.Config.Theme =Theme.Dark;
            htmlReport.Config.DocumentTitle = documentTitle;
            htmlReport.Config.ReportName = reportName;

            extentReport = new ExtentReports();
            extentReport.AttachReporter(htmlReport);
        }

        public static void LogToReport(Status status,string message){
            extentTest.Log(status, message);
        }

        public static void CreateTest(string testName){
            extentTest = extentReport.CreateTest(testName);
        }

        public static void FlushReport(){
            extentReport.Flush();
        }

        public static void TestStatus(string status){
            if(status=="Pass")
                extentTest.Pass("Test Case Passed");
            else
                extentTest.Fail("Test Case Failed");
        }
    }
}

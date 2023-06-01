using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.IO;
using System.Threading;
using Demoblaze.SetUp;
using Demoblaze.Webpages;
using Demoblaze.WebPages.Base;
using Demoblaze.WebPages;

namespace Demoblaze.Tests
{
    [SetUpFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class SetUpFixtureBase
    {
        #region Definitions
        public static ExtentReports extent;
        public static string HTMLPath = $@"{TestContext.CurrentContext.WorkDirectory}\Screenshots\" + DateTime.Now.ToString("yyyyMMdd-HHmm");
        public static int n_threads = 0;
        #endregion

        [OneTimeSetUp]
        public void StartReport()
        {
            n_threads++;
            if (extent == null)
            {
                if (!Directory.Exists(SetUpFixtureBase.HTMLPath))
                {
                    Directory.CreateDirectory(HTMLPath);
                }

                var reportPath = new ExtentHtmlReporter(HTMLPath + @"\");

                extent = new ExtentReports();
                extent.AttachReporter(reportPath);

                extent.AddSystemInfo("TGS: ", "Windows 11");
                extent.AddSystemInfo("Operating System: ", "Windows 11");
                extent.AddSystemInfo("Hostname: ", "Selenium");
                extent.AddSystemInfo("Browser: ", "Google Chrome");
            }
        }

        [OneTimeTearDown]
        public void EndReport()
        {
            n_threads--;
            if (n_threads == 0)
            {
                extent.Flush();
            }
        }
    }

    public class TestSetCleanBase
    {
        #region Definitions
        protected HomePage homePage;
        protected LoginPage loginPage;
        protected CartPage cartPage;
        protected ItemPage itemPage;
        protected Page page;
        protected ISetUpWebDriver setUpWebDriver;
        protected ObjectsTest objectsTest;
        protected ExtentTest test;
        #endregion

        [SetUp]
        public void TestSetUp()
        {
            test = SetUpFixtureBase.extent.CreateTest(this.GetType().Name);
            setUpWebDriver = new SetUpWebDriver();
            objectsTest = new ObjectsTest();
        }

        [TearDown]
        public void TestCleanUp()
        {
            page = new Page(setUpWebDriver);
            var status = TestContext.CurrentContext.Result.Outcome.Status;

            var message = string.IsNullOrEmpty(TestContext.CurrentContext.Result.Message)
                ? "" : string.Format("{0}", TestContext.CurrentContext.Result.Message);

            var stackTrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)
                ? "" : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);

            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }

            Thread.Sleep(1000);
            test.Log(logstatus, "Test ended with " + logstatus + " Message: " + message + "<br/>" + stackTrace + "<br/><br/>", MediaEntityBuilder.CreateScreenCaptureFromPath(page.TakeScreenshot(SetUpFixtureBase.HTMLPath)).Build());

            page.TakeScreenshot(SetUpFixtureBase.HTMLPath);
            //page.CloseDriver();
            Thread.Sleep(1000);
        }
    }
}

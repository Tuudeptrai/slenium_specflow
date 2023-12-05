using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace selenium.StepDefinitions
{
    [Binding]
    public sealed class SpecflowHooks
    {
        private static ExtentReports extent;
        private static ExtentTest featureName;
        private static ExtentTest scenarioName;
        private string testResultPath;
        IWebDriver driver;
        [BeforeTestRun]

        public static void BeforeTestRun()
        {
            var htmlReporter = new ExtentHtmlReporter("C:\\data\\C#\\selenium\\report\\index.html");
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

            Console.WriteLine("in method before test run");
        }
        [AfterTestRun]
       

        public static void AfterTestRun()
        {

            extent.Flush();
            Console.WriteLine("in method after test run");
        }
        
        [BeforeFeature]

        public static void BeforeFeature()
        {
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
            Console.WriteLine("in method before Feature");
        }

        [AfterFeature]

        public static void AfterFeature()
        {
            Console.WriteLine("in method after Feature");
        }
        
        [BeforeScenario]

        public void BeforeScenario()
        {
            scenarioName = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
            Console.WriteLine("in method before Scenario");
        }

        [AfterScenario]

        public void AfterScenario()
        {

            Console.WriteLine("in method after Scenario");
        }

        [BeforeScenarioBlock]

        public void BeforeScenarioBlock()
        {
            Console.WriteLine("in method before Scenario Block");
        }

        [AfterScenarioBlock]

        public void AfterScenarioBlock()
        {
            Console.WriteLine("in method after Scenario Block");
        }
        [BeforeStep ]
        public void BeforeStep()
        {
            Console.WriteLine("in method before Step 1");
        }

        [AfterStep]
        public void AfterStep()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                {
                    scenarioName.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (stepType == "When")
                {
                    scenarioName.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (stepType == "Then")
                {
                    scenarioName.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                }
                else if (stepType == "And")
                {
                    scenarioName.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
                }
            }
            else
            {
                var errorMessage = ScenarioContext.Current.TestError.Message;

                // Mark the scenario as failed in the report
                scenarioName.Fail(errorMessage);

                // Create a node based on the step type
                var stepNode = CreateStepNode(stepType, ScenarioStepContext.Current.StepInfo.Text).Fail(errorMessage);

                // Capture and attach screenshot if applicable
                CaptureAndAttachScreenshot(stepNode);
            }
        }
        private ExtentTest CreateStepNode(string stepType, string stepText)
        {
            switch (stepType)
            {
                case "Given":
                    return scenarioName.CreateNode<Given>(stepText);
                case "When":
                    return scenarioName.CreateNode<When>(stepText);
                case "Then":
                    return scenarioName.CreateNode<Then>(stepText);
                case "And":
                    return scenarioName.CreateNode<And>(stepText);
                default:
                    throw new ArgumentOutOfRangeException(nameof(stepType), $"Unknown step type: {stepType}");
            }
        }
        private void CaptureAndAttachScreenshot(ExtentTest stepNode)
        {
            try
            {
                // Initialize WebDriver
                using (var driver = new ChromeDriver())
                {
                    // Capture screenshot
                    var screenshot = ((ITakesScreenshot)driver).GetScreenshot();

                    // Convert screenshot to base64 for embedding in the report
                    var base64Screenshot = screenshot.AsBase64EncodedString;

                    // Attach screenshot to the report
                    stepNode.AddScreenCaptureFromBase64String(base64Screenshot);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions if any
                Console.WriteLine($"Failed to capture and attach screenshot: {ex.Message}");
            }
        }

    }
}
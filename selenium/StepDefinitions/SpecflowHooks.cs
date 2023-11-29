using TechTalk.SpecFlow;

namespace selenium.StepDefinitions
{
    [Binding]
    public sealed class SpecflowHooks
    {
        [BeforeTestRun]

        public static void BeforeTestRun()
        {
            Console.WriteLine("in method before test run");
        }
        [AfterTestRun]

        public static void AfterTestRun()
        {
            Console.WriteLine("in method after test run");
        }
        
        [BeforeFeature]

        public static void BeforeFeature()
        {
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
        [BeforeStep]

        public void BeforeStep()
        {
            Console.WriteLine("in method before Step");
        }

        [AfterStep]

        public void AfterStep()
        {
            Console.WriteLine("in method after Step");
        }
    }
}
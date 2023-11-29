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
        [BeforeStep (Order =10)]
        [Scope(Tag = "smoke")]
        public void BeforeStep()
        {
            Console.WriteLine("in method before Step 1");
        }

        [AfterStep(Order = 10)]

        public void AfterStep()
        {
            Console.WriteLine("in method after Step 1");
        } 
        
        [BeforeStep(Order = 20)]

        public void BeforeStep2()
        {
            Console.WriteLine("in method before Step 2");
        }

        [AfterStep(Order = 20)]

        public void AfterStep2()
        {
            Console.WriteLine("in method after Step 2");
        }
    }
}
using System;
using TechTalk.SpecFlow;

namespace selenium.StepDefinitions
{
    [Binding]
    public class SearchGoogleStepDefinitions
    {
        [Given(@"Google page open")]
        public void GivenGooglePageOpen()
        {
            
        }

        [Given(@"search box should present and enable")]
        public void GivenSearchBoxShouldPresentAndEnable()
        {
            // comment ok here
        }

        [When(@"hit enter")]
        public void whenhitenter()
        {

        }

        [When(@"User search a course with key ""([^""]*)"" tutorial")]
        public void WhenUserSearchACourseWithKeyTutorial(string java)
        {
          
        }

        [Then(@"all course ""([^""]*)"" tutorial should be díplayed")]
        public void ThenAllCourseTutorialShouldBeDiplayed(string java)
        {
            
        }

    }
}

using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;


namespace selenium.StepDefinitions
{
    [Binding]
    public class FacebookHomePageLoginStepDefinitions
    {
        IWebDriver driver;
        [Given(@"User navigates to the Facebook home page")]
        public void GivenUserNavigatesToTheFacebookHomePage()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.facebook.com/");
        }

        [When(@"User enters test(.*) as username and pass(.*) as passwork")]
        public void WhenUserEntersTestAsUsernameAndPassAsPasswork(int p0, int p1)
        {
   
           driver.FindElement(By.Name("email")).SendKeys("Test#@123");
           driver.FindElement(By.Name("pass")).SendKeys("pass11");
        }

        [When(@"Click on the login button")]
        public void WhenClickOnTheLoginButton()
        {
            driver.FindElement(By.Name("login")).Click();
        }

        [Then(@"the login not successful")]
        public void ThenTheLoginNotSuccessful()
        {
            Console.WriteLine(driver.Title);
            String expectedTitle = "Log in to Facebook";
            String actualTitle = driver.Title;
            Assert.AreEqual(expectedTitle, actualTitle);
            driver.Quit();
        }
    }
}

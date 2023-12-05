using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;
using MongoDB.Driver.Core.Bindings;
using System.Threading;
using Microsoft.Extensions.Logging;
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
        [When(@"User enters ""([^""]*)"" as username and ""([^""]*)"" as password")]
        public void WhenUserEntersAsUsernameAndAsPassword(string p0, string p1)
        {

            driver.FindElement(By.Name("email")).SendKeys(p0);
            driver.FindElement(By.Name("pass")).SendKeys(p1);
        }


        [When(@"Click on the login button")]
        public void WhenClickOnTheLoginButton()
        {
            driver.FindElement(By.Name("login")).Click();
        }

        [Then(@"the login not successful")]
        public void ThenTheLoginNotSuccessful()
        {
            try
            {
                Console.WriteLine(driver.Title);
                String expectedTitle = "Log in to Facebook";
                String actualTitle = driver.Title;
                Console.WriteLine("đã tới chỗ này");
                Assert.That(actualTitle, Is.EqualTo(expectedTitle));
                Console.WriteLine("code ở chỗ này không có hiệu lực");
            }
            finally
            {
                // Code that should be executed regardless of whether the Assert passes or fails
                Thread.Sleep(5000);
                driver.Quit();
            }
        }




    }
}

using OpenQA.Selenium;
using CucumberTest.Pages;
using TechTalk.SpecFlow.Assist;
using OpenQA.Selenium.Edge;
using System.Xml.Linq;
using OpenQA.Selenium.Chrome;

namespace CucumberTest.StepDefinitions
{
    [Binding]
    public sealed class AddNewJWorkShiftDefinitions
    {
        IWebDriver webDriver = new ChromeDriver();

        [Given(@"User logged in with data")]
        public void GivenUserLoggedInWithData(Table table)
        {
            webDriver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            LogInPage logInPage = new LogInPage(webDriver);
            dynamic data = table.CreateDynamicInstance();
            logInPage.Login((string)data.UserName, (string)data.Password);
        }

        [When(@"User click on Admin")]
        public void WhenUserClickOnAdmin()
        {
            MainPage mainPage = new MainPage(webDriver);
            mainPage.GoToAdmin();
        }

        [When(@"User click on Work Shifts")]
        public void WhenUserClickOnWorkShifts()
        {
            MainPage mainPage = new MainPage(webDriver);
            mainPage.GoToWorkShifts();
        }

        [When(@"User click on Add")]
        public void WhenUserClickOnAdd()
        {
            MainPage mainPage = new MainPage(webDriver);
            mainPage.GoToAdd();
        }

        [When(@"User insert data")]
        public void WhenUserInsertData(Table table)
        {
            MainPage mainPage = new MainPage(webDriver);
            dynamic data = table.CreateDynamicInstance();
            mainPage.InsertAddData((string)data.ShiftName, (string)data.AssignedEmployees);
        }

        [When(@"User click on Save")]
        public void WhenUserClickOnSave()
        {
            MainPage mainPage = new MainPage(webDriver);
            mainPage.ClickSave();
        }

        [Then(@"User delete Work Shift")]
        public void ThenUserDeleteWorkShift()
        {
            MainPage mainPage = new MainPage(webDriver);
            mainPage.DeleteWorkShift();
        }
    }
}
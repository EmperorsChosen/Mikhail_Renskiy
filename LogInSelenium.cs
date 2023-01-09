using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace CucumberTest.Pages
{
    internal class LogInPage
    {
        public IWebDriver webDriver { get; }
        public IWebElement lnkLogin;
        public IWebElement txtUserName;
        public IWebElement txtPassword;
        public LogInPage(IWebDriver webDriver1)
        {
            webDriver = webDriver1;
        }

        private void Init()
        {
            Thread.Sleep(1500);
            lnkLogin = webDriver.FindElement(By.XPath("//button"));
            txtUserName = webDriver.FindElement(By.XPath("//input[@name='username']"));
            txtPassword = webDriver.FindElement(By.XPath("//input[@name='password']"));
        }

        public void Login(string userName, string password)
        {
            Init();
            txtPassword.SendKeys(password);
            txtUserName.SendKeys(userName);
            ClickLoginButton();
        }
        private void ClickLoginButton() => lnkLogin.Click();
    }
}
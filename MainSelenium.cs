using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CucumberTest.Pages
{
    internal class MainPage
    {

        private IWebDriver webDriver { get; }
        public MainPage(IWebDriver webDriver1)
        {
            webDriver = webDriver1;
        }


        private IWebElement lnkAdmin;
        public void GoToAdmin()
        {
            Thread.Sleep(1500);
            lnkAdmin = webDriver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[1]/aside/nav/div[2]/ul/li[1]/a/span"));
            lnkAdmin.Click();
        }


        private IWebElement lnkJob;
        private IWebElement lnkJobTitles;
        public void GoToWorkShifts()
        {
            Thread.Sleep(1000);
            lnkJob = webDriver.FindElement(By.XPath("/html/body/div/div[1]/div[1]/header/div[2]/nav/ul/li[2]/span/i"));
            lnkJob.Click();
            lnkJobTitles = webDriver.FindElement(By.XPath("/html/body/div/div[1]/div[1]/header/div[2]/nav/ul/li[2]/ul/li[5]/a"));
            lnkJobTitles.Click();
        }


        private IWebElement lnkAddJob;
        public void GoToAdd()
        {
            Thread.Sleep(1000);
            lnkAddJob = webDriver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/div[1]/div/button"));
            lnkAddJob.Click();
        }


        private IWebElement lnkShiftName;
        private IWebElement lnkAssignedEmployees;
        private IWebElement lnkWorkingFrom;
        private IWebElement lnkWorkingFromPointer;
        private IWebElement lnkWorkingTo;
        private IWebElement lnkWorkingToPointer;
        private IWebElement lnkEmployeePointer;
        public void InsertAddData(string ShiftName, string AssignedEmployees)
        {
            Thread.Sleep(1000);
            lnkShiftName = webDriver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[1]/div/div/div/div[2]/input"));
            lnkAssignedEmployees = webDriver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[3]/div/div/div/div[2]/div/div[1]/input"));
            lnkShiftName.SendKeys(ShiftName);
            lnkAssignedEmployees.SendKeys(AssignedEmployees);
            Thread.Sleep(2000);

            lnkEmployeePointer = webDriver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[3]/div/div/div/div[2]/div/div[2]"));
            lnkEmployeePointer.Click();


            lnkWorkingFrom = webDriver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[1]/div/div[2]/div/div[1]/input"));
            lnkWorkingFrom.Click();
            for(int i = 0; i < 3; i++)
            {
                lnkWorkingFromPointer = webDriver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[1]/div/div[2]/div/div[2]/div[1]/i[2]"));
                lnkWorkingFromPointer.Click();
            }

            lnkWorkingTo = webDriver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[2]/div/div[2]/div/div[1]/input"));
            lnkWorkingTo.Click();
            for (int i = 0; i < 1; i++)
            {
                lnkWorkingToPointer = webDriver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[2]/div/div[2]/div/div[2]/div[1]/i[1]"));
                lnkWorkingToPointer.Click();
            }

        }

        private IWebElement lnkSave;
        public void ClickSave()
        {
            lnkSave = webDriver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[4]/button[2]"));
            lnkSave.Click();
        }


        private IWebElement lnkDelete;
        private IWebElement lnkDeleteConfirm;
        public void DeleteWorkShift()
        {
            Thread.Sleep(4000);
            webDriver.Navigate().Refresh();
            Thread.Sleep(4000);
            lnkDelete = webDriver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/div[3]/div/div/div/div/div/div[1]/div[2]/div/div/button[1]/i"));
            lnkDelete.Click();

            Thread.Sleep(1000);

            lnkDeleteConfirm = webDriver.FindElement(By.XPath("/html/body/div/div[3]/div/div/div/div[3]/button[2]"));
            lnkDeleteConfirm.Click();
        }
        

    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace DataDrivenFinOps
{
    [TestClass]
    public class UnitTestFO
    {
        
        //[DynamicData(nameof(ReadExcelData), DynamicDataSourceType.Method)]
        [TestMethod]
        public void TestMethod1()
        {
            Random ran = new Random();
            int a = ran.Next();
            /*
            ScreenCaptureJob scj = new ScreenCaptureJob();
            scj.OutputScreenCaptureFileName = @"D:\Results\Test.avi";
            scj.Start(); */

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://autovmnew-3f614dab4e1a1230cdevaos.cloudax.dynamics.com/?cmp=usmf&mi=defaultdashboard";
            Thread.Sleep(3000);
            IWebElement emailTextField = driver.FindElement(By.XPath("//*[@name='loginfmt']"));
            emailTextField.SendKeys("Automated.Test1@saglobal.com");
            driver.FindElement(By.XPath("//*[@value='Next']")).Click();
            Thread.Sleep(3000);
            IWebElement passwordTextField = driver.FindElement(By.XPath("//*[@name='passwd']"));
            passwordTextField.SendKeys("5B33!6jYXTX8mSy");
            driver.FindElement(By.XPath("//*[@value='Sign in']")).Click();
            Thread.Sleep(3000);

            driver.FindElement(By.XPath("//*[@aria-label='Modules']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@data-dyn-title='Project management and accounting']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//button[@title='Collapse all']")).Click();
            Thread.Sleep(3000);

            driver.FindElement(By.XPath("//*[@aria-label='Projects']")).Click();
            driver.FindElement(By.XPath("//*[@data-dyn-title='All projects']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@name='ProjectNewButton']")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@name='Name']")).SendKeys("Sk "+a);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@name='ProjInvoiceId']")).SendKeys("000001");
            //SelectElement pc = new SelectElement(driver.FindElement(By.XPath("//*[@name='ProjInvoiceId']")));
            //pc.SelectByIndex(1);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@name='ProjectedStartDate']")).Click();
            driver.FindElement(By.XPath("//*[@name='ProjTable_WorkerResponsible_DirPerson_FK_Name']")).SendKeys("Jodi Christiansen");
            Thread.Sleep(3000); //name="ProjectedStartDate"
            driver.FindElement(By.XPath("//*[@name='ProjectedStartDate']")).Click();


            //driver.FindElement(By.XPath("//button[@name='NewProjectContract']")).Click();
            //Thread.Sleep(5000);
            //driver.FindElement(By.XPath("//*[@name='ProjFundingSource_FundingSourceId']")).SendKeys("000001");
            //SelectElement dropDown = new SelectElement(driver.FindElement(By.XPath("//*[@name='ProjFundingSource_FundingSourceId']"))).SelectByValue(aaaaa);

            //driver.FindElement(By.XPath("//*[@name='ProjFundingSource_FundingSourceId']")).SendKeys(dropDown);

            //dropDown.SelectByIndex(1);          
            //.SelectByValue(1);
            driver.FindElement(By.XPath("//span[text()='Create project']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//*[@data-dyn-controlname='HeaderHomeTab']")).Click();
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("((//*[@data-dyn-controlname='CtrlStages'])[1])")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@aria-label='In process']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@name='Ok']")).Click();
            Thread.Sleep(5000);
            //var stage = driver.FindElement(By.XPath("//*[@name='ProjStage_Stage']")).Text;
            //Assert.AreEqual(stage, "In process");
            driver.Quit();
            /*
            IWebElement p = driver.FindElement(By.XPath("//*[@name='ProjStage_Stage']"));
            //getText() to obtain text
            //p.GetAttribute();
            Assert.p(driver.FindElement(By.Name("ErrorBox")).Text, Is.EqualTo("Login failed")); */
        }
        //[TestMethod]
        public static IEnumerable<object[]> ReadExcelData()
        {
            using (ExcelPackage package = new ExcelPackage(new FileInfo("Data.xlsx")))
            {
                //get the first worksheet in the workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"];
                int rowCount = worksheet.Dimension.End.Row;     //get row count
                for (int i = 2; i <= rowCount; i++)
                {
                    yield return new object[] {
                        worksheet.Cells[i, 1].Value?.ToString().Trim(), // Email
                        worksheet.Cells[i, 2].Value?.ToString().Trim() // Pass
                    };
                }
            }
        }
    }
}

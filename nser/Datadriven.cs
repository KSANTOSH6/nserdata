
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OfficeOpenXml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace nser
{
    /*
    internal class Program
    {
        public static void Main(string[] args)
        {
            Datadriven ab = new Datadriven();
            string s = ab.DataDrivenTest();
            con
        }
    } */
    [TestClass]
    public class Datadriven
    {
        //Email email;
        //private string Email = email;
        //private string Password = password;
        [DynamicData(nameof(ReadExcel), DynamicDataSourceType.Method)]
        [TestMethod]
        public void DataDrivenTest(string email, string password)
        {

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://www.facebook.com/";

            driver.FindElement(By.Id("email")).SendKeys(email);
            driver.FindElement(By.XPath("//*[@aria-label='Password']")).SendKeys(password);
            driver.FindElement(By.XPath("//*[@name='login']")).Click();
            driver.Quit();
        }
        /*
        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] { "Narendra", "Modi"};
            yield return new object[] { "donald", "trump"};
        }
        */
        public static IEnumerable<object[]> ReadExcel()
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

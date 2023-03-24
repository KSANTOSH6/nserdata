using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Packaging;
using System.Threading;

namespace DataDriven
{
    [TestClass]
    public class UnitTest1
    {
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
            Thread.Sleep(5000);
            driver.Quit();
        }
        /*
        public static IEnumerable<object[]> ReadExcel()
        {
                using (ExcelPackage package = new ExcelPackage(new FileInfo("Data.xlsx"))) ;
                //ExcelPackage package = new ExcelPackage(new FileInfo("Data.xlsx"));
                //get the first worksheet in the workbook
                //ExcelWorksheet worksheet = ExcelPackage.
                ExcelWorksheet worksheet = Package.Workbook.Worksheets["Sheet1"];
                int rowCount = worksheet.Dimension.End.Row;     //get row count
                for (int i = 2; i <= rowCount; i++)
                {
                    yield return new object[] {
                        worksheet.Cells[i, 1].Value?.ToString().Trim(), // Email
                        worksheet.Cells[i, 2].Value?.ToString().Trim() // Pass
                    };
                }
        }
        */

        public static IEnumerable<object[]> ReadExcel()
        {
            using (ExcelPackage package = new ExcelPackage(new FileInfo("data.xlsx")))
            {
                //get the first worksheet in the workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"];
                int rowCount = worksheet.Dimension.End.Row;     //get row count
                for (int i = 2; i <= rowCount; i++)
                {
                    yield return new object[] {
                        worksheet.Cells[i, 1].Value?.ToString().Trim(),
                        worksheet.Cells[i, 2].Value?.ToString().Trim()
                        //worksheet.Cells[row, 3].Value?.ToString().Trim() 
                    };
                }
            }
        }
/*
        public static m1(string i, string ii)
        {
            return i;
        }
*/
    }
}
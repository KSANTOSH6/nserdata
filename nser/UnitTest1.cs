using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace nser
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestDemo1()
        {

            /*
            public static ExtentTest test;
            public static ExtentReports extent;

            [SetUp]
            public void Initialize()
            {
                driver = new ChromeDriver();
            }
            [OneTimeSetUp]
            public void ExtentStart()
            {

                extent = new ExtentReports();
                var htmlreporter = new ExtentHtmlReporter(@"D:\ReportResults\Report" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
                extent.AttachReporter(htmlreporter);

            }
            [Test]
            public void BrowserTest()
            {
                test = null;
                test = extent.CreateTest("T001").Info("Login Test");

                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://www.facebook.com/");
                test.Log(Status.Info, "Go to URL");

                //provide username
                //driver.FindElement(By.Id("usr")).SendKeys("admin");
                ///IWebElement username = driver.FindElement(By.XPath("//*[@name='email']"));//.SendKeys("SantoshK");
                ///username.SendKeys("SantoshK");
                //provide password
                //driver.FindElement(By.Id("pwd")).SendKeys("12345");
                IWebElement password = driver.FindElement(By.XPath("//*[@name='pass']"));//.SendKeys("alpha");
                password.SendKeys("alpha1234");
                //submit
                driver.FindElement(By.XPath("//button[@type='submit']")).Click();
                
                try
                {
                    //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
                    //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h3[contains(.,'WELCOME :)')]")));
                    //Test Result
                    // test.Log(Status.Pass, "Test Pass");
                    //WebDriver 

                    driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                    driver.Url = "https://www.facebook.com/";
                    IWebElement username = driver.FindElement(By.XPath(".//*[@name='email']"));//.SendKeys("SantoshK");
                    username.SendKeys("SantoshK");
                    driver.Quit();
                }

                catch (Exception e)
                {
                    throw;
                }
                finally
                {
                    if (driver != null)
                    {
                        driver.Quit();
                    }
                }
        //}
            /*
            [TearDown]
            public void closeBrowser()
            {
                driver.Close();
            }

            [OneTimeTearDown]
            public void ExtentClose()
            {
                extent.Flush();
            }
            */
            IWebDriver driver = null;
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("www.facebook.com");

            IWebElement dataone = driver.FindElement(By.XPath(""));



        }
    }
}

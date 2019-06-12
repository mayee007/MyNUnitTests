using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.Collections.Generic;

namespace MyNUnitTests
{
    [Category("guiTests")]
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class GoogleMainPageTestInputData
    {
        IWebDriver driver;
        String url;
        ChromeOptions options; 

        [OneTimeSetUp]
        public void setup()
        {
            // to run chrome headless 
            options = new ChromeOptions();
            options.AddArgument("--headless");
            
            //driver = new ChromeDriver(); // this pops up windows
            url = "http://google.com";
        }

        [SetUp]
        public void createChromeDriverBeforeEachTest()
        {
            driver = new ChromeDriver(options);
            //driver = new ChromeDriver(); // this pops up windows
        }

        private static IEnumerable<TestCaseData> TitleTestCases()
        {
            yield return new TestCaseData("Google", true);
            yield return new TestCaseData("google", false);
            yield return new TestCaseData("", false);
            yield return new TestCaseData("Googleeee", false);
            yield return new TestCaseData("         ", false);
        }

        // method 2 - more test cases 
        [Test, TestCaseSource("TitleTestCases")]
        [Timeout(20000)] //20 seconds
        public void getTitleTestMethod3(String title, Boolean status)
        {
            driver.Navigate().GoToUrl(url);
            String actualTitle = driver.Title;
            driver.Close(); //closes window  
            
            Assert.AreEqual(actualTitle.Equals(title) , status); 
        }

        [OneTimeTearDown]
        public void cleanup()
        {
            driver.Quit();
        }
    } // end of class
}
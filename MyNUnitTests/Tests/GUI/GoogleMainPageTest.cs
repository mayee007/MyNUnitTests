using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace MyNUnitTests
{
    [Category("guiTests")]
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class GoogleMainPageTest
    {
        IWebDriver driver;
        String url;
        String title;

        [SetUp]
        public void setup()
        {
            // to run chrome headless 
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless"); 
            driver = new ChromeDriver(options);

            //driver = new ChromeDriver(); // this pops up windows
            url = "http://google.com";
            title = "Google";
        }

        [TestCase, Timeout(10000)] // 10 seconds max time limit 
        [Repeat(5)] // repeat this test 5 times 
        public void openHomePageTest()
        {
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize(); // maximizes window       
            driver.Close(); //closes window                              
        }

        [TestCase, Repeat(5)] // method 1 - simple 
                              // repeat this test 5 times 
        public void getTitleTest()
        {
            driver.Navigate().GoToUrl(url);
            Assert.AreEqual(title, driver.Title);
            driver.Close(); //closes window                              
        }

        // method 2 - more test cases 
        [TestCase("Google", ExpectedResult = true)]
        [TestCase("google", ExpectedResult = false)]
        [TestCase("", ExpectedResult = false)]
        [TestCase("Googleeeeee", ExpectedResult = false)]
        [Timeout(20000)] //20 seconds
        public Boolean getTitleTestMethod2(String title)
        {
            driver.Navigate().GoToUrl(url);
            String actualTitle = driver.Title;
            driver.Close(); //closes window  
            
            return actualTitle.Equals(title); 
        }

        [TearDown]
        public void cleanup()
        {
            driver.Quit();
        }
    } // end of class
}
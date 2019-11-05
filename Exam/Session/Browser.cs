using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace Exam.Session
{
    public class Browser
    {
        public readonly string _browser = "Chrome";

        public Browser()
        {
            _browser = "Chrome";
        }

        public IWebDriver Build()
        {
            IWebDriver driver;

            if (_browser == "Chrome")
            {
                var options = new ChromeOptions();
                options.AddArgument("start-maximized"); //open full-screen
                driver = new ChromeDriver(Directory.GetCurrentDirectory(), options);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            }
            else
            {
                return null;
            }
            return driver;
        }
    }
}
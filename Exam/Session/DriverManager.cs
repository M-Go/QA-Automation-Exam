using Exam.Tests;
using Exam.Utils;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace Exam.Session
{
    public static class DriverManager
    {
        public static ThreadLocal<IWebDriver> Driver { get; set; } = new ThreadLocal<IWebDriver>();


        //public static void SetDriver(IWebDriver driver)
        //{
        //    _Driver.Value = driver;
        //}

        //public static IWebDriver GetDriver()
        //{
        //    return _Driver.Value;
        //}

        public static IJavaScriptExecutor GetJSExecutor()
        {
            return (IJavaScriptExecutor)Driver.Value;
        }




        public static void SetToken(string token)
        {
            Thread.Sleep(TimeSpan.FromSeconds(10));
            LocalStorage localStorage = new LocalStorage(Driver.Value);
            Thread.Sleep(TimeSpan.FromSeconds(10));
            localStorage.SetItemInLocalStorage("token", token);
            var findToken = localStorage.GetItemFromLocalStorage("token");
        }
    }
}
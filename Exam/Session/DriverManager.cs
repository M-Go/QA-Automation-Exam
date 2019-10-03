using Exam.Tests;
using OpenQA.Selenium;
using System.Threading;

namespace Exam.Session
{
    public static class DriverManager
    {
        public static ThreadLocal<IWebDriver> Driver { get; set; } = new ThreadLocal<IWebDriver>();

        public static void SetToken(string token)
        {
            ChromeLocalStorage localStorage = new ChromeLocalStorage(Driver.Value);
            localStorage.SetItemInLocalStorage("token", token);
            string getToken = localStorage.GetItemFromLocalStorage("token");
        }
    }
}
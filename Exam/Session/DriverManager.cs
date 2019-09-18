using Exam.Utils;
using OpenQA.Selenium;
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

        public static void SetToken()
        {
            var token = TokenManager.GetToken();

            //Driver.Cookie apply(token);
        }
    }
}
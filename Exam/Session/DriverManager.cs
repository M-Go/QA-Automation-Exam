using OpenQA.Selenium;
using System.Threading;

namespace Exam.Session
{
    public static class DriverManager
    {
        public static readonly ThreadLocal<IWebDriver> _Driver = new ThreadLocal<IWebDriver>();

        public static void SetDriver(IWebDriver driver)
        {
            _Driver.Value = driver;
        }

        public static IWebDriver GetDriver()
        {
            return _Driver.Value;
        }

        public static IJavaScriptExecutor GetJSExecutor()
        {
            return (IJavaScriptExecutor)_Driver.Value;
        }
    }
}
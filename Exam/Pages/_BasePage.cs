using Exam.Session;
using OpenQA.Selenium;

namespace Exam.Pages
{
    public class _BasePage
    {
        public IWebDriver _driver = DriverManager.GetDriver();
    }
}
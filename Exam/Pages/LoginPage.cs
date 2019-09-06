using OpenQA.Selenium;

namespace Exam.Pages
{
    public class LoginPage : _BasePage
    {
        private IWebElement _username => _driver.FindElement(By.XPath("//div/input[@placeholder='Username']"));
        private IWebElement _password => _driver.FindElement(By.XPath("//div/input[@placeholder='Password']"));
        private IWebElement _signIn => _driver.FindElement(By.XPath("//div/button[@type='submit']"));

        public LoginPage()
        {
            _driver.Url = "http://backoffice.kube.private/login";
        }

        public LoginPage Login()
        {
            _username.SendKeys("admin@betlab");
            _password.SendKeys("abc");
            _signIn.Click();
            return this;
        }
    }
}
using Exam.Pages;
using Exam.Session;

namespace Exam.Utils
{
    public class Login
    {
        private LoginPage _loginPage;

        public void LoginViaApi(string destination)
        {
            DriverManager.Driver.Value.Url = $"http://backoffice.kube.private{destination}";
            DriverManager.SetToken(TokenManager.GetToken());
        }

        public void LoginViaFrontend()
        {
            _loginPage = new LoginPage();
            _loginPage.Login();
        }
    }
}
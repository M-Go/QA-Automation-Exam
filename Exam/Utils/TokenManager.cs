using Exam.BackendClients;
using Exam.Models;

namespace Exam.Utils
{
    public static class TokenManager
    {
        private static string _token;

        public static string GetToken()
        {

            if (string.IsNullOrEmpty(_token))
            {
                LoginRequestModel loginRequest = new LoginRequestModel();
                var includeAttributes = new[] { "perm.*" };
                loginRequest.IncludeAttributes = includeAttributes;
                loginRequest.UserName = "admin@betlab";
                loginRequest.Password = "abc";
                _token = new SsoClient().GetSsoResponse(loginRequest).Token;
                return _token;
            }
            return _token;
        }
    }
}
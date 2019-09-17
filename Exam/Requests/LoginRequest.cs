using Exam.DataProvider;
using Exam.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Exam.Requests
{
    public class LoginRequest
    {
        private ApiClient _login;
        private string _token = TokenManager.GetToken();

        public LoginRequest()
        {
            _login = new ApiClient("http://backoffice.kube.private");
        }

        public string LoginToSettlementMonitor()
        {
            var response = _login.Post("/api/sso-operator/Login", "{\"includeAttributes\":[\"perm.*\"],\"userName\":\"admin@betlab\",\"password\":\"abc\"}"); //JsonConvert.SerializeObject(new LoginProvider()));
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Cannot get token");
            }
            var result = response.Content.ReadAsStringAsync().Result;
            var resultJObject = JsonConvert.DeserializeObject<JObject>(result);
            var token = resultJObject["token"].ToString();
            return token;
        }
    }
}
using Exam.Models;
using Exam.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.BackendSide
{
    public class SsoClient
    {
        private ApiClient _baseClient;

        public SsoClient()
        {
            _baseClient = new ApiClient("http://backoffice.kube.private");
        }

        public LoginResponse GetSsoResponse()
        {
            var response = _baseClient.Post("api/sso-operator/Login", "{\"includeAttributes\":[\"perm.*\"],\"userName\":\"admin@betlab\",\"password\":\"abc\"}"); //JsonConvert.SerializeObject(new LoginProvider()));
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Authorization failed");
            }
            var result = response.Content.ReadAsStringAsync().Result;
            LoginResponse resultJObject = JsonConvert.DeserializeObject<LoginResponse>(result);
            string token = resultJObject.Token.ToString();
            return resultJObject;
        }
    }
}
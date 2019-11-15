using Exam.Models;
using Exam.Utils;
using Newtonsoft.Json;
using System;

namespace Exam.BackendClients
{
    public class SsoClient
    {
        private ApiClient _baseClient;

        public SsoClient()
        {
            _baseClient = new ApiClient("http://backoffice.kube.private");
        }

        public LoginResponseModel GetSsoResponse(LoginRequestModel request)
        {
            var jsonBody = JsonConvert.SerializeObject(request);
            var response = _baseClient.Post("api/sso-operator/Login", jsonBody);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Authorization failed");
            }
            var result = response.Content.ReadAsStringAsync().Result;
            LoginResponseModel resultJObject = JsonConvert.DeserializeObject<LoginResponseModel>(result);
            string token = resultJObject.Token.ToString();
            return resultJObject;
        }
    }
}
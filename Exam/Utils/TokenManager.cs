using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using Exam.DataProvider;

namespace Exam.Utils
{
    public static class TokenManager
    {
        private static string _token;

        public static string GetToken()
        {
            if (string.IsNullOrEmpty(_token))
            {
                _token = Authorize();
                return _token;
            }
            return _token;
        }

        private static string Authorize()
        {
            ApiClient client = new ApiClient("http://backoffice.hp.consul");

            var response = client.Post("api/sso-operator/Login", "{\"includeAttributes\":[\"perm.*\"],\"userName\":\"admin@betlab\",\"password\":\"abc\"}"); //JsonConvert.SerializeObject(new LoginProvider()));
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Authorization failed");
            }
            var result = response.Content.ReadAsStringAsync().Result;
            var resultJObject = JsonConvert.DeserializeObject<JObject>(result);
            var token = resultJObject["token"].ToString();
            return token;
        }
    }
}
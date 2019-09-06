using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Exam.Utils
{
    public class ApiClient
    {
        HttpClient _client;

        public ApiClient(string host)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(host);
        }

        public HttpResponseMessage Post(string requestUri, string jsonObject)
        {
            var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
            var result = _client.PostAsync(requestUri, content).GetAwaiter().GetResult();
            return result;
        }

        public HttpResponseMessage Get(string requestUri, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("token", token);
            var result = _client.GetAsync(requestUri).GetAwaiter().GetResult();
            return result;
        }
    }
}
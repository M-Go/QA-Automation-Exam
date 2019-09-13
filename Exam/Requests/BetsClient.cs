using Exam.DataProvider;
using Exam.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;

namespace Exam.Requests
{
    public class BetsClient
    {
        private ApiClient _backoffice;

        public BetsClient()
        {
            _backoffice = new ApiClient("http://backoffice.kube.private");
        }

        public JArray ReceiveBets()
        {
            var response = _backoffice.Post("/api/betview-service/bets/", "{\"inFilter\":{\"segmentIds\":[0],\"channels\":[\"MOBILE_WEB\"],\"outcomeKeys\":[]},\"oDataFilter\":\"(eventId eq '520012') and (acceptTime ge 2019-08-26T21:00:00.000Z) and (acceptTime lt 2019-09-13T11:00:53.672Z) and (betBaseAmount ge 1)\",\"take\":50}"); //JsonConvert.SerializeObject(new LoginProvider()));
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Cannot get bets");
            }
            var result = response.Content.ReadAsStringAsync().Result;
            var resultJObject = JsonConvert.DeserializeObject<JArray>(result);
            return resultJObject;
        }
    }
}
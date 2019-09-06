using Exam.DataProvider;
using Exam.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Text;

namespace Exam.Requests
{
    public class BetsRequest
    {
        private ApiClient _bets;

        public BetsRequest()
        {
            _bets = new ApiClient("http://backoffice.kube.private");
        }

        public BetsRequest Bets()
        {
            var request = _bets.Post("/api/betview-service/bets/", "{“inFilter”:{“segmentIds”:[0],“channels”:[“MOBILE_WEB”],“outcomeKeys”:[]},“oDataFilter”:“(eventId eq ‘520012’) and (acceptTime ge 2019-08-26T21:00:00.000Z) and (acceptTime lt 2019-09-06T07:25:12.027Z) and (betBaseAmount ge 1)“,”take”:50}"); //JsonConvert.SerializeObject(new LoginProvider()));
            if (!request.IsSuccessStatusCode)
            {
                throw new Exception("Cannot get bets");
            }
            var result = request.Content.ReadAsStringAsync().Result;
            var resultJObject = JsonConvert.DeserializeObject<JObject>(result);
            //var token = resultJObject["token"];
            return this;
        }
    }
}
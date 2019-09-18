using Exam.DataProvider;
using Exam.Models;
using Exam.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Exam.BackendSide
{
    public class BetsClient
    {
        private ApiClient _backoffice;

        public BetsClient()
        {
            _backoffice = new ApiClient("http://backoffice.kube.private");
            _backoffice.SetToken(TokenManager.GetToken());
        }

        public List<BetsResponse> GetBets()
        {
            var response = _backoffice.Post("/api/betview-service/bets/", "{\"inFilter\":{\"segmentIds\":[0],\"channels\":[\"MOBILE_WEB\"],\"outcomeKeys\":[]},\"oDataFilter\":\"(eventId eq '520012') and (acceptTime ge 2019-08-26T21:00:00.000Z) and (acceptTime lt 2019-09-13T11:00:53.672Z) and (betBaseAmount ge 1)\",\"take\":50}"); //JsonConvert.SerializeObject(new LoginProvider()));
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Cannot get bets");
            }
            var result = response.Content.ReadAsStringAsync().Result;
            List<BetsResponse> resultJObject = JsonConvert.DeserializeObject<List<BetsResponse>>(result);
            return resultJObject;
        }

        //public string GetAcceptTime()
        //{
        //    BetsClient betRequest = new BetsClient();
        //    List<BetsResponse> a = betRequest.GetBets();
        //    string acceptTime = a[0].AcceptTime;
        //    return acceptTime;
        //}

        //public string GetChannel()
        //{
        //    BetsClient betRequest = new BetsClient();
        //    List<BetsResponse> a = betRequest.GetBets();
        //    string channel = a[0].Channel;
        //    return channel;
        //}
    }
}
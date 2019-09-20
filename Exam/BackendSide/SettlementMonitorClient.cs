﻿using Exam.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.BackendSide
{
    public class SettlementMonitorClient
    {
        private ApiClient _backoffice;

        public SettlementMonitorClient()
        {
            _backoffice = new ApiClient("http://backoffice.kube.private");
            _backoffice.SetToken(TokenManager.GetToken());
        }

        //public List<BetsResponse> GetBets()
        //{
        //    var response = _backoffice.Post("/api/betview-service/bets/", "{\"inFilter\":{\"segmentIds\":[0],\"channels\":[\"MOBILE_WEB\"],\"outcomeKeys\":[]},\"oDataFilter\":\"(eventId eq '520012') and (acceptTime ge 2019-08-26T21:00:00.000Z) and (acceptTime lt 2019-09-13T11:00:53.672Z) and (betBaseAmount ge 1)\",\"take\":50}"); //JsonConvert.SerializeObject(new LoginProvider()));
        //    if (!response.IsSuccessStatusCode)
        //    {
        //        throw new Exception("Cannot get bets");
        //    }
        //    var result = response.Content.ReadAsStringAsync().Result;
        //    List<BetsResponse> resultJObject = JsonConvert.DeserializeObject<List<BetsResponse>>(result);
        //    return resultJObject;
        //}

    }
}
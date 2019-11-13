using Exam.Models;
using Exam.Models.Filtering;
using Exam.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Exam.BackendClients
{
    public class BetsClient
    {
        private ApiClient _backoffice;

        public BetsClient()
        {
            _backoffice = new ApiClient("http://backoffice.kube.private");
            _backoffice.SetToken(TokenManager.GetToken());
        }

        public List<BetsResponse> GetBets(FilteringRequest request)
        {

            var jsonBody = JsonConvert.SerializeObject(request);
            var response = _backoffice.Post("/api/betview-service/bets/", jsonBody);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Cannot get bets");
            }
            var result = response.Content.ReadAsStringAsync().Result;
            List<BetsResponse> resultJObject = JsonConvert.DeserializeObject<List<BetsResponse>>(result);
            return resultJObject;
        }
    }
}
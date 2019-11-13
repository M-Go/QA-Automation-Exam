using Exam.BackendClients;
using Exam.Models;
using Exam.Models.Filtering;
using Exam.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.Tests
{
    [TestFixture]
    public class BetsMonitorBackendTests : _BaseUITest
    {
        [SetUp]
        public void BeforeTest()
        {
            Login loginViaApi = new Login();
            loginViaApi.LoginViaApi("/monitors/bets/");
        }

        [TestCase("929297369", "2019-08-26T21:00:00.000Z")]
        [TestCase("005097235", "2019-11-07T21:00:00.000Z")]
        public void VerifyPlayerIds(string playerId, string acceptTime)
        {
            BetsClient client = new BetsClient();
            FilteringRequest betsRequest = new FilteringRequest();
            InFilterModel inFilter = new InFilterModel();
            var playerIds = new  [] {playerId};
            inFilter.PlayerIds = playerIds;
            betsRequest.InFilter = inFilter;
            betsRequest.ODataFilter = $"(acceptTime ge {acceptTime})";            
            betsRequest.Take = 50;
            List<BetsResponse> betsResponse = client.GetBets(betsRequest);
            var allPlayerIds = from bet in betsResponse select bet.PlayerId; //Distinct();
            bool playerIdComparisonResult = allPlayerIds.All(id => id.Equals(playerId));

            Assert.IsTrue(playerIdComparisonResult, "Player IDs do not match");
        }

        [TestCase("929297369", "2019-08-26T21:00:00.000Z")]
        [TestCase("005097235", "2019-11-07T21:00:00.000Z")]
        public void VerifyBetDates(string playerId, string betTime)
        {
            BetsClient client = new BetsClient();
            FilteringRequest betsRequest = new FilteringRequest();
            InFilterModel inFilter = new InFilterModel();
            var playerIds = new[] { playerId };
            inFilter.PlayerIds = playerIds;
            betsRequest.InFilter = inFilter;
            betsRequest.ODataFilter = $"(acceptTime ge {betTime})";
            betsRequest.Take = 50;
            List<BetsResponse> betsResponse = client.GetBets(betsRequest);
            var allAcceptTimes = from bet in betsResponse select bet.AcceptTime;
            DateTime givenAcceptTime = DateTime.Parse(betTime);
            var allAcceptTimesInDateTime = allAcceptTimes.Select(time => DateTime.Parse(time));
            bool dateComparisonResult = allAcceptTimesInDateTime.All(time => time > givenAcceptTime);

            Assert.IsTrue(dateComparisonResult, "Bet date does not match");
        }
    }
}
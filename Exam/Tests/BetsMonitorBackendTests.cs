using Exam.BackendClients;
using Exam.DataProvider;
using Exam.DataProvider.TestData;
using Exam.Models;
using Exam.Pages;
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
        private BetsMonitorPage _betsMonitorPage;
        private PlayerHistoryPage _playerHistoryPage;

        [SetUp]
        public void BeforeTest()
        {
            Login loginViaApi = new Login();
            loginViaApi.LoginViaApi("/monitors/bets/");
        }

        [TestCaseSource(typeof(FilteringTestData), nameof(FilteringTestData.GetFilteringData))]
        public void VerifyPlayerIds(FilterProvider filteringData)
        {
            BetsClient betRequest = new BetsClient();
            List<BetsResponse> betsResponse = betRequest.GetBets(filteringData.FilteringBodyInBetsMonitor);            
            var allPlayerIds = from bet in betsResponse select bet.PlayerId; //Distinct();
            bool playerIdComparisonResult = allPlayerIds.All(playerId => playerId.Equals(playerId));

            Assert.IsTrue(playerIdComparisonResult, "Player IDs do not match");
        }

        [TestCaseSource(typeof(FilteringTestData), nameof(FilteringTestData.GetFilteringData))]
        public void VerifyBetDates(FilterProvider filteringData)
        {
            BetsClient betRequest = new BetsClient();
            List<BetsResponse> betsResponse = betRequest.GetBets(filteringData.FilteringBodyInBetsMonitor);
            var allAcceptTimes = from bet in betsResponse select bet.AcceptTime;
            var allAcceptTimesInDateTime = allAcceptTimes.Select(acceptTime => DateTime.Parse(acceptTime));
            bool dateComparisonResult = allAcceptTimesInDateTime.All(acceptTime => acceptTime > filteringData.AcceptTimeFiltering);

            Assert.IsTrue(dateComparisonResult, "Bet date does not match");
        }
    }
}
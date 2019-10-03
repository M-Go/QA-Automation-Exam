using Exam.BackendClients;
using Exam.DataProvider;
using Exam.DataProvider.TestData;
using Exam.Models;
using Exam.Pages;
using Exam.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Tests
{
    [TestFixture]
    public class BetsMonitorFrontendTests
    {
        private BetsMonitorPage _betsMonitorPage;
        private PlayerHistoryPage _playerHistoryPage;

        [SetUp]
        public void BeforeTest()
        {
            Login loginViaApi = new Login();
            loginViaApi.LoginViaApi("/monitors/bets/");
        }

        [Test]
        public void NavigateToPlayerHistoryFromBetsMonitor()
        {
            _betsMonitorPage = new BetsMonitorPage();
            _betsMonitorPage
                .FilterBetsByAcceptTimeAndPlayerId("27.08.2019 00:00:00", "929297369")
                .NavigateToPlayerHistoryPage();
            _playerHistoryPage = new PlayerHistoryPage();

            Assert.AreEqual("929297369", _playerHistoryPage.GetPlayerId(), "Player ID does not match");
        }

        [TestCaseSource(typeof(FilteringTestData), nameof(FilteringTestData.GetFilteringData))]
        public void VerifyEventNames(FilterProvider filteringData)
        {
            _betsMonitorPage = new BetsMonitorPage();
            _betsMonitorPage
                .FilterBetsByAcceptTimeAndPlayerId(filteringData.Date, filteringData.PlayerId);


            BetsClient betRequest = new BetsClient();
            List<BetsResponse> betsResponse = betRequest.GetBets(filteringData.FilteringBodyInBetsMonitor);
            //List<string> playerIds = new List<string>();
            var ids = from bet in betsResponse select bet.PlayerId;

            //int betsCount = betsResponse.Count();

            //int i = 0;
            //while (i <= betsCount)
            //{
            //    playerIds.Add(betsResponse[i].PlayerId);
            //    i++;
            //}



            //foreach (BetsResponse playerId in betsResponse)
            //{
            //    playerIds.Add(betsResponse.PlayerId);
            //}
            //for (int i = 0; i <= betsCount; i++)
            //{
            //    playerIds.Add(betsResponse[i].PlayerId);
            //}
            //    Console.WriteLine(ids);



            //    Assert.AreEqual("929297369", actualPlayerIdsDist, "Player IDs do not match");
            //}
        }
    }
}
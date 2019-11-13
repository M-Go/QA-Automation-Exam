using Exam.BackendClients;
using Exam.DataProvider;
using Exam.DataProvider.TestData;
using Exam.Models;
using Exam.Models.Filtering;
using Exam.Pages;
using Exam.Utils;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Exam.Tests
{
    [TestFixture]
    public class BetsMonitorFrontendTests : _BaseUITest
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
        public void NavigateToPlayerHistoryFromBetsMonitor(FilterProvider filteringData)
        {
            _betsMonitorPage = new BetsMonitorPage();
            _betsMonitorPage
                .FilterBetsByAcceptTimeAndPlayerId(filteringData.Date, filteringData.PlayerId)
                .NavigateToPlayerHistoryPage();
            _playerHistoryPage = new PlayerHistoryPage();

            Assert.AreEqual(filteringData.PlayerId, _playerHistoryPage.GetPlayerId(), "Player ID does not match");
        }

        [TestCase(0, "MOBILE_WEB", "2019 -08-26T21:00:00.000Z")]
        public void VerifyEventNames(int segment, string channel, string acceptTime)
        {
            BetsClient client = new BetsClient();
            FilteringRequest betsRequest = new FilteringRequest();
            InFilterModel inFilter = new InFilterModel();
            var segments = new[] { segment };
            inFilter.SegmentIds = segments;
            var channels = new[] { channel };           
            inFilter.Channels = channels;
            betsRequest.InFilter = inFilter;

            //oDataFilter\":\"(eventId eq '520012') and (acceptTime ge 2019-08-26T21:00:00.000Z) and (acceptTime lt 2019-09-13T11:00:53.672Z) and (betBaseAmount ge 1)
            betsRequest.ODataFilter = $"(acceptTime ge {acceptTime})";
            betsRequest.Take = 50;
            List<BetsResponse> betsResponse = client.GetBets(betsRequest);

            
            var allEventNamesFromResponse = from bet in betsResponse select bet.EventName;
            var validEventNamesFromResponse = allEventNamesFromResponse.Where(name => name != null).ToList();

            _betsMonitorPage = new BetsMonitorPage();
            _betsMonitorPage
                .FilterBetsByAcceptTimeAndPlayerId(filteringData.Date, filteringData.PlayerId);

            var allEventNamesFromUi = _betsMonitorPage.GetEventNames();
            var validEventNamesFromUi = allEventNamesFromResponse.Where(name => name != null).ToList();


            //bool eventNamesComparisonResult = Enumerable.SequenceEqual(allEventNamesFromResponse, allEventNamesFromUi);

            CollectionAssert.AreEqual(validEventNamesFromResponse, validEventNamesFromUi, "Event names do not match");
            //IsTrue(eventNamesComparisonResult, "Event names do not match");


            //Compare events amount

            ////List<string> playerIds = new List<string>();
            //var ids = from bet in betsResponse select bet.PlayerId;

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
        }
    }
}
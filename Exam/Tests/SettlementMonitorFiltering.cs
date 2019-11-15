using Exam.Models;
using Exam.Pages;
using Exam.BackendClients;
using NUnit.Framework;
using System.Collections.Generic;
using Exam.Utils;
using Exam.Models.Filtering;

namespace Exam.Tests
{
    [TestFixture]
    public class SettlementMonitorFiltering : _BaseUITest
    {
        private SettlementMonitorPage _settlementMonitorPage;
        private PlayerHistoryPage _playerHistoryPage;

        [SetUp]
        public void BeforeTest()
        {
            Login loginViaApi = new Login();
            loginViaApi.LoginViaApi("/monitors/settlement/");
        }

        [TestCase("28.08.19 - 03.09.19", "ЦСКА", "27.08.2019 00:00:00", "1", "10", "Mobile", "929297369")]
        public void NavigateToPlayerHistoryFromSettlementMonitor(string eventsDate, string text, string betsDate, string betsAmountFrom, string betsAmountTo, string channel, string playerId)
        {
            _settlementMonitorPage = new SettlementMonitorPage();
            _settlementMonitorPage
                .SelectDate(eventsDate)
                .SearchEventByText(text)
                .NavigateIntoEvent()
                .FilterBets(betsDate, betsAmountFrom, betsAmountTo, channel)
                .NavigateToPlayerHistoryPage();
            _playerHistoryPage = new PlayerHistoryPage();

            Assert.AreEqual(playerId, _playerHistoryPage.GetPlayerId(), "Player ID does not match");
        }

        [TestCase("28.08.19 - 03.09.19", "ЦСКА", "27.08.2019 00:00:00", "1", "10", "Mobile")]
        public void VerifyBetDate(string eventsDate, string text, string betsDate, string betsAmountFrom, string betsAmountTo, string channel)
        {
            _settlementMonitorPage = new SettlementMonitorPage();
            _settlementMonitorPage
                .SelectDate(eventsDate)
                .SearchEventByText(text)
                .NavigateIntoEvent()
                .FilterBets(betsDate, betsAmountFrom, betsAmountTo, channel);

            Assert.That(_settlementMonitorPage.GetBetAcceptTime(), Is.GreaterThan(betsDate), "Date does not match");
        }

        [TestCase(0, "MOBILE_WEB", "520012", "2019-08-26T21:00:00.000Z", "2019-09-13T11:00:53.672Z", "1")]
        public void VerifyBetChannel(int segment, string channel, string eventId, string acceptTimeGreaterOrEqual, string acceptTimeLessThan, string betsAmount)
        {
            BetsClient betRequest = new BetsClient();
            FilteringRequestModel betsRequest = new FilteringRequestModel();
            InFilterModel inFilter = new InFilterModel();
            var segments = new[] { segment };
            inFilter.SegmentIds = segments;
            var channels = new[] { channel };
            inFilter.Channels = channels;
            betsRequest.InFilter = inFilter;
            betsRequest.ODataFilter = $"(eventId eq '{eventId}') and (acceptTime ge {acceptTimeGreaterOrEqual}) and (acceptTime lt {acceptTimeLessThan}) and (betBaseAmount ge {betsAmount})";
            betsRequest.Take = 50;
            List<BetsResponseModel> betsResponse = betRequest.GetBets(betsRequest);
            string channelFromResponse = betsResponse[0].Channel;

            Assert.AreEqual(channel, channelFromResponse, "Channel does not match");
        }
    }
}
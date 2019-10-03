using Exam.DataProvider;
using Exam.DataProvider.TestData;
using Exam.Models;
using Exam.Pages;
using Exam.BackendClients;
using NUnit.Framework;
using System.Collections.Generic;
using Exam.Utils;

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

        [Test]
        public void NavigateToPlayerHistoryFromSettlementMonitor()
        {
            _settlementMonitorPage = new SettlementMonitorPage();
            _settlementMonitorPage
                .SelectDate()
                .SearchEventByText()
                .NavigateIntoEvent()
                .FilterBetsByDate("27.08.2019 00:00:00")
                .NavigateToPlayerHistoryPage();
            _playerHistoryPage = new PlayerHistoryPage();

            Assert.AreEqual("929297369", _playerHistoryPage.GetPlayerId(), "Player ID does not match");
        }

        [TestCaseSource(typeof(FilteringTestData), nameof(FilteringTestData.GetFilteringData))]
        public void VerifyBetDate(FilterProvider filteringData)
        {
            _settlementMonitorPage = new SettlementMonitorPage();
            _settlementMonitorPage
                .SelectDate()
                .SearchEventByText()
                .NavigateIntoEvent()
                .FilterBetsByDate(filteringData.Date);

            Assert.That(_settlementMonitorPage.GetBetAcceptTime(), Is.GreaterThan(filteringData.Date), "Date does not match");
        }

        [TestCaseSource(typeof(FilteringTestData), nameof(FilteringTestData.GetFilteringData))]
        public void VerifyBetChannel(FilterProvider filteringData)
        {
            BetsClient betRequest = new BetsClient();
            List<BetsResponse> betsResponse = betRequest.GetBets(filteringData.FilteringBodyInSettlementMonitor);
            string channel = betsResponse[0].Channel;

            Assert.AreEqual("MOBILE_WEB", channel, "Channel does not match");
        }
    }
}
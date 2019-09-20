using Exam.DataProvider;
using Exam.DataProvider.TestData;
using Exam.Models;
using Exam.Pages;
using Exam.BackendSide;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Exam.Session;
using Exam.Utils;

namespace Exam.Tests
{
    [TestFixture]
    public class SettlementMonitorFiltering : _BaseUITest
    {
        private LoginPage _loginPage;
        private SettlementMonitorPage _settlementMonitorPage;
        private PlayerHistoryPage _playerHistoryPage;

        [SetUp]
        public void BeforeTest()
        {
            //_loginPage = new LoginPage();
            //_loginPage.Login();

            //var login = new LoginClient();

            //accessAllowed.Authorize();
        }

        [Test]
        public void NavigateToPlayerHistory()
        {
            _settlementMonitorPage = new SettlementMonitorPage();
            //_playerHistoryPage = new PlayerHistoryPage();
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

        [Test]
        public void VerifyBetChannel()
        {
            BetsClient betRequest = new BetsClient();
            List<BetsResponse> betModel = betRequest.GetBets();
            string channel = betModel[0].Channel;

            Assert.AreEqual("MOBILE_WEB", channel, "Channel does not match");
        }

        [Test]
        public void TestLoginToBsm()
        {
            //_settlementMonitorPage = new SettlementMonitorPage();
            //SettlementMonitorClient login = new SettlementMonitorClient();
            //_settlementMonitorPage
            //    .SelectDate()
            //    .SearchEventByText()
            //    .NavigateIntoEvent();
            
            DriverManager.Driver.Value.Url = "http://backoffice.kube.private/monitors/settlement/";
            DriverManager.SetToken(TokenManager.GetToken());
            _settlementMonitorPage = new SettlementMonitorPage();
            _settlementMonitorPage
                .SelectDate()
                .SearchEventByText()
                .NavigateIntoEvent();
            //How no set token to driver(manager)
        }
    }
}
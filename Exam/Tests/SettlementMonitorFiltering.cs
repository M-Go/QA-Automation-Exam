using Exam.DataProvider;
using Exam.DataProvider.TestData;
using Exam.Pages;
using Exam.Requests;
using NUnit.Framework;
using System;

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
            _loginPage = new LoginPage();
            _loginPage.Login();

            //var accessAllowed = new LoginRequest();
            //accessAllowed.Authorize();
        }

        //[Test]
        [TestCaseSource(typeof(FilteringTestData), nameof(FilteringTestData.GetFilteringData))]
        public void FilterBetsByDate(FilterProvider filteringData) //public void FilterBetsByDate(FilterProvider filteringData)
        {
            _settlementMonitorPage = new SettlementMonitorPage();
            _settlementMonitorPage
                .SelectDate()
                .SearchEventByText()
                .NavigateIntoEvent()
                //.FilterBetsByDate("27.08.2019 00:00:00");
                .FilterBetsByDate(filteringData.Date);

            //Assert.That(_settlementMonitorPage.GetBetAcceptTime(), Is.GreaterThan("27/08/2019 00:00:00"), "Date does not match");
            Assert.That(_settlementMonitorPage.GetBetAcceptTime(), Is.GreaterThan(filteringData.Date), "Date does not match");
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

        [Test]
        public void GetBetsViaAPI()
        {
            var betRequest = new BetsClient();
            var a = betRequest.ReceiveBets();
            Console.WriteLine(a);
        }


        //[Test]
        //Find betId via API
        //var betRequest = new BetRequest();
        //betRequest.GetBets();

        //Check its channel
        //Check its date

    }
}
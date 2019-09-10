using Exam.DataProvider;
using Exam.Pages;
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

        [Test]
        public void FilterBetsByDate() //public void FilterBetsByDate(FilterProvider filteringData)
        {
            _settlementMonitorPage = new SettlementMonitorPage();
            _settlementMonitorPage
                .SelectDate()
                .SearchEventByText()
                .NavigateIntoEvent()
                .FilterBetsByDate("27.08.2019 00:00:00"); //.FilterBetsByDate(filteringData.Date)
        
            Assert.That(DateTime.Parse(_settlementMonitorPage.GetBetAcceptTime()), Is.GreaterThan(DateTime.Parse("27/08/2019 00:00:00")));
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

            Assert.AreEqual("929297369", _playerHistoryPage.GetPlayerId(), "Player ID does not match");
        }
    }
}
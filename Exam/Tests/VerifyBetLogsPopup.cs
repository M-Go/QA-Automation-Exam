using Exam.Pages;
using Exam.Utils;
using NUnit.Framework;

namespace Exam.Tests
{
    [TestFixture]
    public class VerifyBetLogsPopup : _BaseUITest
    {
        private SettlementMonitorPage _settlementMonitorPage;

        [SetUp]
        public void BeforeTest()
        {
            Login loginViaApi = new Login();
            loginViaApi.LoginViaApi("/monitors/settlement/");
        }

        [TestCase("30.10.19 - 31.10.19", "ЦСКА")]
        public void FindEventByTextSearch(string eventsDate, string text)
        {
            _settlementMonitorPage = new SettlementMonitorPage();
            _settlementMonitorPage
                .SelectDate(eventsDate)
                .SearchEventByText(text);

            Assert.AreEqual(_settlementMonitorPage.GetEventDescriptionInTree(), _settlementMonitorPage.GetEventDescriptionInList(), "Event stage does not match");  //(Regex.IsMatch(_settlementMonitorPage.GetEventDescriptionInList().ToString(), "Киберспорт.*"), "Event description does not match");
        }

        [TestCase("30.10.19 - 31.10.19", "ЦСКА", "31.10.2019 00:00:00", "1", "10", "Desktop")]
        public void VerifyEventName(string eventsDate, string text, string betsDate, string betsAmountFrom, string betsAmountTo, string channel)
        {
            _settlementMonitorPage = new SettlementMonitorPage();
            _settlementMonitorPage
                .SelectDate(eventsDate)
                .SearchEventByText(text)
                .NavigateIntoEvent()
                .FilterBets(betsDate, betsAmountFrom, betsAmountTo, channel)
                .ObserveBetLogs();

            Assert.AreEqual(_settlementMonitorPage.GetEventNameDetailedView(), _settlementMonitorPage.GetEventNamePopup(), "Event name does not match");
        }

        [TestCase("30.10.19 - 31.10.19", "ЦСКА", "31.10.2019 00:00:00", "1", "10", "Desktop", "Settled")]
        public void VerifyBetStatus(string eventsDate, string text, string betsDate, string betsAmountFrom, string betsAmountTo, string channel, string expectedBetStatus)
        {
            _settlementMonitorPage = new SettlementMonitorPage();
            _settlementMonitorPage
                .SelectDate(eventsDate)
                .SearchEventByText(text)
                .NavigateIntoEvent()
                .FilterBets(betsDate, betsAmountFrom, betsAmountTo, channel)
                .ObserveBetLogs();

            Assert.AreEqual(expectedBetStatus, _settlementMonitorPage.GetBetSettlementStatusPopup(), "Bet settlement status does not match");
        }

        [TestCase("30.10.19 - 31.10.19", "ЦСКА", "31.10.2019 00:00:00", "1", "10", "Desktop", "LOSE")]
        public void VerifyBetResult(string eventsDate, string text, string betsDate, string betsAmountFrom, string betsAmountTo, string channel, string expectedBetResult)
        {
            _settlementMonitorPage = new SettlementMonitorPage();
            _settlementMonitorPage
                .SelectDate(eventsDate)
                .SearchEventByText(text)
                .NavigateIntoEvent()
                .FilterBets(betsDate, betsAmountFrom, betsAmountTo, channel)
                .ObserveBetLogs();

            Assert.AreEqual(expectedBetResult, _settlementMonitorPage.GetBetResultPopup(), "Bet result does not match");
        }
    }
}
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

        [Test]
        public void FindEventByTextSearch()
        {
            _settlementMonitorPage = new SettlementMonitorPage();
            _settlementMonitorPage
                .SelectDate()
                .SearchEventByText();

            Assert.AreEqual(_settlementMonitorPage.GetEventDescriptionInTree(), _settlementMonitorPage.GetEventDescriptionInList(), "Event stage does not match");  //(Regex.IsMatch(_settlementMonitorPage.GetEventDescriptionInList().ToString(), "Киберспорт.*"), "Event description does not match");
        }

        [Test]
        public void VerifyEventName()
        {
            _settlementMonitorPage = new SettlementMonitorPage();
            _settlementMonitorPage
                .SelectDate()
                .SearchEventByText()
                .NavigateIntoEvent()
                .ObserveBetLogs();

            Assert.AreEqual(_settlementMonitorPage.GetEventNameDetailedView(), _settlementMonitorPage.GetEventNamePopup(), "Event name does not match");
        }

        [Test]
        public void VerifyBetStatus()
        {
            _settlementMonitorPage = new SettlementMonitorPage();
            _settlementMonitorPage
                .SelectDate()
                .SearchEventByText()
                .NavigateIntoEvent()
                .ObserveBetLogs();

            Assert.AreEqual("Settled", _settlementMonitorPage.GetBetSettlementStatusPopup(), "Bet settlement status does not match");
        }

        [Test]
        public void VerifyBetResult()
        {
            _settlementMonitorPage = new SettlementMonitorPage();
            _settlementMonitorPage
                .SelectDate()
                .SearchEventByText()
                .NavigateIntoEvent()
                .ObserveBetLogs();

            Assert.AreEqual("LOSE", _settlementMonitorPage.GetBetResultPopup(), "Bet result does not match");
        }
    }
}
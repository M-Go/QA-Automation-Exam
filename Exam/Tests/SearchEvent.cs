using Exam.Pages;
using Exam.BackendSide;
using Exam.Utils;
using NUnit.Framework;

namespace Exam.Tests
{
    [TestFixture]
    public class SearchEvent : _BaseUITest
    {
        private LoginPage _loginPage;
        private SettlementMonitorPage _settlementMonitorPage;

        [SetUp]
        public void BeforeTest()
        {
            _loginPage = new LoginPage();
            _loginPage.Login();

            //var accessAllowed = new LoginRequest();
            //accessAllowed.Authorize();
        }

        [Test]
        public void SelectEvent()
        {
            _settlementMonitorPage = new SettlementMonitorPage();
            _settlementMonitorPage
                .SelectDate()
                .SelectEventInEventsTree();

            Assert.AreEqual(_settlementMonitorPage.GetEventDescriptionInTree(), _settlementMonitorPage.GetEventDescriptionInList(), "Event stage does not match");  //(Regex.IsMatch(_settlementMonitorPage.GetEventDescriptionInList().ToString(), "Киберспорт.*"), "Event description does not match");
        }

        [Test]
        public void VerifyThatEventIsFinished()
        {
            _settlementMonitorPage = new SettlementMonitorPage();
            _settlementMonitorPage
                .SelectDate()
                .SelectEventInEventsTree()
                .SelectFinishedEvents();

            Assert.AreEqual("Finished", _settlementMonitorPage.GetEventStageStatus(), "Event stage does not match");
        }

        [Test]
        public void VerifyThatEventIsSettled()
        {
            _settlementMonitorPage = new SettlementMonitorPage();
            _settlementMonitorPage
                .SelectDate()
                .SelectEventInEventsTree()
                .SelectFinishedEvents();

            Assert.AreEqual("Settled", _settlementMonitorPage.GetEventSettlementStatus(), "Event settlement status does not match");
        }
    }
}
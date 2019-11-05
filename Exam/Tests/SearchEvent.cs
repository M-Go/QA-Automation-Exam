using Exam.Pages;
using Exam.Utils;
using NUnit.Framework;

namespace Exam.Tests
{
    [TestFixture]
    public class SearchEvent : _BaseUITest
    {
        private SettlementMonitorPage _settlementMonitorPage;

        [SetUp]
        public void BeforeTest()
        {
            Login loginViaApi = new Login();
            loginViaApi.LoginViaApi("/monitors/settlement/");
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
                .SelectEventInEventsTree();

            Assert.AreEqual("Finished", _settlementMonitorPage.GetEventStageStatus(), "Event stage does not match");
        }

        [Test]
        public void VerifyThatEventIsSettled()
        {
            _settlementMonitorPage = new SettlementMonitorPage();
            _settlementMonitorPage
                .SelectDate()
                .SelectEventInEventsTree();

            Assert.AreEqual("Settled", _settlementMonitorPage.GetEventSettlementStatus(), "Event settlement status does not match");
        }
    }
}
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
            Localization selectLanguage = new Localization();
            selectLanguage.SelectLanguage("ru", "admin@betlab");
        }


        [TestCase("28.08.19 - 03.09.19")]
        public void SelectEvent(string eventsDate)
        {
            _settlementMonitorPage = new SettlementMonitorPage();
            _settlementMonitorPage
                .SelectDate(eventsDate)
                .SelectEventInEventsTree();

            Assert.AreEqual(_settlementMonitorPage.GetEventDescriptionInTree(), _settlementMonitorPage.GetEventDescriptionInList(), "Event stage does not match");  //(Regex.IsMatch(_settlementMonitorPage.GetEventDescriptionInList().ToString(), "Киберспорт.*"), "Event description does not match");
        }

        [TestCase("28.08.19 - 03.09.19", "Finished")]
        public void VerifyEventStage(string eventsDate, string expectedEventStage)
        {
            _settlementMonitorPage = new SettlementMonitorPage();
            _settlementMonitorPage
                .SelectDate(eventsDate)
                .SelectEventInEventsTree();

            Assert.AreEqual(expectedEventStage, _settlementMonitorPage.GetEventStageStatus(), "Event stage does not match");
        }

        [TestCase("28.08.19 - 03.09.19", "Settled")]
        public void VerifySettlementStatus(string eventsDate, string expectedSettlementStatus)
        {
            _settlementMonitorPage = new SettlementMonitorPage();
            _settlementMonitorPage
                .SelectDate(eventsDate)
                .SelectEventInEventsTree();

            Assert.AreEqual(expectedSettlementStatus, _settlementMonitorPage.GetEventSettlementStatus(), "Event settlement status does not match");
        }
    }
}
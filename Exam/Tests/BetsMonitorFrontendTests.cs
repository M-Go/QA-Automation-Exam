using Exam.BackendClients;
using Exam.Models;
using Exam.Models.Filtering;
using Exam.Pages;
using Exam.Utils;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Exam.Tests
{
    [TestFixture]
    public class BetsMonitorFrontendTests : _BaseUITest
    {
        private BetsMonitorPage _betsMonitorPage;
        private PlayerHistoryPage _playerHistoryPage;

        [SetUp]
        public void BeforeTest()
        {
            Login loginViaApi = new Login();
            loginViaApi.LoginViaApi("/monitors/bets/");
            Localization selectLanguage = new Localization();
            selectLanguage.SelectLanguage("ru", "admin@betlab");
        }

        [TestCase("2019-08-26T21:00:00.000Z", "929297369")]
        public void NavigateToPlayerHistoryFromBetsMonitor(string acceptTime, string playerId)
        {
            _betsMonitorPage = new BetsMonitorPage();
            _betsMonitorPage
                .FilterBetsByAcceptTimeAndPlayerId(acceptTime, playerId)
                .NavigateToPlayerHistoryPage();
            _playerHistoryPage = new PlayerHistoryPage();

            Assert.AreEqual(playerId, _playerHistoryPage.GetPlayerId(), "Player ID does not match");
        }

        [TestCase("929297369", "2019-08-26T21:00:00.000Z")]
        public void VerifyEventNames(string playerId, string acceptTime)
        {
            BetsClient client = new BetsClient();
            FilteringRequestModel betsRequest = new FilteringRequestModel();
            InFilterModel inFilter = new InFilterModel();
            var playerIds = new[] { playerId };
            inFilter.PlayerIds = playerIds;
            betsRequest.InFilter = inFilter;
            betsRequest.ODataFilter = $"(acceptTime ge {acceptTime})";
            betsRequest.Take = 50;
            List<BetsResponseModel> betsResponse = client.GetBets(betsRequest);          
            var allEventNamesFromResponse = from bet in betsResponse select bet.EventName;
            var validEventNamesFromResponse = allEventNamesFromResponse.Where(name => name != null).ToList();

            _betsMonitorPage = new BetsMonitorPage();
            _betsMonitorPage
                .FilterBetsByAcceptTimeAndPlayerId(acceptTime, playerId);
            var allEventNamesFromUi = _betsMonitorPage.GetEventNames();
            var validEventNamesFromUi = allEventNamesFromResponse.Where(name => name != null).ToList();
            CollectionAssert.AreEqual(validEventNamesFromResponse, validEventNamesFromUi, "Event names do not match");           
        }
    }
}
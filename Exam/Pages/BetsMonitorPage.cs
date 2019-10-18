using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam.Pages
{
    public class BetsMonitorPage : _BasePage
    {
        private IWebElement _acceptTimeField => _driver.FindElement(By.CssSelector(".multiselect__single"));
        private IWebElement _timeRangeOption => _driver.FindElement(By.XPath("//span[contains(.,'Временной интервал')]"));
        private IWebElement _dateFromField => _driver.FindElement(By.CssSelector(".custom-frame-from>.mx-datepicker>.mx-input-wrapper>.mx-input"));
        private IWebElement _searchEventField => _driver.FindElement(By.CssSelector(".event-search-input"));
        private IWebElement _playerIdField => _driver.FindElement(By.CssSelector(".bo-player-id span")); // ("[placeholder*='игрока']")); //XPath("//div/input[@placeholder='Enter player ID']"));
        private IWebElement _playerIdFieldInput => _driver.FindElement(By.CssSelector(".bo-player-id input"));
        private IWebElement _betsTable => _driver.FindElement(By.CssSelector(".bet-view-table-wrapper.current")); //ClassName("bet-view-table"));
        private List<IWebElement> _betsEventNames => _driver.FindElements(By.CssSelector(".eventName-text")).ToList();
        //private IWebElement _betsTableRows => _driver.FindElements(By.CssSelector(".bet-view-table-row"));
        //eventNameTableCell: .bet-view-table-cell.eventName


        private IWebElement _filterButton => _driver.FindElement(By.CssSelector(".warning.raised.lg"));
        private IWebElement _playerIdClickable => _driver.FindElement(By.CssSelector(".player-profit-status"));

        public BetsMonitorPage()
        {
            _driver.Url = "http://backoffice.kube.private/monitors/bets";
        }

        public BetsMonitorPage FilterBetsByAcceptTimeAndPlayerId(string acceptTime, string playerId)
        {
            _acceptTimeField.Click();
            _timeRangeOption.Click();
            _dateFromField.SendKeys(acceptTime);
            _searchEventField.Click(); //click anywhere to close the datepicker 
            _playerIdField.Click();
            _playerIdFieldInput.SendKeys(playerId);
            _playerIdFieldInput.SendKeys(Keys.Enter);
            _filterButton.Click();
            return this;
        }

        public BetsMonitorPage NavigateToPlayerHistoryPage()
        {
            _playerIdClickable.Click();
            return this;
        }

        //Assert methods
        public IEnumerable<String> GetEventNames()
        {

            //WebElement baseTable = driver.findElement(By.className("table gradient myPage"));

            List<IWebElement> element = _betsEventNames;
            var allEventNames = from name in _betsEventNames select name.Text;

            //var tableRows = _betsTable.FindElements(By.TagName("tr"));

            //_driver.FindElements(By.CssSelector(".eventName-text"));
            //var allEventNames = _betsEventNames.GetText();


            //List<BetsResponse> betsResponse = betRequest.GetBets(filteringData.FilteringBodyInBetsMonitor);
            //var allPlayerIds = from bet in betsResponse select bet.PlayerId; //Distinct();
            //List<IWebElement> AllEventNames = tableRows.FindElements(By.CssSelector(".eventName-text"));

            //List<IWebElement> tableRows = _betsTable.FindElements(By.TagName("tr")).ToList();
            //List<IWebElement> AllEventNames = tableRows.FindElements(By.CssSelector(".eventName-text"));

            //List <String> AllEventNames = tableRows
            //tableRows.get(index).getText();

            //String innerText = _driver.FindElements(By.CssSelector(".bet-view-table-row")).GetText();

            return allEventNames;//.ToList();
        }
    }
}
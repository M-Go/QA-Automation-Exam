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
        private IWebElement _playerIdField => _driver.FindElement(By.CssSelector(".bo-player-id span"));
        private IWebElement _playerIdFieldInput => _driver.FindElement(By.CssSelector(".bo-player-id input"));
        private IWebElement _betsTable => _driver.FindElement(By.CssSelector(".bet-view-table-wrapper.current"));
        private List<IWebElement> _betsEventNames => _driver.FindElements(By.CssSelector(".eventName-text")).ToList();
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

        public IEnumerable<String> GetEventNames()
        {
            List<IWebElement> element = _betsEventNames;
            var allEventNames = from name in _betsEventNames select name.Text;
            return allEventNames;
        }
    }
}
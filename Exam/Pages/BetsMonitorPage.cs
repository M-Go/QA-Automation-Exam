using OpenQA.Selenium;

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
    }
}
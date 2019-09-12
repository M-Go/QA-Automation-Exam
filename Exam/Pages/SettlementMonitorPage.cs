using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace Exam.Pages
{
    public class SettlementMonitorPage : LoginPage
    {      
        private IWebElement _dateField =>_driver.FindElement(By.XPath("//input[@placeholder='Выберите период']"));
        private IWebElement _searchEventField => _driver.FindElement(By.XPath("//div/input[@placeholder='Find event']"));
        private IWebElement _selectSportType => _driver.FindElement(By.XPath("(//label[@class='title'][contains(., 'Хоккей')])"));
        private IWebElement _selectCategory => _driver.FindElement(By.XPath("//div/section/ul/li/ul[@class='event-tree'][last()]"));
        private IWebElement _selectTournament => _driver.FindElement(By.XPath("//div/section/ul/li/ul/li/ul[@class='event-tree'][last()]"));
        private IWebElement _eventCheckbox => _driver.FindElement(By.XPath("//span[@class='material-icons'][1]"));
        private IWebElement _eventStageField => _driver.FindElement(By.XPath("//span[@class='multiselect__placeholder'][contains(., 'All event stages')]"));
        private IWebElement _eventStageFinished => _driver.FindElement(By.XPath("//div/ul/li[@class='multiselect__element'][contains(., 'Finished')]"));
        private IWebElement _eventRow => _driver.FindElement(By.XPath("//div[@class='alert-item']"));
        private IWebElement _betLogsButton => _driver.FindElement(By.XPath("//button[@class='transparent icon info']"));
        private IWebElement _filterButton => _driver.FindElement(By.XPath("//button[@class='default white bordered']"));
        private IWebElement _timeRangeFromField => _driver.FindElement(By.XPath("//div/input[@name='date']"));
        private IWebElement _betAmountFromField => _driver.FindElement(By.XPath("//div/input[@class='bo-number-range-input']"));
        private IWebElement _segmentField => _driver.FindElement(By.XPath("//span[@class='multiselect__placeholder'][contains(.,'All segments')]"));
        private IWebElement _noStatusSegment => _driver.FindElement(By.XPath("//span/span[contains(.,'Без статуса')]"));
        private IWebElement _channelField => _driver.FindElement(By.XPath("//span[@class='multiselect__placeholder'][contains(.,'All channels')]"));
        private IWebElement _mobileChannel => _driver.FindElement(By.XPath("//span/span[contains(.,'Mobile')]"));
        private IWebElement _filterForm => _driver.FindElement(By.XPath("//form[@class='event-bet-table-filter-form']"));
        private IWebElement _filteringConfirmButton => _driver.FindElement(By.XPath("//button[@class='warning raised']"));
        private IWebElement _playerIdField => _driver.FindElement(By.XPath("//span[@class='player-profit-status bad']")); //td/div/div/a[@href]"));

        //assert fields
        private IWebElement _eventDescriptionEventsTree => _driver.FindElement(By.XPath("//label/span/span[last()]"));
        private IWebElement _eventDescriptionEventsList => _driver.FindElement(By.XPath("//div[@class='event-title has-tooltip']"));
        private IWebElement _eventStageStatus => _driver.FindElement(By.XPath("//div/span[@class ='value']"));
        private IWebElement _eventSettlementStatus => _driver.FindElement(By.XPath("//div/section/span[2]"));
        private IWebElement _eventNameDetailedView => _driver.FindElement(By.XPath("//div/h2[@class='event-title']"));
        private IWebElement _eventNamePopup => _driver.FindElement(By.XPath("//div/table/tbody/tr/td[@class='eventName']"));
        private IWebElement _betSettlementStatusPopup => _driver.FindElement(By.XPath("//div/table/tbody/tr/td/span[@class='label boLabel settled']"));
        private IWebElement _betResultPopup => _driver.FindElement(By.XPath("//span[contains(., 'LOSE')]"));
        private IWebElement _betAcceptTime => _driver.FindElement(By.XPath("//td[@class='mn-table-cell bet-table-cell betAcceptTime']/div[1]"));
        private IWebElement _betAcceptDate => _driver.FindElement(By.XPath("//td[@class='mn-table-cell bet-table-cell betAcceptTime']/div[2]"));

        public SettlementMonitorPage()
        {
            _driver.Url = "http://backoffice.kube.private/monitors/settlement";
        }

        public SettlementMonitorPage SelectDate()
        {
            _dateField.Click();
            _dateField.Clear();
            _dateField.SendKeys("01.09.19 - 07.09.19");
            _searchEventField.Click(); //click anywhere to close the datepicker
            return this;
        }

        public SettlementMonitorPage SelectEventInEventsTree()
        {
            _selectSportType.Click();
            _selectCategory.Click();
            _selectTournament.Click();
            _eventCheckbox.Click();
            return this;
        }

        public SettlementMonitorPage SelectFinishedEvents()
        {
            _eventStageField.Click();
            _eventStageFinished.Click();
            _searchEventField.Click(); //click anywhere to close the dropdown
            return this;

            //does not work select from dropdown
            //IWebElement selectEventStage = _eventStageField;
            //SelectElement dropdownEventStage = new SelectElement(selectEventStage);
            //dropdownEventStage.SelectByValue("Finished");
            //return this;
        }

        public SettlementMonitorPage SearchEventByText()
        {
            _searchEventField.SendKeys("Авангард");
            _eventCheckbox.Click();
            return this;
        }

        public SettlementMonitorPage NavigateIntoEvent()
        {
            _eventRow.Click();        
            return this;
        }

        public SettlementMonitorPage ObserveBetLogs()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", _betLogsButton);
            return this;
        }

        public SettlementMonitorPage FilterBetsByDate(string date)
        {
            _filterButton.Click();
            _timeRangeFromField.SendKeys(date);
            _betAmountFromField.SendKeys("1");
            _segmentField.Click();
            _noStatusSegment.Click();
            _filterForm.Click(); //click anywhere to close the dropdown
            _channelField.Click();
            _mobileChannel.Click();
            _filterForm.Click(); //click anywhere to close the dropdown
            _filteringConfirmButton.Click();
            return this;

            //does not work select from dropdown
            //SelectElement selectSegment = new SelectElement(_segmentField);
            //selectSegment.SelectByValue("Без статуса");
        }

        public SettlementMonitorPage NavigateToPlayerHistoryPage()
        {
            _playerIdField.Click();
            return this;
        }


        //Assert Methods
        public string GetEventDescriptionInTree()
        {
            IWebElement element = _eventDescriptionEventsTree;
            return element.Text;
        }

        public string GetEventDescriptionInList()
        {
            IWebElement element = _eventDescriptionEventsList;
            return element.Text;
        }

        public string GetEventStageStatus()
        {
            IWebElement element = _eventStageStatus;
            return element.Text;
        }

        public string GetEventSettlementStatus()
        {
            IWebElement element = _eventSettlementStatus;
            return element.Text;
        }

        public string GetEventNameDetailedView()
        {
            IWebElement element = _eventNameDetailedView;
            return element.Text;
        }

        public string GetEventNamePopup()
        {
            IWebElement element = _eventNamePopup;
            return element.Text;
        }

        public string GetBetSettlementStatusPopup()
        {
            IWebElement element = _betSettlementStatusPopup;
            return element.Text;
        }

        public string GetBetResultPopup()
        {
            IWebElement element = _betResultPopup;
            return element.Text;
        }

        //public string GetBetAcceptTime()
        //{
        //    IWebElement element1 = _betAcceptTime;
        //    string time = element1.Text;
        //    IWebElement element2 = _betAcceptDate;
        //    string date = element2.Text;
        //    string acceptTime = date + " " + time;
        //    Regex pattern1 = new Regex("\\.");
        //    acceptTime = pattern1.Replace(acceptTime, "/");
        //    Regex pattern2 = new Regex("19");
        //    acceptTime = pattern2.Replace(acceptTime, "2019");
        //    return acceptTime;
        //}

        public string GetBetAcceptTime()
        {
            IWebElement element1 = _betAcceptTime;
            string time = element1.Text;
            IWebElement element2 = _betAcceptDate;
            string date = element2.Text;
            string acceptTime = date + " " + time;
            Regex pattern = new Regex("19");
            acceptTime = pattern.Replace(acceptTime, "2019");
            return acceptTime;
        }
    }
}
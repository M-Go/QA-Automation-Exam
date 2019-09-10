using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Pages
{
    public class PlayerHistoryPage : _BasePage
    {
        private IWebElement _playerIdField => _driver.FindElement(By.CssSelector(".player-brief-attribute.accountNumber")); //"//span[@class='player-brief-attribute accountNumber']"));

        public PlayerHistoryPage()
        {
            _driver.Url = "http://backoffice.kube.private/players/929297369/bets";
        }

        public string GetPlayerId()
        {
            IWebElement element = _playerIdField;
            return element.Text;
        }
    }
}

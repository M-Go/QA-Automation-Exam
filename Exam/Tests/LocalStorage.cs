using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Tests
{
    public class LocalStorage
    {
        private IJavaScriptExecutor js;

        public LocalStorage(IWebDriver driver)
        {
            this.js = (IJavaScriptExecutor)driver;
        }

        public void RemoveItemFromLocalStorage(string item)
        {
            js.ExecuteScript(
                $"window.localStorage.removeItem'{item}');"
                );
        }

        public bool IsItemPresentInLocalStorage(string item)
        {
            return !(js.ExecuteScript(
                $"return window.localStorage.getItem('{item}');") == null);
        }

        public string GetItemFromLocalStorage(string key)
        {
            return (string)js.ExecuteScript(
                $"return window.localStorage.getItem('{key}')");
        }

        public string GetKeyFromLocalStorage(int key)
        {
            return (string)js.ExecuteScript(
                $"return window.localStorage.key('{key}')");
        }

        public long GetLocalStorageLength()
        {
            return (long)js.ExecuteScript(
                "return window.localStorage.length;");
        }


        public void SetItemInLocalStorage(string item, string value)
        {
            js.ExecuteScript($"window.localStorage.setItem('{item}', '{value}');");
            //$"window.localStorage.setItem('{item}', '{value}');");
        }



        //public void SetItemInLocalStorage(string item, string value)
        //{
        //    js.ExecuteScript(
        //        $"localStorage.setItem('{item}', '{value}');");
        //        //$"window.localStorage.setItem('{item}', '{value}');");
        //}

        public void ClearLocalStorage()
        {
            js.ExecuteScript(
                "window.localStorage.clear();");
        }
    }
}
using OpenQA.Selenium;
using System;
using OpenCart.SetUp;
using OpenCart.WebPages.Base;
using OpenCart.Common;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace OpenCart.WebPages
{
    public class PrivacyPage : CommonPage
    {
        public PrivacyPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        //ELEMENTS
        private IWebElement BtnAdvConfig { get { return WebDriver.FindElementById("details-button"); } }
        private IWebElement _ProceedLink { get { return WebDriver.FindElement(ProceedLink); } }
        private By ProceedLink { get { return By.Id("proceed-link"); } }



        //METHODS
        public PrivacyPage SkipPrivacyPage()
        {
            
            BtnAdvConfig.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10)).Until(CustomExpectedConditions.ElementIsVisible(ProceedLink));
            _ProceedLink.Click();
            return this;
        }






    }
}

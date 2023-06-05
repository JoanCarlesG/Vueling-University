using OpenQA.Selenium;
using System;
using OpenCart.SetUp;
using OpenCart.WebPages.Base;
using OpenCart.Common;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace OpenCart.WebPages
{
    public class HomePage : CommonPage
    {
        public HomePage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        //ELEMENTS
        private IWebElement BtnAccount { get { return WebDriver.FindElementByXPath("//a[@class='dropdown-toggle']/i[contains(@class, 'fa-user')]"); } }
        private IWebElement _AccountDropdown { get { return WebDriver.FindElement(AccountDropdown); } }
        private By AccountDropdown { get { return By.XPath("//ul[contains(@class, 'dropdown-menu-right')]"); } }
        private IWebElement BtnRegister { get { return WebDriver.FindElementByXPath("//a[text()='Register']"); } }

        private IWebElement SponsorNintendo { get { return WebDriver.FindElementByXPath("//img[@alt='Nintendo']"); } }

        private IWebElement BtnNextSponsor { get { return WebDriver.FindElementByClassName("swiper-button-next"); } }


        //METHODS
        public HomePage ClickRegisterUser()
        {
            
            BtnAccount.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10)).Until(CustomExpectedConditions.ElementIsVisible(AccountDropdown));
            BtnRegister.Click();
            return this;
        }

        public string GetSponsor()
        {
            string sponsor = SponsorNintendo.GetAttribute("alt");
            return sponsor;
        }






    }
}

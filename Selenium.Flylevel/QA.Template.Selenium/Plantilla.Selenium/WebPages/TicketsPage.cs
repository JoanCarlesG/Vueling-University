using OpenQA.Selenium;
using System;
using Flylevel.SetUp;
using Flylevel.WebPages.Base;
using Flylevel.Common;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Drawing;
using System.Threading;

namespace Flylevel.WebPages
{
    public class TicketsPage : CommonPage
    {
        public TicketsPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();

        private IWebElement OriginField {get { return WebDriver.FindElementById("AvailabilitySearchInputSearchView_TextBoxMarketOrigin1"); }}
        private IWebElement DestinationField { get { return WebDriver.FindElementById("AvailabilitySearchInputSearchView_TextBoxMarketDestination1"); } }
        private IWebElement _Station { get { return WebDriver.FindElement(Station); } }
        private By Station { get { return By.ClassName("optionActive"); } }
        private IWebElement FirstDayInMonth(int monthNum) { return WebDriver.FindElementByXPath("//td[@data-month='" + monthNum + "']"); }
        private IWebElement MonthInCalendar { get { return WebDriver.FindElementByXPath("(//span[@class='ui-datepicker-month'])[1]"); } }

        private IWebElement BtnNextMonth { get { return WebDriver.FindElementByXPath("//a[@title='Siguiente']"); } }
        private By Calendar { get {  return By.Id("datePickerContainer"); }}
        private IWebElement _Calendar { get { return WebDriver.FindElement(Calendar); } }
        private By Searcher { get { return By.Id("buscador"); } }
        private IWebElement _Searcher { get { return WebDriver.FindElement(Calendar); } }
        private IWebElement BtnCookies { get { return WebDriver.FindElementById("onetrust-accept-btn-handler");} }
        private IWebElement BtnRegister { get { return WebDriver.FindElementByClassName("optionRegister"); } }
        private By BtnAccessRegister { get { return By.XPath("//a[text()='Darme de alta']"); }}
        private IWebElement _BtnAccessRegister { get { return WebDriver.FindElement(BtnAccessRegister); } }
        private IWebElement ConcreteDayInLeftMonth(int day) { return WebDriver.FindElementByXPath("(//td[@data-handler='selectDay']/a[text()='"+ day + "'])[1]");}
        private IWebElement FirstAvailableDayInLeftMonth { get { return WebDriver.FindElementByXPath("(//td[@data-handler='selectDay'])[1]"); } }
        private IWebElement BtnOW { get { return WebDriver.FindElementById("AvailabilitySearchInputSearchView_OneWay"); } }
        private IWebElement SelectorINF { get { return WebDriver.FindElementById("AvailabilitySearchInputSearchView_DropDownListPassengerType_INFANT"); } }
        private IWebElement OptionINF(int inf) { return WebDriver.FindElementByXPath("//option[contains(@title, 'Bebé') and @value=" + inf +"]"); }
        private IWebElement BtnSearchFlight { get { return WebDriver.FindElementById("AvailabilitySearchInputSearchView_btnClickToSearchNormal"); } }

        public TicketsPage SkipCookies()
        {
            BtnCookies.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10)).Until(CustomExpectedConditions.ElementIsClickable(Searcher));
            return this;
        }
        public TicketsPage SelectTrip(string origin, string destination)
        {
            BtnCookies.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10)).Until(CustomExpectedConditions.ElementIsClickable(Searcher));
            OriginField.SendKeys(origin);
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10)).Until(CustomExpectedConditions.ElementIsClickable(Station));
            OriginField.SendKeys(Keys.Enter);
            DestinationField.SendKeys(destination);
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10)).Until(CustomExpectedConditions.ElementIsClickable(Station));
            DestinationField.SendKeys(Keys.Enter);

            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10)).Until(CustomExpectedConditions.ElementIsClickable(Calendar));
            return this;
        }

        public TicketsPage ChooseMonth(string month)
        {
            //Jse2.ExecuteScript("arguments[0].click();", BtnNextMonth);
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10)).Until(CustomExpectedConditions.ElementIsClickable(Calendar));
            while (MonthInCalendar.Text != month)
            {
                Jse2.ExecuteScript("arguments[0].click();", BtnNextMonth);
            }
            return this;
        }

        public TicketsPage GoToRegister()
        {
            BtnRegister.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10)).Until(CustomExpectedConditions.ElementIsClickable(BtnAccessRegister));
            _BtnAccessRegister.Click();
            return this;
        }

        public TicketsPage Get1stAvailableDay(int day)
        {
            FirstAvailableDayInLeftMonth.Click();
            return this;
        }

        public TicketsPage ChooseDay(int day)
        {
            ConcreteDayInLeftMonth(day).Click(); 
            return this;
        }

        public TicketsPage ChooseOW()
        {
            Jse2.ExecuteScript("arguments[0].click();", BtnOW);
            return this;
        }

        public TicketsPage ChooseINF(int inf)
        {
            SelectorINF.Click();
            //Thread.Sleep(1000);
            //Jse2.ExecuteScript("arguments[0].click();", OptionINF(inf));
            OptionINF(inf).Click(); 
            return this;    
        }

        public TicketsPage GoSearchFlight()
        {
            BtnSearchFlight.Click();    
            return this;
        }
       






    }
}

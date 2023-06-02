using OpenQA.Selenium;
using System;
using Flylevel.SetUp;
using Flylevel.WebPages.Base;
using Flylevel.Common;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace Flylevel.WebPages
{
    public class HomePage : CommonPage
    {
        public HomePage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();

        private IWebElement _BtnOrigin {get { return WebDriver.FindElement(BtnOrigin); }  }
        private By BtnOrigin {get { return By.XPath("//div[@data-field='origin']"); }}
        private IWebElement BtnCookies {get { return WebDriver.FindElementById("ensCloseBanner"); }}
        private IWebElement OriginInput {get { return WebDriver.FindElementByXPath("//input[@placeholder = '¿Desde dónde?']"); } }
        private IWebElement DestinationInput {get { return WebDriver.FindElementByXPath("//input[@placeholder = '¿A dónde?']"); } }
        private IWebElement Station(string way , string station) { return WebDriver.FindElementByXPath("//div[@data-field='" + way + "']//div[@class='city' and text()='" + station + "']"); }
        private IWebElement DatePicker { get { return WebDriver.FindElementByClassName("is-available"); }}
        private IWebElement BtnPax { get { return WebDriver.FindElementByClassName("btn-pax"); } }
        private IWebElement BtnSubmitSearch { get { return WebDriver.FindElementById("searcher_submit_buttons"); } }
        private IWebElement TripSwitch { get { return WebDriver.FindElementByXPath("//input[@type='checkbox']/../span[@class='lever']"); } }
        private IWebElement _PaxSelector { get { return WebDriver.FindElement(PaxSelector); } }
        private By PaxSelector { get { return By.XPath("//div[contains(@class,'passengers-selector')]"); } }
        private IWebElement BtnMoreADTs { get { return WebDriver.FindElementByXPath("//div[@data-field='adult']//div[@class='js-plus']"); } }
        private IWebElement BtnMoreCHDs { get { return WebDriver.FindElementByXPath("//div[@data-field='child']//div[@class='js-plus']"); } }
        private IWebElement BtnMoreINFs { get { return WebDriver.FindElementByXPath("//div[@data-field='infant']//div[@class='js-plus']"); } }
        private IWebElement CalendarMonthName { get { return WebDriver.FindElementByXPath("//span[@class='month']"); } }
        private IWebElement BtnNextMonth { get { return WebDriver.FindElementByClassName("datepicker__next-action"); } }
        private IWebElement DayInCalendar(long timestamp) { return WebDriver.FindElementByXPath("//div[@data-time='" + timestamp +"']"); } 



        public HomePage SelectOrigin(string station)
        {
            string way = "origin";
            BtnCookies.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10)).Until(CustomExpectedConditions.ElementIsClickable(BtnOrigin));
            _BtnOrigin.Click();
            OriginInput.SendKeys(station);
            Station(way,station).Click();
            return this;
        }
        public HomePage SelectDestination(string station)
        {
            string way = "destination";
            DestinationInput.SendKeys(station);
            Station(way, station).Click();
            return this;
        }

        public HomePage ChooseAvailableDate()
        {
            DatePicker.Click();
            return this;
        }

        public HomePage ConfirmPax() 
        { 
            BtnPax.Click();
            return this;
        }

        public HomePage ConfirmSubmitSearch()
        {
            BtnSubmitSearch.Click();
            return this;
        }

        public HomePage ChangeTrip()
        {
            TripSwitch.Click();
            return this;
        }

        public HomePage ChoosePax(int adts, int chds, int infs)
        {
            //new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10)).Until(CustomExpectedConditions.ElementIsClickable(PaxSelector));
            _PaxSelector.Click();
            this.ChooseADTs(adts);
            this.ChooseCHDs(chds);
            this.ChooseINFs(infs);
            this.ConfirmPax();
            return this;    
        }
        public HomePage ChooseADTs(int num) 
        { 
            for(int i = 1; i < num; i++)
            {
                BtnMoreADTs.Click();
            }
            return this;
        }
        public HomePage ChooseCHDs(int num)
        {
            for (int i = 0; i < num; i++)
            {
                BtnMoreCHDs.Click();
            }
            return this;
        }
        public HomePage ChooseINFs(int num)
        {
            for (int i = 0; i < num; i++)
            {
                BtnMoreINFs.Click();
            }
            return this;
        }

        public HomePage SelectMonth(string month)
        {

            while(CalendarMonthName.Text != month.ToUpper())
            {
                BtnNextMonth.Click();
            }
            return this;
        }

        public long DateToTimestamp(string dateString)
        {
            DateTime date = DateTime.ParseExact(dateString, "dd/MM/yyyy", null);
            long timestamp = new DateTimeOffset(date).ToUnixTimeMilliseconds();
            return timestamp;
        }

        public HomePage PickDay(string dateTime) 
        {
            long timestamp = DateToTimestamp(dateTime);
            DayInCalendar(timestamp).Click();
            return this;
        }






    }
}

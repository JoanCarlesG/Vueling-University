using OpenQA.Selenium;
using System;
using Flylevel.SetUp;
using Flylevel.WebPages.Base;
using Flylevel.Common;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Threading;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Collections;
using System.Linq;

namespace Flylevel.WebPages
{
    public class ChooseFlightPage : CommonPage
    {
        public ChooseFlightPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();


        private IWebElement _FlightsContainer { get { return WebDriver.FindElement(FlightsContainer); } }
        private By FlightsContainer { get { return By.Id("flightCardsContainer"); } }
        private IList<IWebElement> flightsList { get { return WebDriver.FindElementsByXPath("//span[@id='justPrice']/span[@class='price-currency__amount']"); } }
        private IWebElement Flight(int value) { return WebDriver.FindElementByXPath("//span[@id='justPrice']/span[@class='price-currency__amount' and text()='" + value +"']"); }

        public ChooseFlightPage FindCheapestFlight()
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10)).Until(CustomExpectedConditions.ElementIsClickable(FlightsContainer));
            int cheapest = flightsList.Min(flight => Int32.Parse(flight.Text));
            Flight(cheapest).Click();
            return this;
        }

    }
}

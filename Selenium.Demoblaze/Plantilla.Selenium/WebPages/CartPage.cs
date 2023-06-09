﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demoblaze.SetUp;
using Demoblaze.WebPages.Base;
using Demoblaze.Webpages;
using System.Threading;
using Demoblaze.Common;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using AventStack.ExtentReports.Utils;

namespace Demoblaze.WebPages
{
    public class CartPage : CommonPage
    {
        public CartPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();

        private IWebElement BtnPlaceOrder
        {
            get { return WebDriver.FindElementByXPath("//button[text() = 'Place Order']"); }
        }

        private IWebElement _NameField
        {
            get { return WebDriver.FindElement(NameField); }
        }

        private By NameField
        {
            get { return By.Id("name"); }
        }
        private IWebElement CountryField
        {
            get { return WebDriver.FindElementById("country"); }
        }
        private IWebElement CityField
        {
            get { return WebDriver.FindElementById("city"); }
        }
        private IWebElement CreditCardField
        {
            get { return WebDriver.FindElementById("card"); }
        }
        private IWebElement MonthField
        {
            get { return WebDriver.FindElementById("month"); }
        }
        private IWebElement YearField
        {
            get { return WebDriver.FindElementById("year"); }
        }
        private IWebElement BtnPurchase
        {
            get { return WebDriver.FindElementByXPath("//button[text() = 'Purchase']"); }
        }
        private IWebElement _OrderConfirmationMessage
        {
            get { return WebDriver.FindElement(OrderConfirmationMessage); }
        }
        private By OrderConfirmationMessage
        {
            get { return By.XPath("//*[text() = 'Thank you for your purchase!']"); }
        }
        private IWebElement BtnOK
        {
            get { return WebDriver.FindElementByXPath("//button[text() = 'OK']"); }
        }
        private IWebElement ProductsTitle
        {
            get { return WebDriver.FindElementByXPath("//*[text() = 'Products']"); }
        }
        private IWebElement ItemInCart (string item)
        {
            return WebDriver.FindElementByXPath("//td[text() = '" + item + "']");
        }
        private IWebElement BtnDeleteItemInCart (string item)
        {
            return WebDriver.FindElementByXPath("//td[text()='" + item + "']/../td/a");
        }



        public CartPage PlaceOrder()
        {
            Assert.AreEqual("Products", ProductsTitle.Text);
            BtnPlaceOrder.Click();
            return this;
        }

        public CartPage FillAndSubmitForm()
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10)).Until(CustomExpectedConditions.ElementIsVisible(NameField));
            _NameField.SendKeys("aaaa");
            CountryField.SendKeys("aaaa");
            CityField.SendKeys("aaaa");
            CreditCardField.SendKeys("1111111");
            MonthField.SendKeys("11");
            YearField.SendKeys("1111");
            BtnPurchase.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10)).Until(CustomExpectedConditions.ElementIsVisible(OrderConfirmationMessage));
            return this;
        }

        public string GetConfirmationMessage()
        {
            string message = _OrderConfirmationMessage.Text;
            return message;
        }

        public string GetItemInCart(string item)
        {
            string name = ItemInCart(item).Text;
            return name;
        }

        public CartPage DeleteItemInCart(string item)
        {
            BtnDeleteItemInCart(item).Click();
            return this;
        }

        public bool CheckItemExistsInCart(string item)
        {
            if (ItemInCart(item).Displayed)
            {
                return true;
            } else
            {
                return false;
            }
        }
        
        
    }
}

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

namespace Demoblaze.WebPages
{
    public class ItemPage : CommonPage
    {
        public ItemPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();

        private IWebElement BtnAddToCart
        {
            get { return WebDriver.FindElementByXPath("//a[text() = 'Add to cart']"); }
        }
        private IWebElement BtnCart
        {
            get { return WebDriver.FindElementById("cartur"); }
        }
        private IWebElement BtnHome
        {
            get { return WebDriver.FindElementByXPath("//a[text() = 'Home ']"); }
        }




        public ItemPage AddToCart()
        {
            BtnAddToCart.Click();
            return this;
        }

        public ItemPage AcceptAlert()
        {
            //WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10));
            //IAlert alert = wait.Until(ExpectedConditions.AlertIsPresent());
            
            IAlert alert = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.AlertIsPresent());
            alert.Accept();
            return this;
        }


        public ItemPage GotToCart()
        {
            BtnCart.Click();
            return this;
        }

        public ItemPage GoHome()
        {
            BtnHome.Click();
            return this;
        }
    }
}

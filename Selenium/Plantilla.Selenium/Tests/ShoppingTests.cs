using AventStack.ExtentReports;
using NUnit.Framework;
using Demoblaze.Webpages;
using Demoblaze.Common;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using Demoblaze.SetUp;
using Demoblaze.WebPages;

namespace Demoblaze.Tests
{
    class ShoppingTests : TestSetCleanBase
    {
        [TestCase]
        public void PurchaseLaptopTest()
        {
            string category = "Laptops";
            string laptop = "Dell i7 8gb";
            homePage = new WebPages.HomePage(setUpWebDriver);
            homePage.LoginPage();
            loginPage = new WebPages.LoginPage(setUpWebDriver);
            loginPage.FillAndSubmitLoginForm();
            homePage.ConfirmUser();
            homePage.GetCategory(category);
            homePage.SelectItem(laptop);
            itemPage = new WebPages.ItemPage(setUpWebDriver);
            itemPage.AddToCart();
            itemPage.GotToCart();
            cartPage = new WebPages.CartPage(setUpWebDriver);
            cartPage.PlaceOrder();
            cartPage.FillAndSubmitForm(); 
        }

        [TestCase]
        public void PurchasePhoneTest()
        {
            string category = "Phones";
            string laptop = "Sony xperia z5";
            homePage = new WebPages.HomePage(setUpWebDriver);
            homePage.LoginPage();
            loginPage = new WebPages.LoginPage(setUpWebDriver);
            loginPage.FillAndSubmitLoginForm();
            homePage.ConfirmUser();
            homePage.GetCategory(category);
            homePage.SelectItem(laptop);
            itemPage = new WebPages.ItemPage(setUpWebDriver);
            itemPage.AddToCart();
            itemPage.GotToCart();
            cartPage = new WebPages.CartPage(setUpWebDriver);
            cartPage.PlaceOrder();
            cartPage.FillAndSubmitForm();

        }

        [TestCase]
        public void PurchaseMonitorTest()
        {
            string category = "Monitors";
            string laptop = "Apple monitor 24";
            homePage = new WebPages.HomePage(setUpWebDriver);
            homePage.LoginPage();
            loginPage = new WebPages.LoginPage(setUpWebDriver);
            loginPage.FillAndSubmitLoginForm();
            homePage.ConfirmUser();
            homePage.GetCategory(category);
            homePage.SelectItem(laptop);
            itemPage = new WebPages.ItemPage(setUpWebDriver);
            itemPage.AddToCart();
            itemPage.GotToCart();
            cartPage = new WebPages.CartPage(setUpWebDriver);
            cartPage.PlaceOrder();
            cartPage.FillAndSubmitForm();

        }
    }
}

﻿using AventStack.ExtentReports;
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
    class ItemsTests : TestSetCleanBase
    {
        [TestCase]
        public void PurchaseLaptopTest()
        {
            string category = "Laptops";
            string laptop = "Dell i7 8gb";
            string message = "Thank you for your purchase!";
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
            Assert.AreEqual(message, cartPage.GetConfirmationMessage());
        }

        [TestCase]
        public void PurchasePhoneTest()
        {
            string category = "Phones";
            string phone = "Sony xperia z5";
            string message = "Thank you for your purchase!";
            homePage = new WebPages.HomePage(setUpWebDriver);
            homePage.LoginPage();
            loginPage = new WebPages.LoginPage(setUpWebDriver);
            loginPage.FillAndSubmitLoginForm();
            homePage.ConfirmUser();
            homePage.GetCategory(category);
            homePage.SelectItem(phone);
            itemPage = new WebPages.ItemPage(setUpWebDriver);
            itemPage.AddToCart();
            itemPage.GotToCart();
            cartPage = new WebPages.CartPage(setUpWebDriver);
            cartPage.PlaceOrder();
            cartPage.FillAndSubmitForm();
            Assert.AreEqual(message, cartPage.GetConfirmationMessage());
        }

        [TestCase]
        public void PurchaseMonitorTest()
        {
            string category = "Monitors";
            string monitor = "Apple monitor 24";
            string message = "Thank you for your purchase!";
            homePage = new WebPages.HomePage(setUpWebDriver);
            homePage.LoginPage();
            loginPage = new WebPages.LoginPage(setUpWebDriver);
            loginPage.FillAndSubmitLoginForm();
            homePage.ConfirmUser();
            homePage.GetCategory(category);
            homePage.SelectItem(monitor);
            itemPage = new WebPages.ItemPage(setUpWebDriver);
            itemPage.AddToCart();
            itemPage.GotToCart();
            cartPage = new WebPages.CartPage(setUpWebDriver);
            cartPage.PlaceOrder();
            cartPage.FillAndSubmitForm();
            Assert.AreEqual(message, cartPage.GetConfirmationMessage());
        }

        [TestCase]
        public void CheckItemsInCartTest()
        {
            string category1 = "Monitors";
            string category2 = "Phones";
            string monitor = "Apple monitor 24";
            string phone = "Sony xperia z5";

            homePage = new WebPages.HomePage(setUpWebDriver);
            homePage.LoginPage();
            loginPage = new WebPages.LoginPage(setUpWebDriver);
            loginPage.FillAndSubmitLoginForm();
            homePage.ConfirmUser();
            //First Item
            homePage.GetCategory(category1);
            homePage.SelectItem(monitor);
            itemPage = new WebPages.ItemPage(setUpWebDriver);
            itemPage.AddToCart();
            itemPage.AcceptAlert();
            itemPage.GoHome();
            //Second Item
            homePage.GetCategory(category2);
            homePage.SelectItem(phone);
            itemPage.AddToCart();
            itemPage.AcceptAlert();
            //Cart
            itemPage.GotToCart();
            cartPage = new WebPages.CartPage(setUpWebDriver);
            //Check items in cart
            Assert.AreEqual(monitor, cartPage.GetItemInCart(monitor));
            Assert.AreEqual(phone, cartPage.GetItemInCart(phone));
            
        }

        [TestCase]
        public void DeleteItemsInCartTest()
        {
            string category1 = "Monitors";
            string category2 = "Phones";
            string monitor = "Apple monitor 24";
            string phone = "Sony xperia z5";

            homePage = new WebPages.HomePage(setUpWebDriver);
            homePage.LoginPage();
            loginPage = new WebPages.LoginPage(setUpWebDriver);
            loginPage.FillAndSubmitLoginForm();
            homePage.ConfirmUser();
            //First Item
            homePage.GetCategory(category1);
            homePage.SelectItem(monitor);
            itemPage = new WebPages.ItemPage(setUpWebDriver);
            itemPage.AddToCart();
            itemPage.AcceptAlert();
            itemPage.GoHome();
            //Second Item
            homePage.GetCategory(category2);
            homePage.SelectItem(phone);
            itemPage.AddToCart();
            itemPage.AcceptAlert();
            //Cart
            itemPage.GotToCart();
            cartPage = new WebPages.CartPage(setUpWebDriver);
            //Check items in cart
            cartPage.DeleteItemInCart(monitor);
            //Assert.IsFalse(cartPage.CheckItemExistsInCart(monitor));
        }
    }
}

using OpenQA.Selenium;
using System;
using OpenCart.SetUp;
using OpenCart.WebPages.Base;
using OpenCart.Common;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace OpenCart.WebPages
{
    public class ItemPage : CommonPage
    {
        public ItemPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        //ELEMENTS
        private IWebElement BtnAddToCart { get { return WebDriver.FindElementById("button-cart"); } }
        private IWebElement _ItemThumbnails { get { return WebDriver.FindElement(ItemThumbnails); } }
        private By ItemThumbnails { get { return By.ClassName("thumbnails"); } }
        private IWebElement BtnCart { get { return WebDriver.FindElementByXPath("//a[@title='Shopping Cart']"); } }

        private IWebElement _AddedAlert { get { return WebDriver.FindElement(AddedAlert); } }
        private By AddedAlert { get { return By.ClassName("alert"); } }


        //METHODS
        public ItemPage AddItemToCart()
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10)).Until(CustomExpectedConditions.ElementIsVisible(ItemThumbnails));
            BtnAddToCart.Click();
            return this;
        }

        public ItemPage GoToCart()
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10)).Until(CustomExpectedConditions.ElementIsVisible(AddedAlert));
            BtnCart.Click();
            return this;
        }






    }
}

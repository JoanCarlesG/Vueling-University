using OpenQA.Selenium;
using System;
using OpenCart.SetUp;
using OpenCart.WebPages.Base;
using OpenCart.Common;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace OpenCart.WebPages
{
    public class CartPage : CommonPage
    {
        public CartPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        //ELEMENTS
        private IWebElement _QuestionsAccordion { get { return WebDriver.FindElement(QuestionsAccordion); } }
        private By QuestionsAccordion { get { return By.Id("accordion"); } }

        private IWebElement BtnCheckout { get { return WebDriver.FindElementByXPath("//a[text()='Checkout']"); } }

        //METHODS
        public CartPage GoToCheckout()
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10)).Until(CustomExpectedConditions.ElementIsVisible(QuestionsAccordion));
            BtnCheckout.Click();
            return this;
        }






    }
}

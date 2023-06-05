using OpenQA.Selenium;
using System;
using OpenCart.SetUp;
using OpenCart.WebPages.Base;
using OpenCart.Common;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace OpenCart.WebPages
{
    public class CheckoutPage : CommonPage
    {
        public CheckoutPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        //ELEMENTS
        private IWebElement _QuestionsAccordion { get { return WebDriver.FindElement(QuestionsAccordion); } }
        private By QuestionsAccordion { get { return By.Id("accordion"); } }
        private IWebElement FirstNameField { get { return WebDriver.FindElementById("input-payment-firstname"); } }
        private IWebElement LastNameField { get { return WebDriver.FindElementById("input-payment-lastname"); } }
        private IWebElement Adress1Field { get { return WebDriver.FindElementById("input-payment-address-1"); } }
        private IWebElement CityField { get { return WebDriver.FindElementById("input-payment-city"); } }
        private IWebElement PostCodeField { get { return WebDriver.FindElementById("input-payment-postcode"); } }
        private IWebElement RegionField { get { return WebDriver.FindElementById("input-payment-zone"); } }
        private IWebElement SelectedRegionField { get { return WebDriver.FindElementByXPath("//option[text()='Bristol']"); } }

        private IWebElement BtnContinue1 { get { return WebDriver.FindElementByXPath("(//input[@value='Continue'])[1]"); } }
        private IWebElement BtnContinue2 { get { return WebDriver.FindElementByXPath("(//input[@value='Continue'])[2]"); } }
        private IWebElement BtnContinue3 { get { return WebDriver.FindElementByXPath("//div[@class='buttons']/div/input[@value='Continue']"); } }
        private IWebElement AgreePolicyCheckbox { get { return WebDriver.FindElementByXPath("//input[@name='agree' and @type='checkbox']"); } }
        private IWebElement BtnContinue4 { get { return WebDriver.FindElementById("button-payment-method"); } }
        private IWebElement BtnConfirmOrder { get { return WebDriver.FindElementById("button-confirm"); } }
        private IWebElement ConfirmationMessage { get { return WebDriver.FindElementByXPath("//h1[text()='Your order has been placed!']"); } }

        private IWebElement _Step3Panel { get { return WebDriver.FindElement(Step3Panel); } }
        private By Step3Panel { get { return By.Id("shipping-existing"); } }

        //METHODS
        public CheckoutPage FillAndSubmitForm()
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10)).Until(CustomExpectedConditions.ElementIsVisible(QuestionsAccordion));
            FirstNameField.SendKeys(Helpers.GetRandomString(5));
            LastNameField.SendKeys(Helpers.GetRandomString(5));
            Adress1Field.SendKeys(Helpers.GetRandomString(5));
            CityField.SendKeys(Helpers.GetRandomString(5));
            PostCodeField.SendKeys(Helpers.GetRandomPhoneNumber().ToString());
            RegionField.Click();
            SelectedRegionField.Click();
            BtnContinue1.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10)).Until(CustomExpectedConditions.ElementIsVisible(Step3Panel));
            BtnContinue2.Click();
            BtnContinue3.Click();
            AgreePolicyCheckbox.Click();
            BtnContinue4.Click();
            BtnConfirmOrder.Click();
            return this;
        }

        public string GetConfirmationMessage()
        {
            string message = ConfirmationMessage.Text;
            return message;
        }






    }
}

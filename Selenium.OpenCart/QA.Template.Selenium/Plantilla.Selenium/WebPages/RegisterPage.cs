using OpenQA.Selenium;
using System;
using OpenCart.SetUp;
using OpenCart.WebPages.Base;
using OpenCart.Common;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace OpenCart.WebPages
{
    public class RegisterPage : CommonPage
    {
        public RegisterPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        //ELEMENTS
        private IWebElement FirstNameField { get { return WebDriver.FindElementById("input-firstname"); } }
        private IWebElement LastNameField { get { return WebDriver.FindElementById("input-lastname"); } }
        private IWebElement EmailField { get { return WebDriver.FindElementById("input-email"); } }
        private IWebElement PhoneField { get { return WebDriver.FindElementById("input-telephone"); } }
        private IWebElement PasswordField { get { return WebDriver.FindElementById("input-password"); } }
        private IWebElement ConfirmPasswordField { get { return WebDriver.FindElementById("input-confirm"); } }
        private IWebElement _RegisterContent { get { return WebDriver.FindElement(RegisterContent); } }
        private By RegisterContent { get { return By.Id("content"); } }
        private IWebElement AgreePolicy { get { return WebDriver.FindElementByXPath("//input[@name='agree']"); } }
        private IWebElement BtnSubmitRegister { get { return WebDriver.FindElementByXPath("//input[@value='Continue']"); } }




        //METHODS
        public RegisterPage RegisterUser()
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10)).Until(CustomExpectedConditions.ElementIsVisible(RegisterContent));
            FirstNameField.SendKeys(Helpers.GetRandomString(5));
            LastNameField.SendKeys(Helpers.GetRandomString(5));
            EmailField.SendKeys(Helpers.GetRandomString(5) + "@test.com");
            PhoneField.SendKeys(Helpers.GetRandomPhoneNumber().ToString());
            PasswordField.SendKeys("Testpassword");
            ConfirmPasswordField.SendKeys("Testpassword");
            AgreePolicy.Click();
            BtnSubmitRegister.Click();
            return this;
        }






    }
}

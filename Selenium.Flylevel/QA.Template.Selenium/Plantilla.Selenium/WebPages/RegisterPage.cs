using OpenQA.Selenium;
using System;
using Flylevel.SetUp;
using Flylevel.WebPages.Base;
using Flylevel.Common;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Threading;

namespace Flylevel.WebPages
{
    public class RegisterPage : CommonPage
    {
        public RegisterPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();

        private IWebElement NameField { get { return WebDriver.FindElementById("CONTROLGROUPREGISTERVIEW_PersonInputRegisterView_TextBoxFirstName"); } }
        private IWebElement LastNameField { get { return WebDriver.FindElementById("CONTROLGROUPREGISTERVIEW_PersonInputRegisterView_TextBoxLastName"); } }

        private IWebElement EmailField { get { return WebDriver.FindElementById("CONTROLGROUPREGISTERVIEW_PersonInputRegisterView_TextBoxEmail"); } }
        private IWebElement PasswordField { get { return WebDriver.FindElementById("CONTROLGROUPREGISTERVIEW_MemberInputRegisterView_PasswordFieldAgentPassword"); } }
        private IWebElement ConfirmPasswordField { get { return WebDriver.FindElementById("CONTROLGROUPREGISTERVIEW_MemberInputRegisterView_PasswordFieldPasswordConfirm"); } }
        private IWebElement SecurityQuestion1 { get { return WebDriver.FindElementById("CONTROLGROUPREGISTERVIEW_SecurityQuestionsRegisterView_FirstQuestion"); } }
        private IWebElement SecurityQuestion2 { get { return WebDriver.FindElementById("CONTROLGROUPREGISTERVIEW_SecurityQuestionsRegisterView_SecondQuestion"); } }
        private IWebElement SecurityAnswer1 { get { return WebDriver.FindElementById("CONTROLGROUPREGISTERVIEW_SecurityQuestionsRegisterView_FirstAnswer"); } }
        private IWebElement SecurityAnswer2 { get { return WebDriver.FindElementById("CONTROLGROUPREGISTERVIEW_SecurityQuestionsRegisterView_SecondAnswer"); } }
        private IWebElement ConditionsCheckbox { get { return WebDriver.FindElementByXPath("//input[@id='CONTROLGROUPREGISTERVIEW_LegalConditionsCheckbox']"); } }
        private IWebElement BtnSubmit { get { return WebDriver.FindElementById("CONTROLGROUPREGISTERVIEW_LinkButtonSubmit"); } }
        private IWebElement SecurityQuestion1Option(int value) { return WebDriver.FindElementByXPath("//select[contains(@id,'First')]/option["+ value +"]"); }
        private IWebElement SecurityQuestion2Option(int value) { return WebDriver.FindElementByXPath("//select[contains(@id,'Second')]/option[" + value + "]"); }


        public RegisterPage FillForm()
        {
            NameField.SendKeys(Helpers.GenerateFirstName(5));
            LastNameField.SendKeys(Helpers.GetRandomString(5));
            EmailField.SendKeys(Helpers.GetRandomString(5) + "@test.com");
            PasswordField.SendKeys("Password");
            ConfirmPasswordField.SendKeys("Password");
            SecurityQuestion1.Click();
            Random rnd = new Random();
            SecurityQuestion1Option(rnd.Next(1, 12)).Click();
            SecurityAnswer1.SendKeys(Helpers.GetRandomString(5));
            SecurityQuestion2.Click();
            SecurityQuestion2Option(Helpers.GetRandomNumberBetween(1, 12)).Click();
            SecurityAnswer2.SendKeys(Helpers.GetRandomString(5));
            Jse2.ExecuteScript("arguments[0].click();", ConditionsCheckbox);
            WebDriver.Navigate().GoToUrl("www.vueling.com");
            return this;
        }

    }
}

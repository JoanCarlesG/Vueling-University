using OpenQA.Selenium;
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
    public class LoginPage : CommonPage
    {
        public LoginPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();

        private IWebElement UsernameField
        {
            get { return WebDriver.FindElementById("loginusername"); }
        }
        private IWebElement PasswordField
        {
            get { return WebDriver.FindElementById("loginpassword"); }
        }
        private IWebElement ConfirmLoginBtn
        {
            get { return WebDriver.FindElementByXPath("//button[text() = 'Log in']"); }
        }

        public LoginPage FillAndSubmitLoginForm()
        {
            UsernameField.SendKeys("Joan Carles");
            PasswordField.SendKeys("a");
            ConfirmLoginBtn.Click();
            return this;
        }
    }
}

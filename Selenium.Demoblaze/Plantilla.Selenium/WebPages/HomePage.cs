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
using NUnit.Framework;
using System.Xml.Linq;

namespace Demoblaze.WebPages
{
    public class HomePage : CommonPage
    {
        public HomePage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();

        private IWebElement BtnHome
        {
            get { return WebDriver.FindElementByXPath("//a[text() = 'Home ']"); }
        }
        private IWebElement MonitorCategory
        {
            get { return WebDriver.FindElementByXPath("//a[text() = 'Monitors']"); }
        }
        private IWebElement PhoneCategory
        {
            get { return WebDriver.FindElementByXPath("//a[text() = 'Phones']"); }
        }
        private IWebElement LaptopCategory
        {
            get { return WebDriver.FindElementByXPath("//a[text() = 'Laptops']"); }
        }
        
        private IWebElement BtnNext
        {
            get { return WebDriver.FindElementById("next2"); }
        }
        private IWebElement BtnPrevious
        {
            get { return WebDriver.FindElementById("prev2"); }
        }
        private IWebElement _BtnCarouselNext
        {
            get { return WebDriver.FindElement(BtnCarouselNext); }
        }
        private By BtnCarouselNext
        {
            get { return By.ClassName("carousel-control-next-icon"); }
        }
        private IWebElement BtnCarouselPrevious
        {
            get { return WebDriver.FindElementByClassName("carousel-control-prev-icon"); }
        }

        private IWebElement BtnLogin
        {
            get { return WebDriver.FindElementById("login2"); }
        }

        private IWebElement _Username
        {
            get { return WebDriver.FindElement(Username); }
        }
        private By Username
        {
            get { return By.Id("nameofuser"); }
        }
        private IWebElement SelectedItem(string item)
        {
            return WebDriver.FindElementByXPath("//a[text() = '" + item + "']");
                
        }
        





        public HomePage CarouselNext()
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10)).Until(CustomExpectedConditions.ElementIsVisible(BtnCarouselNext));
            _BtnCarouselNext.Click();
            return this;
        }


        public HomePage LoginPage()
        {
            BtnLogin.Click();
            return this;
        }

        public HomePage ConfirmUser()
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).Until(CustomExpectedConditions.ElementIsVisible(Username));
            Assert.AreEqual("Welcome Joan Carles", _Username.Text);
            return this;
        }
        public HomePage GetCategory(string categoryName)
        {
            switch (categoryName)
            {
                case "Laptops":
                    LaptopCategory.Click();
                    break;
                case "Phones":
                    PhoneCategory.Click(); 
                    break;
                case "Monitors":
                    MonitorCategory.Click();
                    break;
                
            }
            return this;
        }

        public HomePage SelectItem(string item) 
        {
            SelectedItem(item).Click();
            return this;
        }

    }
}

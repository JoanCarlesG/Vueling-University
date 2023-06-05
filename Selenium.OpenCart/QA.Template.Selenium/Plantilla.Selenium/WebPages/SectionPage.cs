using OpenQA.Selenium;
using System;
using OpenCart.SetUp;
using OpenCart.WebPages.Base;
using OpenCart.Common;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace OpenCart.WebPages
{
    public class SectionPage : CommonPage
    {
        public SectionPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        //ELEMENTS
        private IWebElement _ItemContent { get { return WebDriver.FindElement(ItemContent); } }
        private By ItemContent { get { return By.ClassName("product-layout"); } }

        private IWebElement BtnItemTitle(string item) { return WebDriver.FindElementByXPath("//a[text()='" + item + "']"); }
        private IWebElement ItemRow { get { return WebDriver.FindElementByXPath("//div[@id='content']/div[@class='row']"); } }

        

        //METHODS
        public SectionPage SelectItem(string item)
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10)).Until(CustomExpectedConditions.ElementIsVisible(ItemContent));
            BtnItemTitle(item).Click();
            return this;
        }

        public bool ItemsMissing()
        {
            if (ItemRow.Displayed) 
            {
                return true;
            }
            else
            {
                return false;
            };
        }






    }
}

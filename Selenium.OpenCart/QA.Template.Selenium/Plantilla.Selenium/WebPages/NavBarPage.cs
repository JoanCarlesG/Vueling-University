using OpenQA.Selenium;
using System;
using OpenCart.SetUp;
using OpenCart.WebPages.Base;
using OpenCart.Common;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace OpenCart.WebPages
{
    public class NavBarPage : CommonPage
    {
        public NavBarPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {
        }

        //ELEMENTS
        private IWebElement DesktopsDropdown { get { return WebDriver.FindElementByXPath("//a[text()='Desktops']"); } }
        private IWebElement DesktopsSeeMacs { get { return WebDriver.FindElementByXPath("//a[text()='Mac (1)']"); } }
        private IWebElement LaptopsDropdown { get { return WebDriver.FindElementByXPath("//a[text()='Laptops & Notebooks']"); } }
        private IWebElement LaptopsSeeAll { get { return WebDriver.FindElementByXPath("//a[text()='Show All Laptops & Notebooks']"); } }
        private IWebElement ComponentsDropdown { get { return WebDriver.FindElementByXPath("//a[text()='Components']"); } }
        private IWebElement ComponentsSeeMonitors { get { return WebDriver.FindElementByXPath("//a[text()='Monitors (2)']"); } }
        private IWebElement TabletsDropdown { get { return WebDriver.FindElementByXPath("//a[text()='Tablets']"); } }
        private IWebElement SoftwareDropdown { get { return WebDriver.FindElementByXPath("//a[text()='Software']"); } }
        private IWebElement PhonesDropdown { get { return WebDriver.FindElementByXPath("//a[text()='Phones & PDAs']"); } }
        private IWebElement CamerasDropdown { get { return WebDriver.FindElementByXPath("//a[text()='Cameras']"); } }
        private IWebElement MP3Dropdown { get { return WebDriver.FindElementByXPath("//a[text()='MP3 Players']"); } }
        private IWebElement MP3SeeAll { get { return WebDriver.FindElementByXPath("//a[text()='Show All MP3 Players']"); } }

        
        private IWebElement _AccountDropdown { get { return WebDriver.FindElement(AccountDropdown); } }
        private By AccountDropdown { get { return By.XPath("//ul[contains(@class, 'dropdown-menu-right')]"); } }
        private IWebElement BtnRegister { get { return WebDriver.FindElementByXPath("//a[text()='Register']"); } }



        //METHODS
        public NavBarPage GoSection(string section)
        {
            switch (section)
            {
                case "Desktops":
                    DesktopsDropdown.Click();
                    DesktopsSeeMacs.Click();
                    break;
                case "Laptops & Notebooks":
                    LaptopsDropdown.Click();
                    LaptopsSeeAll.Click();
                    break;
                case "Components":
                    ComponentsDropdown.Click();
                    ComponentsSeeMonitors.Click();
                    break;
                case "Tablets":
                    TabletsDropdown.Click();
                    break;
                case "Software":
                    SoftwareDropdown.Click();
                    break;
                case "Phones & PDAs":
                    PhonesDropdown.Click();
                    break;
                case "Cameras":
                    CamerasDropdown.Click();
                    break;
                case "MP3 Players":
                    MP3Dropdown.Click();
                    MP3SeeAll.Click();
                    break;
            }
            return this;
        }






    }
}

using OpenCart.WebPages;
using NUnit.Framework;

namespace OpenCart.Tests
{
    class ShoppingTests : TestSetCleanBase
    {
        [TestCase]
        public void CheckSponsorTest()
        {
            string sponsor = "Nintendo";
            homePage = new WebPages.HomePage(setUpWebDriver);
            Assert.AreEqual(sponsor, homePage.GetSponsor());
        }
        [TestCase]
        public void PurchaseDesktopTest()
        {
            string section = "Desktops";
            string item = "iMac";
            string message = "Your order has been placed!";
            homePage = new WebPages.HomePage(setUpWebDriver);
            homePage.ClickRegisterUser();
            privacyPage = new WebPages.PrivacyPage(setUpWebDriver);
            privacyPage.SkipPrivacyPage();
            registerPage = new WebPages.RegisterPage(setUpWebDriver);
            registerPage.RegisterUser();
            navBarPage = new WebPages.NavBarPage(setUpWebDriver);
            navBarPage.GoSection(section);
            sectionPage = new SectionPage(setUpWebDriver);
            sectionPage.SelectItem(item);
            itemPage = new ItemPage(setUpWebDriver);
            itemPage.AddItemToCart();
            itemPage.GoToCart();
            cartPage = new CartPage(setUpWebDriver);
            cartPage.GoToCheckout();
            checkoutPage = new CheckoutPage(setUpWebDriver);
            checkoutPage.FillAndSubmitForm();
            Assert.AreEqual(message, checkoutPage.GetConfirmationMessage());
        }
        [TestCase]
        public void PurchaseLaptopTest()
        {
            string section = "Laptops & Notebooks";
            string item = "Sony VAIO";
            string message = "Your order has been placed!";
            homePage = new WebPages.HomePage(setUpWebDriver);
            homePage.ClickRegisterUser();
            privacyPage = new WebPages.PrivacyPage(setUpWebDriver);
            privacyPage.SkipPrivacyPage();
            registerPage = new WebPages.RegisterPage(setUpWebDriver);
            registerPage.RegisterUser();
            navBarPage = new WebPages.NavBarPage(setUpWebDriver);
            navBarPage.GoSection(section);
            sectionPage = new SectionPage(setUpWebDriver);
            sectionPage.SelectItem(item);
            itemPage = new ItemPage(setUpWebDriver);
            itemPage.AddItemToCart();
            itemPage.GoToCart();
            cartPage = new CartPage(setUpWebDriver);
            cartPage.GoToCheckout();
            checkoutPage = new CheckoutPage(setUpWebDriver);
            checkoutPage.FillAndSubmitForm();
            Assert.AreEqual(message, checkoutPage.GetConfirmationMessage());
        }
        [TestCase]
        public void PurchaseComponentTest()
        {
            string section = "Components";
            string item = "Samsung SyncMaster 941BW";
            string message = "Your order has been placed!";
            homePage = new WebPages.HomePage(setUpWebDriver);
            homePage.ClickRegisterUser();
            privacyPage = new WebPages.PrivacyPage(setUpWebDriver);
            privacyPage.SkipPrivacyPage();
            registerPage = new WebPages.RegisterPage(setUpWebDriver);
            registerPage.RegisterUser();
            navBarPage = new WebPages.NavBarPage(setUpWebDriver);
            navBarPage.GoSection(section);
            sectionPage = new SectionPage(setUpWebDriver);
            sectionPage.SelectItem(item);
            itemPage = new ItemPage(setUpWebDriver);
            itemPage.AddItemToCart();
            itemPage.GoToCart();
            cartPage = new CartPage(setUpWebDriver);
            cartPage.GoToCheckout();
            checkoutPage = new CheckoutPage(setUpWebDriver);
            checkoutPage.FillAndSubmitForm();
            Assert.AreEqual(message, checkoutPage.GetConfirmationMessage());
        }
        [TestCase]
        public void PurchaseTabletTest()
        {
            string section = "Tablets";
            string item = "Samsung Galaxy Tab 10.1";
            string message = "Your order has been placed!";
            homePage = new WebPages.HomePage(setUpWebDriver);
            homePage.ClickRegisterUser();
            privacyPage = new WebPages.PrivacyPage(setUpWebDriver);
            privacyPage.SkipPrivacyPage();
            registerPage = new WebPages.RegisterPage(setUpWebDriver);
            registerPage.RegisterUser();
            navBarPage = new WebPages.NavBarPage(setUpWebDriver);
            navBarPage.GoSection(section);
            sectionPage = new SectionPage(setUpWebDriver);
            sectionPage.SelectItem(item);
            itemPage = new ItemPage(setUpWebDriver);
            itemPage.AddItemToCart();
            itemPage.GoToCart();
            cartPage = new CartPage(setUpWebDriver);
            cartPage.GoToCheckout();
            checkoutPage = new CheckoutPage(setUpWebDriver);
            checkoutPage.FillAndSubmitForm();
            Assert.AreEqual(message, checkoutPage.GetConfirmationMessage());
        }
        [TestCase]
        public void PurchaseSoftwareTest()
        {
            string section = "Software";
            //string item = "";
            //string message = "Your order has been placed!";
            homePage = new WebPages.HomePage(setUpWebDriver);
            homePage.ClickRegisterUser();
            privacyPage = new WebPages.PrivacyPage(setUpWebDriver);
            privacyPage.SkipPrivacyPage();
            registerPage = new WebPages.RegisterPage(setUpWebDriver);
            registerPage.RegisterUser();
            navBarPage = new WebPages.NavBarPage(setUpWebDriver);
            navBarPage.GoSection(section);
            sectionPage = new SectionPage(setUpWebDriver);
            //Software is EMPTY
            Assert.IsFalse(sectionPage.ItemsMissing());
            
        }
        [TestCase]
        public void PurchasePhoneTest()
        {
            string section = "Phones & PDAs";
            string item = "iPhone";
            string message = "Your order has been placed!";
            homePage = new WebPages.HomePage(setUpWebDriver);
            homePage.ClickRegisterUser();
            privacyPage = new WebPages.PrivacyPage(setUpWebDriver);
            privacyPage.SkipPrivacyPage();
            registerPage = new WebPages.RegisterPage(setUpWebDriver);
            registerPage.RegisterUser();
            navBarPage = new WebPages.NavBarPage(setUpWebDriver);
            navBarPage.GoSection(section);
            sectionPage = new SectionPage(setUpWebDriver);
            sectionPage.SelectItem(item);
            itemPage = new ItemPage(setUpWebDriver);
            itemPage.AddItemToCart();
            itemPage.GoToCart();
            cartPage = new CartPage(setUpWebDriver);
            cartPage.GoToCheckout();
            checkoutPage = new CheckoutPage(setUpWebDriver);
            checkoutPage.FillAndSubmitForm();
            Assert.AreEqual(message, checkoutPage.GetConfirmationMessage());
        }
        [TestCase]
        public void PurchaseCamerasTest()
        {
            string section = "Cameras";
            string item = "Nikon D300";
            string message = "Your order has been placed!";
            homePage = new WebPages.HomePage(setUpWebDriver);
            homePage.ClickRegisterUser();
            privacyPage = new WebPages.PrivacyPage(setUpWebDriver);
            privacyPage.SkipPrivacyPage();
            registerPage = new WebPages.RegisterPage(setUpWebDriver);
            registerPage.RegisterUser();
            navBarPage = new WebPages.NavBarPage(setUpWebDriver);
            navBarPage.GoSection(section);
            sectionPage = new SectionPage(setUpWebDriver);
            sectionPage.SelectItem(item);
            itemPage = new ItemPage(setUpWebDriver);
            itemPage.AddItemToCart();
            itemPage.GoToCart();
            cartPage = new CartPage(setUpWebDriver);
            cartPage.GoToCheckout();
            checkoutPage = new CheckoutPage(setUpWebDriver);
            checkoutPage.FillAndSubmitForm();
            Assert.AreEqual(message, checkoutPage.GetConfirmationMessage());
        }
        [TestCase]
        public void PurchaseMP3Test()
        {
            string section = "MP3 Players";
            string item = "iPod Classic";
            string message = "Your order has been placed!";
            homePage = new WebPages.HomePage(setUpWebDriver);
            homePage.ClickRegisterUser();
            privacyPage = new WebPages.PrivacyPage(setUpWebDriver);
            privacyPage.SkipPrivacyPage();
            registerPage = new WebPages.RegisterPage(setUpWebDriver);
            registerPage.RegisterUser();
            navBarPage = new WebPages.NavBarPage(setUpWebDriver);
            navBarPage.GoSection(section);
            sectionPage = new SectionPage(setUpWebDriver);
            sectionPage.SelectItem(item);
            itemPage = new ItemPage(setUpWebDriver);
            itemPage.AddItemToCart();
            itemPage.GoToCart();
            cartPage = new CartPage(setUpWebDriver);
            cartPage.GoToCheckout();
            checkoutPage = new CheckoutPage(setUpWebDriver);
            checkoutPage.FillAndSubmitForm();
            Assert.AreEqual(message, checkoutPage.GetConfirmationMessage());
        }



    }
}

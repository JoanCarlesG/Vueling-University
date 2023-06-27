using System;
using Flylevel.WebPages;
using NUnit.Framework;

namespace Flylevel.Tests
{
    class VuelingTests : TestSetCleanBase
    {
        [TestCase]
        public void GetDaysTest()
        {
            ticketsPage = new WebPages.TicketsPage(setUpWebDriver);
            ticketsPage.SelectTrip("BCN", "MAD");
            ticketsPage.ChooseMonth("agosto");

        }

        [TestCase]
        public void Registertest() 
        {
            ticketsPage = new WebPages.TicketsPage(setUpWebDriver);
            ticketsPage.SkipCookies();
            ticketsPage.GoToRegister();
            registerPage = new WebPages.RegisterPage(setUpWebDriver);
            registerPage.FillForm();
        }
        [TestCase]
        public void OW4Days1ADT1INFCheapestFlightTest()
        {

            ticketsPage = new WebPages.TicketsPage(setUpWebDriver);
            ticketsPage.SkipCookies();
            ticketsPage.ChooseOW();
            ticketsPage.SelectTrip("BCN", "MAD");
            ticketsPage.ChooseDay(11);
            ticketsPage.ChooseINF(1);
            ticketsPage.GoSearchFlight();
            chooseFlightPage = new WebPages.ChooseFlightPage(setUpWebDriver);
            chooseFlightPage.FindCheapestFlight();
            
        }




    }
}

using Flylevel.WebPages;
using NUnit.Framework;

namespace Flylevel.Tests
{
    class FlightsTests : TestSetCleanBase
    {
        [TestCase]
        public void SearchFlightTest()
        {
            string origin = "Barcelona";
            string destination = "Buenos Aires";
            homePage = new WebPages.HomePage(setUpWebDriver);
            homePage.SelectOrigin(origin);
            homePage.SelectDestination(destination);
            homePage.ChooseAvailableDate();
            homePage.ChooseAvailableDate();
            homePage.ConfirmPax();
            homePage.ConfirmSubmitSearch(); 
            //CANNOT - Missing Assert to confirm search
        }
        [TestCase]
        public void OW2ADT1CHDTest()
        {
            string origin = "Barcelona";
            string destination = "Nueva York";
            int adts = 2;
            int chds = 1;
            int infs = 0;
            homePage = new WebPages.HomePage(setUpWebDriver);
            homePage.SelectOrigin(origin);
            homePage.SelectDestination(destination);
            homePage.ChangeTrip();
            homePage.ChooseAvailableDate();
            //Choose Pax
            homePage.ChoosePax(adts, chds, infs);
            homePage.ConfirmSubmitSearch();
            //CANNOT - Missing Assert to confirm search
            //Missing Tarifa Economy-Light
            //Missing Assert llegada a Seat Map
        }
        [TestCase]
        public void RT11DaysTest()
        {
            string origin = "Barcelona";
            string destination = "Santiago de Chile";
            int adts = 3;
            int chds = 1;
            int infs = 1;
            string date1 = "01/09/2023";
            string date2 = "12/09/2023";
            string month = "septiembre";
            homePage = new WebPages.HomePage(setUpWebDriver);
            homePage.SelectOrigin(origin);
            homePage.SelectDestination(destination);
            homePage.SelectMonth(month);
            homePage.PickDay(date1);
            homePage.PickDay(date2);
            //Choose Pax
            homePage.ChooseADTs(adts);
            homePage.ChooseCHDs(chds);
            homePage.ChooseINFs(infs);
            homePage.ConfirmPax();
            homePage.ConfirmSubmitSearch();
            //Missing Assert to confirm search
            //Missing Tarifa Economy-Light
            //Missing Assert llegada a Seat Map
        }


    }
}

import { TicketsPage } from "../webpages/TicketsPage"; // Webpage Import
import { FlightsPage } from "../webpages/FlightsPage";
import { PassengersPage } from "../webpages/PassengersPage";
import { SeatsPage } from "../webpages/SeatsPage";

// The container of the tests (must contain the same name as the file)
describe("Flights tests", () => {
  // * let/const for all the tests

  const ticketsPage = new TicketsPage(); // Object of the webpage
  const flightsPage = new FlightsPage();
  const passengersPage = new PassengersPage();
  const seatsPage = new SeatsPage();
  let flightData = {};
  // This will be executed only once before and for all the tests
  before(() => {
    cy.fixture("flightData").then((data)=>{
      flightData = data;
    })
  });
  
  // This will be executed before the execution of every test
  beforeEach(() => {
    
    Cypress.on("uncaught:exception", (err, runnable) => {
      return false;
    });
    cy.visit("/");
  });

  // Independent Test Case
  it("OW BCN-ATH 2ADT 1INF 1st Available in August", () => {
    const origin = flightData.origin;
    const destination = flightData.destination;
    let month = flightData.month;
    const adt = flightData.adt;
    const inf = flightData.inf;
    const operator = flightData.operator;
    const fare = flightData.fare;
    const country = "España"
    let formIndex = 0;
    ticketsPage.acceptCookies();
    ticketsPage.selectOW();
    ticketsPage.selectStations(origin, destination);
    month = month - 1;//Has to be minus 1 because of month's index
    //cy.wait(3000);
    ticketsPage.setLeftMonth(month);
    ticketsPage.selectAvailableDay();
    ticketsPage.selectPassengers(adt, inf);
    ticketsPage.confirmSearch();
    //Assert URL is Select Flights
    //cy.url().should('equal', "https://skysales-bilbo.vueling.com/ScheduleSelectNew.aspx");
    cy.url().should('include', 'ScheduleSelectNew');
    flightsPage.selectFlight(operator);
    flightsPage.selectFare(fare);
    flightsPage.confirmFlights();
    //Assert URL is Fill Passengers Info
    //cy.url().should('include', '/ScheduleSelectNew.aspx');
    //cy.url().should('equal', "https://skysales-bilbo.vueling.com/PassengersInformation.aspx");
    cy.url().should('include', 'PassengersInformation');
    passengersPage.fillPassengersForm(adt, inf, formIndex);
    /*
    passengersPage.fillADTForm(formIndex);
    passengersPage.fillINFForm(formIndex);
    passengersPage.confirmFormInfo(formIndex);
    formIndex++;
    passengersPage.fillADTForm(formIndex);
    passengersPage.confirmFormInfo(formIndex);
    */
    passengersPage.fillContactDetails(country);
    passengersPage.confirmForm();
    //Assert URL is Seat Map
    //cy.url().should('equal', "https://skysales-bilbo.vueling.com/SeatService.aspx");
    cy.url().should('include', 'SeatService');
    seatsPage.selectRandomBabySeat();
    seatsPage.selectRandomSeat();
    seatsPage.confirmSeats();
    //Gets back to homepage

  });

  // This will be executed only once after and for all the tests
  after(() => {});

  // This will be executed after the execution of every test
  afterEach(() => {
    // This will save a screenshot into the screenshots folder
    //cy.screenshot();
  });
});

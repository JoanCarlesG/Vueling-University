import { HomePage } from "../webpages/HomePage"; // Webpage Import

// The container of the tests (must contain the same name as the file)
describe("Flights Test", () => {
  	// * let/const for all the tests

	const homePage = new HomePage(); // Object of the webpage

	// This will be executed only once before and for all the tests
	before(() => {});

	// This will be executed before the execution of every test
	beforeEach(() => {
		Cypress.on("uncaught:exception", (err, runnable) => {
			return false;
		  });
		cy.visit("");
	});

	// Independent Test Case
	it("OW BCN-EZE 2ADT 1INF 1st Available August", () => {
		const origin = "BCN";
		const destination = "EZE";
		
		homePage.selectStations(origin, destination);
		homePage.selectOW();
	});

	// This will be executed only once after and for all the tests
	after(() => {});

	// This will be executed after the execution of every test
	afterEach(() => {
		// This will save a screenshot into the screenshots folder
		//cy.screenshot(`Screenshot_PNR_${pnr}`);
	});
});

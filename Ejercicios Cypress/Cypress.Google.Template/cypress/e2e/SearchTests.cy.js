import { SearchPage } from "../webpages/SearchPage"; // Webpage Import
import { ResultsPage } from "../webpages/ResultsPage"; // Webpage Import

// The container of the tests (must contain the same name as the file)
describe("TC0 => Search tests", () => {
  // * let/const for all the tests

  const searchPage = new SearchPage; // Object of the webpage
  const resultsPage = new ResultsPage;

  // This will be executed only once before and for all the tests
  before(() => {});

  // This will be executed before the execution of every test
  beforeEach(() => {
    // Must be included to go to the specified URL
    cy.visit("/");
    // Path added to the base URL
    //cy.visit("/index.html");
  });

  // Independent Test Case
  it("TC0.1 => Simple GOOGLE search", () => {
    //Variables used only in this test
    const text = "vueling";
    //Steps of the test
    searchPage.skipCookies();
    searchPage.doSearch(text);
    //Final test assert
    resultsPage.matchingResult(text).should("be.visible");
  });

  it("TC0.2 => Lucky GOOGLE search", () => {
    //Variables used in the test
    const text = "vueling";
    //Steps of the test
    searchPage.skipCookies();
    searchPage.doLuckySearch(text);
    //Final test assert
    cy.url().should('include', text)
  });

  // This will be executed only once after and for all the tests
  after(() => {});

  // This will be executed after the execution of every test
  afterEach(() => {
    // This will save a screenshot into the screenshots folder
    //cy.screenshot(`Screenshot_PNR_${pnr}`);
  });
});

/// <reference types='cypress-xpath' />

import "cypress-xpath/src/index";

export class ResultsPage {

  // Elements
  matchingResult = (text) => cy.contains('a', text);

}

/// <reference types='cypress-xpath' />

import "cypress-xpath/src/index";

export class SearchPage {

  // Elements
  btnCookies = () => cy.getId("L2AGLb"); // Search by ID
  searchField = () => cy.getId("APjFqb");
  btnSearch = () => cy.get('input.gNO89b'); // Search by CSS
  btnFeelingLucky = () => cy.get('input.RNmpXc');


  // Methods
  skipCookies(){
    this.btnCookies().click();
  }

  doSearch(text) {
    this.searchField().should("be.visible").click(); // Action click with an assert
    this.searchField().type(text); // Type text in element
    this.btnSearch().last().click();
  }

  doLuckySearch(text){
    this.searchField().should("be.visible").click(); // Action click with an assert
    this.searchField().type(text); // Type text in element
    this.btnFeelingLucky().last().click();
  }
}

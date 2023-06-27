export class FlightsPage {
	// Elements

	flight = (operator) => cy.get(`[codeshare='${operator}']`).parent();
	btnFare = (fare) => cy.getId(fare + "FareBox");
	btnContinue = () => cy.getId("stvContinueButton");

	
	// Methods
	selectFlight(operator){
		this.flight(operator).first().click().should("be.visible");
	}

	selectFare(fare){
		this.btnFare(fare).click().should("be.visible"); 
	}

	confirmFlights(){
		cy.wait(500);  //Page loads async, needs wait to click continue button
		this.btnContinue().click();
	}
	  	
}

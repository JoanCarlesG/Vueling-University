export class HomePage {
    // Elements
    originField = () => cy.get("[data-field='origin']");
	destinationField = () => cy.get("[data-field='destination']");
	tripField = () => cy.get(".switch .lever");
	optionOW = () => cy.get("[value='OW']");
	
    // Methods

    // Start a function
    selectOW() {
		this.tripField().click();
	}

    selectStations(origin, destination) {
		this.originField().type(origin);
		this.destinationField().type(destination);

	}


  }

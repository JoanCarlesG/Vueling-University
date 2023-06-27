export class SeatsPage {
	// Elements

	babyAvailableSeat = () => cy.get('[data_assignable="true"][class="asiento asiento--bebe"]');
	availableSeat = () => cy.get('[data_assignable="true"]');
	btnContinue = () => cy.getId("SeatControlGroup_LinkButtonSubmit");
	
	// Methods

	selectRandomSeat() {
    	this.availableSeat().then((seats) => {
			const numSeats = seats.length;
			const randomIndex = Math.floor(Math.random() * numSeats);
			const randomSeat = seats.eq(randomIndex);
			randomSeat.click();
		});
	}

	selectRandomBabySeat() {
		this.babyAvailableSeat().then((seats) => {
			const numSeats = seats.length;
			const randomIndex = Math.floor(Math.random() * numSeats);
			const randomSeat = seats.eq(randomIndex);
			randomSeat.click();
		});
	}

	confirmSeats(){
		this.btnContinue().click();
	}
  
}

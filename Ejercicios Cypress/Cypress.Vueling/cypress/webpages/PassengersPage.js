export class PassengersPage {
	// Elements

	ADTNameField = (formNumber) => cy.getId(`ContactViewControlGroupMainContact_BoxPassengerInformationView_TextBoxFirstName_${formNumber}`);
	ADTLastNameField = (formNumber) => cy.getId(`ContactViewControlGroupMainContact_BoxPassengerInformationView_TextBoxLastName_${formNumber}`);
	INFNameField = (formNumber) => cy.getId(`ContactViewControlGroupMainContact_BoxPassengerInformationView_TextBoxFirstName_${formNumber}_${formNumber}`);
	INFLastNameField = (formNumber) => cy.getId(`ContactViewControlGroupMainContact_BoxPassengerInformationView_TextBoxLastName_${formNumber}_${formNumber}`);
	INFBirthDateField = (formNumber) => cy.getId(`birthDate${formNumber}_${formNumber}`);
	btnFormReady = (formNumber) => cy.get(`button[position="${formNumber}"]`);

	countryField = () => cy.getId("ContactViewControlGroupMainContact_BoxPassengerInformationView_BoxContactInformationView_DropDownListCountry");
	phoneField = () => cy.getId("ContactViewControlGroupMainContact_BoxPassengerInformationView_BoxContactInformationView_TextBoxHomePhone");
	emailField = () => cy.getId("ContactViewControlGroupMainContact_BoxPassengerInformationView_BoxContactInformationView_TextBoxEmailAddress");
	checkboxPolicy = () => cy.getId("checkboxAcceptsPrivPolLabel");
	btnContinue = () => cy.getId("ContactViewControlGroupMainContact_BoxPassengerInformationView_LinkButtonSubmit");


	// Methods
	
	fillPassengersForm(adt, inf, formNumber){
		let i;
		if(inf > 0){
			for(i = 0; i < inf; i++){
				this.fillADTForm(formNumber);
				this.fillINFForm(formNumber);
				this.confirmFormInfo(formNumber)
				formNumber++;
			}
			for(i = 0; i < (adt-inf); i++){
				this.fillADTForm(formNumber);
				this.confirmFormInfo(formNumber)
				formNumber++;
			}
		}else{
			for(i = 0; i < adt; i++){
				this.fillADTForm(formNumber);
				this.confirmFormInfo(formNumber)
				formNumber++;
			}
		}
	}

	fillADTForm(formNumber){
		this.ADTNameField(formNumber).type("test");
		this.ADTLastNameField(formNumber).type("test");
	}
	fillINFForm(formNumber){
		this.INFNameField(formNumber).type("test");
		this.INFLastNameField(formNumber).type("test");
		formNumber++;
		this.INFBirthDateField(formNumber).type(this.generateBabyBirthdate());
	}
	confirmFormInfo(formNumber){
		formNumber++;
		this.btnFormReady(formNumber).should("be.visible").click();
	}


	
	//Contact details
	fillContactDetails(country){
		this.countryField().select(country);
		this.phoneField().type(this.generateRandomPhone().toString());
		this.emailField().type(this.generateRandomString(5)+"@mailinator.com");
	}
	confirmForm(){
		this.checkboxPolicy().should("be.visible").click();
		this.btnContinue().should("be.visible").click();
	}


	//Generate random info functions
	generateRandomString(length) {
		const characters = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
		let randomString = '';
		for (let i = 0; i < length; i++) {
		  const randomIndex = Math.floor(Math.random() * characters.length);
		  const randomChar = characters.charAt(randomIndex);
		  randomString += randomChar;
		}
		return randomString;
	}

	generateBabyBirthdate() {
		const today = new Date(); // Get the current date
		const birthDate = new Date(); // Between 7 days and 23 months old
		
		birthDate.setMonth(today.getMonth() - 2); // Subtract 2 months from the current date
	  
		const day = String(birthDate.getDate()).padStart(2, '0');
		const month = String(birthDate.getMonth() + 1).padStart(2, '0');
		const year = birthDate.getFullYear();

		const formattedBirthdate = `${day}/${month}/${year}`;

		return formattedBirthdate;
	}
	generateRandomPhone(){
		let randomPhone = Math.floor(Math.random() * 999999999)
		return randomPhone;
	}
}

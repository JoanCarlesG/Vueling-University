export class TicketsPage {
    // Elements
    btnOW = () => cy.getId("AvailabilitySearchInputSearchView_OneWay");
    cookiesButton = () => cy.getId("onetrust-accept-btn-handler");
    fieldOriginStation = () => cy.getId("AvailabilitySearchInputSearchView_TextBoxMarketOrigin1");
    originStation = (origin) => cy.get(`[data-id-code="${origin}"]`)
    fieldDestinationStation = () => cy.getId("AvailabilitySearchInputSearchView_TextBoxMarketDestination1");
    destinationStation = (destination) => cy.get(`[data-id-code="${destination}"]`).last();
    leftMonthCalendar = () => cy.get(`td[data-month]`);
    btnNextMonth = () => cy.get("a.ui-datepicker-next");
    availableDayCalendar = () => cy.get('[data-handler="selectDay"]');
    ADTSelector = () => cy.getId("DropDownListPassengerType_ADT_PLUS")
    ADTOption = (adt) => cy.getId("adtSelectorDropdown").select(`${adt}`);
    INFSelector = () => cy.get('.column_4.buscador_pasajeros_childs');
    INFOption = (inf) => cy.getId("AvailabilitySearchInputSearchView_DropDownListPassengerType_INFANT").select(`${inf}`);
    btnSearchFlights = () => cy.getId("AvailabilitySearchInputSearchView_btnClickToSearchNormal");
    // Methods

    acceptCookies() {
      this.cookiesButton().should("be.visible").click(); // Action click with an assert
    }

    selectOW(){
      //Clicks OW button before station selection
      this.btnOW().click({force:true});
      //this.btnOW().click();

    }

    selectStations(origin, destination){
      //Types origin and destination on fields and clicks on station
      this.fieldOriginStation().type(`${origin}`);
      this.originStation(origin).should("be.visible").click();
      //this.fieldDestinationStation().type(destination, '{enter}');
      this.fieldDestinationStation().type(destination);
      this.destinationStation(destination).click();
    }

    setLeftMonth(month){
      this.leftMonthCalendar().invoke('attr', 'data-month').then(
        ($dataMonth) => {
          if($dataMonth != month){
            this.btnNextMonth().click();
            this.setLeftMonth(month);
          }
        }
      )
    }

    selectAvailableDay(){
      this.availableDayCalendar().first().should("be.visible").click();
    }

    selectPassengers(adt, inf){
      this.ADTSelector().should("be.visible").click();
      this.ADTOption(adt).should("be.visible");
      this.INFSelector().click();
      this.INFOption(inf).should("be.visible");
    }

    confirmSearch(){
      this.btnSearchFlights().should("be.visible").click();
    }

}

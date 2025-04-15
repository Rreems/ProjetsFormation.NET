export class Voiture {
    constructor(licencePlate, startDate = new Date()){
        this.licencePlate = licencePlate
        this.startDate = startDate
        this.endDate = null
    }
}
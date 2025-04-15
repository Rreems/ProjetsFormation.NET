export class Voiture {
    constructor(marque, modele, vitesse){
        this.marque = marque
        this.modele = modele
        this.vitesse = vitesse
    }

    accelerer() {
        this.vitesse += 10
        return `<p>La voiture ${this.marque} accelère de 10 km/h, la nouvelle vitesse est de : ${this.vitesse} km/h</p>`
    }

    tourner() {
        this.vitesse -= 5
        return `<p>La voiture ${this.marque} tourne, la nouvelle vitesse est de : ${this.vitesse} km/h</p>`
    }
}
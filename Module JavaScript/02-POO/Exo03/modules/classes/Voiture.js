export class Voiture {

    constructor(marque, modele, vitesse) {
        this.marque = marque;
        this.modele = modele;
        this.vitesse = vitesse;
    }

    accelerer(){
            this.vitesse += 10
    }

    tourner(){
        if (this.vitesse >= 5){
            
            this.vitesse -= 5
        }
        else {
            this.vitesse = 0
        }
    }
}
import  {Voiture} from "./classes/Voiture.js"

const voitureHaut = document.querySelector(".voiture1")
const voitureBas = document.querySelector(".voiture2")


let voiture1 = new Voiture ("Bmw","Serie 1", 80)
let voiture2 = new Voiture ("Mercedes","GLB", 100)


voiture1.accelerer()
voiture1.accelerer()
voiture1.accelerer()


voiture2.accelerer()
voiture2.accelerer()

voiture2.tourner()
voiture2.tourner()


console.log(voiture1);
voitureHaut.innerHTML  += `Ma super voiture, une ${voiture1.marque} ${voiture1.modele} roule à  ${voiture1.vitesse} cette ZINZIN` ;


console.log(voiture2);
voitureBas.innerHTML  += `Ma super voiture, une ${voiture2.marque} ${voiture2.modele} roule à  ${voiture2.vitesse} cette OUF` ;
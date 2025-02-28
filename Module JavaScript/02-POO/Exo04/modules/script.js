import  {Voiture} from "./classes/Voiture.js"
import  {Vehicule} from "./classes/Vehicule.js"
import  {Moto} from "./classes/Moto.js"

const resultVehicule = document.querySelector(".resultVehicule")


let vehicule1 = new Vehicule ("Tracteur", "KV7", 12000, 1992)
let voiture1 = new Voiture ("Bmw","Serie 1", 140000, 2008, true)
let voiture2 = new Voiture ("Renault","Clio 2", 230000, 2001, false)
let moto1 = new Moto ("Mitsubishi","SuperMoto3°°°", 0, 2025)


console.log(vehicule1);
resultVehicule.innerHTML  += vehicule1.display();

console.log(voiture1);
resultVehicule.innerHTML  += voiture1.display();
resultVehicule.innerHTML  += voiture2.display();

resultVehicule.innerHTML  += moto1.display();

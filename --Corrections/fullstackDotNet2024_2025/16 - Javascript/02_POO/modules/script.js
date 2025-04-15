import { Adherent } from "./classes/Adherent.js";
import {Bibliotheque} from "./classes/Bibliotheque.js"
import { Document } from "./classes/Document.js";
import { Journal } from "./classes/Journal.js";

let m2i = new Bibliotheque("M2I")
let utopios = new Bibliotheque("Utopios")
console.log(m2i);

let lePetitPrince = new Document("Le petit prince")

utopios.ajouterDocument(lePetitPrince)

console.table(utopios.listeDocument);

let toto = new Adherent("toto", "tata")

let leMonde = new Journal("Le monde", "28/02/2025")

console.log(leMonde.toString());
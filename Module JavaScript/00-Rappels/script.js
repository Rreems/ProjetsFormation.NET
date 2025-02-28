
// Déclaration variables
let nom = "Marc" ; // variable "let", anciennement "var" 
const NOMBREREPONSE = 42 ; // constante

// Conditions
if (nom == "Marc"){
    console.log(saluer(nom));
} else if  (nom =="Jean")
{
    console.log("C'est Jean là");
} else
{
    console.log(`C'est ${nom} là`);

}
console.log("lalala");


// Boucles
for (let index = 0; index < 8; index++) {
    console.log(`Tour de boucle: ${index}.`);
    
}

// Fonction
function saluer(personne = "Paul"){
    return `Salut ${personne} ! Ça va ?` ;
}

// Fonction fléchée
const multiplier= (a, b) => a*b ;

console.log("Mutliplication: " + multiplier(2,5));

// Tableaux
let fruits = ["pomme", "banane", "orange"]

fruits.push("clémentine")
console.log(fruits);

fruits.forEach(element => {
    console.log(element);
});
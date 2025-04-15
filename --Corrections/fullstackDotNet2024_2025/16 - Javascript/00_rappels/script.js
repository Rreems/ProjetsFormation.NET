// 1. Déclaration de variables
let nom = "Christophe" // Variable modifiable
const EMAIL = "christophe@email.fr" // Constante (non modifiable)
var ville = "Lille" // Ancienne façon

// 2. Conditions 
let age = 20

if (age >= 18) {
    console.log("Vous êtes majeur !");
} else if (age > 21) {
    console.log("Vous êtes majeur aux USA");
} else {
    console.log("Vous êtes mineur !");
}

// 3. Boucles
for (let i = 0; i < 5; i++){
    console.log(i);
}

let j = 0

while (j < 3) {
    console.log(j);
    j++
}

do {
    console.log(j);
    j++
} while (j < 5)

// 4. Fonctions
function saluer(personne = "Toto"){
    return "Bonjour " + personne
}

console.log(saluer(nom));
console.log(saluer());

// Fonction fléchée
const multiplier = (a,b) => a * b

console.log(multiplier(5, 10));

// 5. Tableaux
let fruits = ["Pomme", "Banane", "Cerise"]

fruits.push("Mangue")
console.table(fruits);
console.log(fruits[0]);

fruits.forEach(fruit => {
    console.log(fruit);
})
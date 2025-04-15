// Les fonctions en ts sont définies de manière similaire à js
// avec l'ajout des types pour les paramètres et le retour
function add(a, b) {
    return a + b;
}
// Paramètres optionnels
// les paramètres d'une fonction peuvent être optionnels en utilisant '?'
// les paramètres optionnels doivent être placés après les paramètres obligatoires
function message(name, message) {
    if (message) {
        return `${name} : ${message}`;
    }
    else {
        return `Bonjour ${name}`;
    }
}
// Fonctions fléchées 
const maFonction = (a, b) => a + b;
// fonction générique
// Les fonctions génériques permettent de définir des fonctions avec des types dynamique
function test(arg) {
    return arg;
}
let outputA = test("Hello");
let outputB = test(5);

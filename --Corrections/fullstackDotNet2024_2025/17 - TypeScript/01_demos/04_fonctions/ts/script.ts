// Les fonctions en ts sont définies de manière similaire à js
// avec l'ajout des types pour les paramètres et le retour

function add (a: number, b : number) : number {
    return a + b
}

// Paramètres optionnels
// les paramètres d'une fonction peuvent être optionnels en utilisant '?'
// les paramètres optionnels doivent être placés après les paramètres obligatoires

function message(name : string, message?: string) : string {
    if(message) {
        return `${name} : ${message}`
    } else {
        return `Bonjour ${name}`
    }
}

// Fonctions fléchées 

const maFonction = (a: number, b: number) : number => a + b

// fonction générique
// Les fonctions génériques permettent de définir des fonctions avec des types dynamique

function test<T>(arg : T) : T {
    return arg
}

let outputA = test<string>("Hello")
let outputB = test<number>(5)
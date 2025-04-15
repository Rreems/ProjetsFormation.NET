// number
// Typescript utilise le type number pour les nombres, il peut s'agir d'un nombre à virgule ou entier
let age = 18;
let pi = 3.14;
// string
let firstname = "toto";
// boolean
let isDone = false;
// void
// le type void est utilisé pour indiquer qu'une fonction ne retourne rien
function message(message) {
    console.log(message);
}
// any
// le type any permet de désactiver le typage d'une variable
// Cela peut être utile quand on veut utiliser une variable sans connaître le type exacte à l'avance
let randomValue = 10;
randomValue = "toto";
// null et undefined
let a = undefined;
let b = null;
// tableaux :
let tab = [1, 2, 3, 4];
let fruits = ["pomme", "orange"];
// tuple
// Les tuples permettent de créer un tableau de taille fixe avec un type spécifique pour chaque élément
let person;
person = ["Toto", 30, "toto@email.fr"];
// enum
// Les énumérations permettent de définir un ensemble de valeur
var Color;
(function (Color) {
    Color[Color["Red"] = 0] = "Red";
    Color[Color["Green"] = 1] = "Green";
    Color[Color["Blue"] = 2] = "Blue";
})(Color || (Color = {}));
let color = Color.Blue;
// unknown
// le type unknown est similaire au any, mais plus sécurisé
// avant d'utiliser une variable de type unknown, il faut vérifier le type
let varA = 4;
varA = "Hello world";
// varA.toUpperCase() // erreur
if (typeof varA == "string") {
    console.log(varA.toUpperCase());
}

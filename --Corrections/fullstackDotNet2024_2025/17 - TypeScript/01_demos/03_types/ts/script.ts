// number

// Typescript utilise le type number pour les nombres, il peut s'agir d'un nombre à virgule ou entier
let age : number = 18
let pi : number = 3.14

// string

let firstname : string = "toto"

// boolean

let isDone : boolean = false

// void
// le type void est utilisé pour indiquer qu'une fonction ne retourne rien

function message(message: string) : void {
    console.log(message);
}

// any
// le type any permet de désactiver le typage d'une variable
// Cela peut être utile quand on veut utiliser une variable sans connaître le type exacte à l'avance

let randomValue : any = 10
randomValue = "toto"

// null et undefined

let a : undefined = undefined
let b : null = null

// tableaux :
let tab: number[] = [1,2,3,4]
let fruits : string[] = ["pomme", "orange"]

// tuple
// Les tuples permettent de créer un tableau de taille fixe avec un type spécifique pour chaque élément

let person : [string, number, string]
person = ["Toto", 30, "toto@email.fr"]

// enum
// Les énumérations permettent de définir un ensemble de valeur

enum Color {
    Red,
    Green,
    Blue
}

let color: Color = Color.Blue

// unknown
// le type unknown est similaire au any, mais plus sécurisé
// avant d'utiliser une variable de type unknown, il faut vérifier le type

let varA: unknown = 4
varA = "Hello world"

// varA.toUpperCase() // erreur

if (typeof varA == "string") {
    console.log(varA.toUpperCase());
}
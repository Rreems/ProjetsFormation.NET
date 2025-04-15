// Interfaces 

// Une interface est contrat qui définit la forme de notre objet, elle définie les propriétés et leurs types

// Certaines propriétées peuvent être optionelles avec le symbole '?'
interface User {
    id: number,
    name: string,
    email?: string,
    isActive: boolean
}

let user : User = {
    id: 1,
    name: "Toto",
    email : "toto@email.fr",
    isActive: true
}

// readonly
// Les propriétées en readonly empêche la modification après leur initialisation

interface User2 {
    readonly id: number,
    name: string
}

let user2 : User2 = {
    id: 2,
    name: "Tata"
}

// user2.id = 3 // erreur : id est en lecture seule
user.id = 5
console.log(user2.id);

// type Alias
// le type alias est une manière de définir un type personnalisé

type UserOrNull = User | null

let userA: UserOrNull = null
let userB: UserOrNull = {
    id: 1,
    name: "test",
    isActive : false
}

type Status = "active" | "inactive" | "suspendu"

let userStatus : Status = "suspendu"
// let userStatus : Status = "en cours" // erreur

// Intersection : combine plusieurs types ensemble

type Admin = {
    adminLevel: number,
    mdp: string
}

type AdminUser = User & Admin

let admin: AdminUser = {
    id: 1,
    name: "Toto",
    isActive: true,
    adminLevel: 5,
    mdp: "123"
}
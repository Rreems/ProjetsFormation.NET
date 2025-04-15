class User {
    // propriétes
    id: number
    name: string
    email: string
    isActive: boolean

    constructor(id: number, name: string, email: string){
        this.id = id
        this.name = name
        this.email = email
    }

    // méthodes
    getDetails(): string {
        return `ID : ${this.id}, Name : ${this.name}, email: ${this.email}`
    }
}

// Instanciation

let user = new User(1, "toto", "toto@email.fr")

// Modificateur d'accès :

// public : Par défaut, accessible partout
// private : accessible uniquement à l'intérieur de la classe
// protected : accessible dans la classe et dans les classes enfants

class User2 {
    readonly id : number
    private name : string
    protected email: string
}
export class Bibliotheque{

    // attributs
    constructor (nom){
        this.nom = nom ;
        this.listDocument = [];


        console.log(this.messageHello());
    }


    // Méthodes
    messageHello(){
        return `Hello, bienvenu dans la bibliotheque ${this.nom} !` ;
    }

    ajoutDoc(doc){
        this.listDocument.push(doc);
        console.log(`${doc.titre} est ajouté à la bibliothèque ${this.nom}`);
    }

}
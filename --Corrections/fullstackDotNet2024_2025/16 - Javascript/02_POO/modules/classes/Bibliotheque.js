export class Bibliotheque {
    // attributs
    constructor(nom){
        this.nom = nom
        this.listeDocument = []
        console.log(this.messageBienvenue());
    }

    // Méthodes
    messageBienvenue(){
        return `Bienvenue dans la bibliotheque : ${this.nom} !`
    }

    ajouterDocument(document){
        this.listeDocument.push(document)
        console.log(`${document.titre} est ajouté à la bibliotheque ${this.nom}`);
    }
}
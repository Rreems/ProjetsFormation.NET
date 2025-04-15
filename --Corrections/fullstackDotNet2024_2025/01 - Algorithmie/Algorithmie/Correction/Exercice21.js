
let nbEtudiant = 3
let nbMatieres = 2
let notes = []
let etudiants = ["toto","tatat","titi"]
let matieres = ["java","C#"]

for(let i = 0; i<nbEtudiant ; i++){
    let tableauDeNote = []
    for(let j =0; j<nbMatieres; j++){
        tableauDeNote.push(Number(prompt("Entrer la note de "+etudiants[i]+" pour la matiere "+matieres[j])))
    }
    notes.push(tableauDeNote)
}

for(let i = 0; i<nbEtudiant ; i++){
    for(let j =0; j<nbMatieres; j++){
        console.log("La note de "+etudiants[i]+" pour la matiere "+matieres[j] + " est : "+notes[i][j])
    }
}

let min 
let max
let total = 0
let nbNotes = 5

for(let i = 1; i<=nbNotes;i++){
    let note = Number(prompt("Entrer la note n°"+i))
    if(i == 1){
        min = note
        max = note
    }

    if(note < min){
        min = note
    }
    if(note>max){
        max = note
    }

    total += note
}

let exit = false;
while(!exit){
    let input = prompt("1/Afficher la plus petite note \n2/Afficher la plus grande note\n3/Afficher la moyenne des notes")

    switch(input){
        case "1":
            alert("La plus petite note est : "+min)
            break
        case "2":
            alert("La plus grande note est : "+max)
            break
        case "3":
            alert("La moyenne des notes est : "+ (total/nbNotes))
            break
        default:
            exit = true
    }
}

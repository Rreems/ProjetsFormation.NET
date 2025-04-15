let nb_mystere = getRandomInt(101)
let nb_essai = 5
let valeur_trouve = false

function getRandomInt(max) {
    return Math.floor(Math.random() * max);
}

console.log(nb_mystere);


do{
    let input = Number(prompt("Entrer une valeur entre 1 et 100"))
    if(input>0 && input<101){
        if(input == nb_mystere){
            valeur_trouve = true
            nb_essai--
        }else{
            if(input>nb_mystere){
                alert("Valeur superieur au nombre mystere")
            }else{
                alert("Valeur inferieur au nombre mystere")
            }
            nb_essai--
        }
    }else{
        alert("Valeur incorrecte")
    }
}while(nb_essai>0 && !valeur_trouve)


if(valeur_trouve){
    alert("Bravo vous avez trouvé le nombre mystere ! en "+ (5 - nb_essai)+" essai(s)")
}else{
    alert("Vous n'avez pas trouvé le nombre mystere : "+ nb_mystere)
}


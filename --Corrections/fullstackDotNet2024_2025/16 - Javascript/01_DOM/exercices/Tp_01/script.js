let nbUser, nbMystere, nbCoups, gagne

// Récupération des éléments du DOM
const submit = document.querySelector(".submit")
const replay = document.querySelector(".replay")
const message = document.querySelector(".message")
const nbCoupsHtml = document.querySelector(".nbCoups")
const nbUserHtml = document.querySelector(".nbUser")

function startGame() {
    // Génération de nombre aléatoire
    nbMystere =Math.round(Math.random() * (50 - 1) + 1);
    console.log(nbMystere);

    // Initialisation des champs HTML
    nbCoups = 0
    message.innerHTML = "Essayez de deviner en proposant ci-dessous"
    nbUserHtml.value = ""
    nbCoupsHtml.innerHTML = 0
    gagne = false
    submit.disabled = false 
}

function updateNbCoups(){
    nbCoups++
    nbCoupsHtml.innerHTML = nbCoups
}

function endGame(){
    message.innerHTML = `Bravo vous avez gagné en ${nbCoups} coups, le nombre mystère était ${nbMystere}`
    gagne = true
    submit.disabled = true 
}

function valider(){
    nbUser = nbUserHtml.value

    if(nbUser <= 0 || nbUser > 50){
        message.innerHTML = "le nombre doit être entre 1 et 50 inclus" 
    } else if (nbUser > nbMystere) {
        updateNbCoups()
        message.innerHTML = "C'est moins !" 
    } else if (nbUser < nbMystere) {
        updateNbCoups()
        message.innerHTML = "C'est plus !" 
    } else if (nbUser == nbMystere) {
        updateNbCoups()
        endGame()
    }
    nbUserHtml.value = ""
}

document.addEventListener("keydown", (event) => {
    if(event.key == "Enter" && !gagne){
        valider()
    }
})

// window.onload permet de déclencher une fonction au chargement de la page
window.onload = startGame()


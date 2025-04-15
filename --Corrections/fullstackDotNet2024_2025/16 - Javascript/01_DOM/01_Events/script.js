// DOM => Document Object Model
let message = document.querySelector(".inputText")

function myButtonClick(){
    alert("Vous avez cliqué sur le bouton")
}

function onMouseOver(){
    alert("Vous avez survolé le bouton")
}

function onDblClick(){
    alert("Vous avez cliqué deux fois sur le bouton")
}

function functionArg(arg){
    switch(arg){
        case 1: alert("Vous avez cliqué sur le bouton 1"); break;
        case 2: alert("Vous avez cliqué sur le bouton 2"); break;
        case 3: alert("Vous avez cliqué sur le bouton 3"); break;
        case 4: alert("Vous avez cliqué sur le bouton 4"); break;
    }
}

// écoute le clavier de l'utilisateur, si l'utilisateur utilise la touche Enter, ça déclenche un événement.
document.addEventListener("keydown", (event) => {
    // console.log(event.key);
    if (event.key == "Enter"){
        alert("Vous avez appuyé sur Enter \nMessage : " + message.value)
        message.value = ""
    }
})

// écoute la souris de l'utilisateur pour déclencher un event
document.addEventListener("click", (event) => {
    // Récupération du "data-key"
    console.log(event.target.dataset.key);
    message.value = event.target.dataset.key
})
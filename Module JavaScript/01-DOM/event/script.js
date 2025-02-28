
// DOM => Document Object Model



function myButtonClick() {
    console.log("Clic");
}

function myButtonOver() {
    console.log("Survolage");
    // alert("Spammmmm")
}

function myButtonDblClick() {
    alert("Beau double-click !");
}

function functionArg(arg) {
    switch (arg) {
        case 1: alert("Fonction bouton 1"); break;
        
        case 2: alert("Fonction bouton 2"); break;
        
        case 3: alert("Fonction bouton 3"); break;
        
        default:
            console.log("Bof.");
            break;
        }
    }
    
let message;

// ecoute le clavier pour déclencher l'event
document.addEventListener("keydown", (event) => {
    // console.log(event.key);
    message = document.querySelector(".inputText")

    if (event.key == "Enter") {
        alert("Vous avez appuyé sur Enter. \nMessage: " + message.value)
        message.value = "Message secret 🤫"
    }
})

// ecoute souris pour déclencher l'event
document.addEventListener("click", (event) => {
    message = document.querySelector(".inputText")

    if (event.target.dataset.key != undefined) {
        console.log("Datakey: " + event.target.dataset.key);
        message.value = event.target.dataset.key ;
    }
})
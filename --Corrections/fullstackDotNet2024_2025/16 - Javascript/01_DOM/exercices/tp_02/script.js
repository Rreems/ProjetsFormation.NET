// ... => spread operator = copie d'un tableau
const touches = [...document.querySelectorAll(".bouton")]
const listDataKey = touches.map((bouton) => bouton.dataset.key)
const ecranHaut = document.querySelector(".ecranHaut")
const ecranBas = document.querySelector(".ecranBas")


touches.forEach((bouton) => {
    bouton.addEventListener("click", (event) => {
        calculer(event.target.dataset.key);
    })
})

document.addEventListener("keydown", (event) => {
    let valeur = event.key
    if(listDataKey.includes(valeur)){
        calculer(valeur)
    }
})

function calculer(valeur) {
    switch (valeur) {
        case "Backspace": // Touche 'C'
            ecranHaut.innerHTML = ""
            ecranBas.innerHTML = ""
            break;
        case "Enter": // Touche '='
            let resultat = eval(ecranHaut.textContent)
            ecranBas.innerHTML = `= ${resultat}`
            break;
        default:
            ecranHaut.innerHTML += valeur
            break;
    }
}
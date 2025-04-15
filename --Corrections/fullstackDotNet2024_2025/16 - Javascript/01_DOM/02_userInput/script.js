const result = document.querySelector(".result")
const prenom = document.querySelector(".prenom")
const nom = document.querySelector(".nom")

function valider(){
    result.innerHTML = `<h1>${prenom.value} ${nom.value}</h1>`
    result.innerHTML += "<p>test</p>"
}
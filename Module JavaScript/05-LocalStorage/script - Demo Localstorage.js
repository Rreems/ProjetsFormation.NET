// const apiUrl = "https://pokeapi.co/api/v2/pokemon";

const btnTest = document.querySelector(".btn-test");


btnTest.addEventListener("click", (event) => {

});


// Enregistrer données en LocalStorage
localStorage.setItem("nom", "toto");

// Lecture/récup 
let nom = localStorage.getItem("nom");
console.log(nom);

// Supprimer données
// localStorage.removeItem("nom")

// Vider complètement le Local Storage
// localStorage.clear();


// Stockage des objets 
let user = {
    id : 1,
    name: "toto"
}

localStorage.setItem("user", JSON.stringify(user));

let user2 = JSON.parse(localStorage.getItem("user"));
console.log(user2);
// Enregister une donnée dans le localStorage
// localStorage.setItem("username", "Toto")

// Récup depuis le localStorage
// let username = localStorage.getItem("username")
// console.log(username);

// // localStorage.setItem("config", "test")

// // Supprimer une donnée de mon localStorage
// localStorage.removeItem("config")

// // Vider le localStorage :
// localStorage.clear()

let user = {
    id: 1,
    name: "toto"
}

// localStorage.setItem("user", JSON.stringify(user))

let user2 = JSON.parse(localStorage.getItem("user"))

console.log(user2.name);
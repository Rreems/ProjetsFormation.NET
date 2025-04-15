// Interfaces 
let user = {
    id: 1,
    name: "Toto",
    email: "toto@email.fr",
    isActive: true
};
let user2 = {
    id: 2,
    name: "Tata"
};
// user2.id = 3 // erreur : id est en lecture seule
user.id = 5;
console.log(user2.id);
let userA = null;
let userB = {
    id: 1,
    name: "test",
    isActive: false
};
let userStatus = "suspendu";
let admin = {
    id: 1,
    name: "Toto",
    isActive: true,
    adminLevel: 5,
    mdp: "123"
};

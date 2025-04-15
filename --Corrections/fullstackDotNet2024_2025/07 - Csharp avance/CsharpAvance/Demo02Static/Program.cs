using Demo02Static.Classes;

Dinosaure[] dinoArray = {
    new Dinosaure(nom: "Denver", age: 10, espece: "Corythosaurus"),
    new Dinosaure("Petit-Pied", 12, "Apatosaurus")
};

Console.WriteLine(Dinosaure.NombreDeDinos);

new Dinosaure("Petit-Pied", 12, "Apatosaurus");
var dino = new Dinosaure("Petit-Pied", 12, "Apatosaurus");

Console.WriteLine(Dinosaure.NombreDeDinos);


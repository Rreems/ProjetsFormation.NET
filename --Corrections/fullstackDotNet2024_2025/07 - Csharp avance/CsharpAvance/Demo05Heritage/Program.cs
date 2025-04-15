using Demo05Heritage;

Animal animal = new Animal("an1", true);
Mammifere mammifere = new Mammifere("mam1", true, "femelle");

animal.SeDeplacer();
Console.WriteLine(animal.Nom);
mammifere.SeDeplacer();
Console.WriteLine(mammifere.Nom);

Animal mammifereAnimal = mammifere;

animal.Respirer();          // un animal qui respire => "L'animal respire"
mammifere.Respirer();       // un mammifere qui respire => "Le mammifere respire"
mammifereAnimal.Respirer(); // un mammifere qui respire MAIS dans une variable Animal =>"L'animal respire"
// cette dernière ligne est un Probleme généré par le Masquage (new)


List<Animal> list = new List<Animal>()
{
    animal,
    mammifere,
    mammifereAnimal
};

foreach (Animal an in list)
{
    an.Respirer(); // on aura toujours "L'animal respire" A CAUSE du masquage
}
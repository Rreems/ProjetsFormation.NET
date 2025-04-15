using Demo01Classe.Classes;

////// instanciation => appel au constructeur
//Dinosaur monDino = new Dinosaur(); // ici le constructeur par défaut car pas de paramêtres

//Console.WriteLine(monDino.Nom);
//Console.WriteLine(monDino.Age);


//Console.WriteLine("---------------------");

//Console.WriteLine("Set des valeurs :");
//monDino.Age = 10;
//monDino.Poids = 100;

//Console.WriteLine("---------------------");

//Console.WriteLine("write de l'age : " + monDino.Age);
//Console.WriteLine("write du poids : " + monDino.Poids);


//Console.WriteLine("---------------------");

//Console.WriteLine("Set d'un poids invalide :");
//monDino.Poids = -10000;

//Console.WriteLine("---------------------");

//monDino.PeutVoler = false;

//Console.WriteLine(monDino.PeutVoler);


//Console.WriteLine("---------------------");

//monDino.Nom = "Guillaume";
//Console.WriteLine(monDino.Nom);


//Console.WriteLine("---------------------");

Dinosaure dino = new Dinosaure(210, "TRex", 2, 10, "Carnivore", "Rex");
//Dinosaure dino = new Dinosaure();

Console.WriteLine(dino.Nom);
Console.WriteLine(dino.RegimeAlimentaire);

Console.WriteLine(dino); // type de la variable


Console.WriteLine("---------------------");


dino.Afficher();
dino.Afficher();
dino.Afficher();
dino.Afficher();

Console.WriteLine("---------------------");
dino.SEnvoler();

using Exo07Pile;

Pile2<string> pileString = new Pile2<string>();

pileString.Empiler("Bonjour");
pileString.Empiler("Test");
pileString.Empiler("ABC");

Console.WriteLine(pileString);

Console.WriteLine(pileString.Depiler());
Console.WriteLine(pileString.Depiler());

Console.WriteLine(pileString);

pileString.Empiler("ABC1");
pileString.Empiler("ABC2");

Console.WriteLine(pileString);

Console.WriteLine("1 -> " + pileString.Recuperer(1));
Console.WriteLine("2 -> " + pileString.Recuperer(2));

Console.WriteLine(pileString);

Pile<Personne> pilePersonne = new Pile<Personne>();


pilePersonne.Empiler(new Personne());
pilePersonne.Empiler(new Personne());

Personne maPersonne = new Personne();
maPersonne.Prenom = "Guillaume";
maPersonne.Nom = "Mairesse";
maPersonne.Age = 56;

// équivalent, très souvent utilisé par la communauté du C#
Personne maPersonne2 = new Personne()
{
    Prenom = "Guillaume",
    Nom = "Mairesse",
    Age = 56
};

pilePersonne.Empiler(maPersonne2);
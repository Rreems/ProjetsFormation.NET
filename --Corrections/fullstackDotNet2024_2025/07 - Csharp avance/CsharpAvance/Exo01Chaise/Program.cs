using Exo01Chaise;

//Chaise chaise1 = new Chaise();
//Chaise chaise2 = new Chaise(2, "Métal", "Noire");
//Chaise chaise3 = new Chaise(6, "Plastique", "Bleue");

//chaise1.Afficher();
//chaise2.Afficher();
//chaise3.Afficher();

//Console.WriteLine(chaise3); // par défaut : Exo01Chaise.Chaise
//Console.WriteLine(chaise3.ToString()); // équivalent

//Chaise[] tabDeChaises = new Chaise[3];
//tabDeChaises[0] = new Chaise();
//tabDeChaises[1] = new Chaise(2, "Métal", "Noire");
//tabDeChaises[2] = new Chaise(6, "Plastique", "Bleue");


Chaise[] tabDeChaises =
[
    new Chaise(),
    new Chaise(2, "Métal", "Noire"),
    new Chaise(6, "Plastique", "Bleue"),
];

List<Chaise> listDeChaises = new List<Chaise>()
{
    new Chaise(),
    new Chaise(2, "Métal", "Noire"),
    new Chaise(6, "Plastique", "Bleue"),
};

//foreach (Chaise chaise in tabDeChaises)
foreach (Chaise chaise in listDeChaises)
{
    Console.WriteLine(chaise);
    chaise.Afficher();
}

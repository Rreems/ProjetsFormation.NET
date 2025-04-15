using ExerciceVols.Classes;

Ville paris = new Ville("Paris");
Ville lille = new Ville("Lille");
Ville marseille = new Ville("Marseille");
Ville lyon = new Ville("Lyon");
Ville bruxelles = new Ville("Bruxelles");
Ville bordeaux = new Ville("Bordeaux");

List<Ville> villes = new List<Ville>() 
{
   paris,
   lille,
   marseille,
   lyon,
   bruxelles,
   bordeaux,
};

List<VolDirect> volDirects= new List<VolDirect>()
{
    new VolDirect(SaisieVille(villes), SaisieVille(villes), SaisieJour(), SaisieHeure()),
    new VolDirect(paris, marseille, Jour.Lundi, 8),
    new VolDirect(paris, lyon, Jour.Jeudi, 17),
    new VolDirect(marseille, lyon, Jour.Mardi, 20),
    new VolDirect(paris, bruxelles, Jour.Lundi, 4),
};

VolsSemaine volsSemaine23 = new VolsSemaine(volDirects, 23, 2023);

Console.WriteLine(volsSemaine23);

Console.WriteLine("Paris appartient au plan de vol ? =>" + volsSemaine23.Appartient(paris));
Console.WriteLine("Bruxelles appartient au plan de vol ? =>" + volsSemaine23.Appartient(bruxelles));
Console.WriteLine("Bordeaux appartient au plan de vol ? =>" + volsSemaine23.Appartient(bordeaux));

List<Ville> destinationsDeParis = volsSemaine23.ListeSuccesseurs(paris);

Console.WriteLine("La liste des destinations à partir de Paris est : {'" + string.Join("', '", destinationsDeParis) + "'}");

// exemples pour les fonctions de saisie
Jour SaisieJour()
{
    Jour jour;
    Console.WriteLine("Meri de saisir un jour valide");
    while (!Enum.TryParse<Jour>(Console.ReadLine(), out jour) ) // méthode sensible à las casse (maj/min)
        Console.WriteLine("Saisie Invalide ! Réésayer :");
    return jour;
}
int SaisieHeure()
{
    int heure;
    Console.WriteLine("Meri de saisir une heure valide");
    while (!(int.TryParse(Console.ReadLine(), out heure) && heure>=0 && heure <=23 ))
        Console.WriteLine("Saisie Invalide ! Réésayer :");
    return heure;
}
Ville SaisieVille(List<Ville> villesExistantes)
{
    Ville ville;
    Console.WriteLine("Meri de saisir une ville Parmis celles-ci:");
    foreach (var v in villesExistantes)
        Console.WriteLine($"- {v}");
    string villeStr = Console.ReadLine()!.ToLower();
    while (villesExistantes.FirstOrDefault(v => v.Nom.ToLower() == villeStr.ToLower()) == null)
    {
        Console.WriteLine("Saisie Invalide ! Réésayer :");
        villeStr = Console.ReadLine()!.ToLower();
    }
    return villesExistantes.FirstOrDefault(v => v.Nom.ToLower() == villeStr.ToLower())!;
}
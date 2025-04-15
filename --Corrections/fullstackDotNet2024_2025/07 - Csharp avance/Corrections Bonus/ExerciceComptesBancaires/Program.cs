using ExerciceComptesBancaires.Classes;
using ExerciceComptesBancaires.Classes.Comptes;

Client client = new Client("Mairesse", "Guillaume", "FR00 1234 5678 9123 4567 8912 345");
Console.WriteLine("Client :");
Console.WriteLine(client);

Console.WriteLine("--------------------");

var compte = new CompteCourant(client);

client.CompteBancaires.Add(compte);
client.CompteBancaires.Add(new CompteEpargne(client));
client.CompteBancaires.Add(new ComptePayant(client));

Console.WriteLine("Comptes du client :");
foreach (CompteBancaire compteBancaire in client.CompteBancaires)
    Console.WriteLine(compteBancaire);

Console.WriteLine("--------------------");

Console.WriteLine("Opération sur le premier compte :");
Console.WriteLine("Dépot de 2000");
compte.Depot(2000);
Console.WriteLine(compte);

Console.WriteLine("--------------------");

Console.WriteLine("Retrait de 90000?");
bool reussite = compte.Retrait(90000);
Console.WriteLine("Réussi ? " + reussite);
Console.WriteLine(compte);

Console.WriteLine("--------------------");

Console.WriteLine("Retrait de 500");
compte.Retrait(500);
Console.WriteLine(compte);
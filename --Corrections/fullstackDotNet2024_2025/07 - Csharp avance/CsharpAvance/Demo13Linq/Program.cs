
//List<int> mesNombres = new List<int> { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
//mesNombres.ForEach(Console.WriteLine);

//// équivalent Linq
//List<int> mesNombres2 = Enumerable.Range(2, 10).ToList();
//mesNombres2.ForEach(Console.WriteLine);


////SELECT

//using Demo13Linq;

//List<int> mesNombres = Enumerable.Range(2, 10).ToList();

////List<int> mesNombresAuCarre = mesNombres.Select(n => n * n).ToList();
//List<int> mesNombresAuCarre = mesNombres.Select(n => n * n)
//                                        .ToList();
//List<double> mesNombresEnDouble = mesNombres.Select(n => (double) n)
//                                        .ToList();

//mesNombresAuCarre.ForEach(Console.WriteLine);

//Console.WriteLine("---------------------");

////double[] tableau = mesNombres.Select(n => (double)n).ToArray();


//// WHERE
//List<int> nombresPairs2 = mesNombres.Where(x => x % 2 == 0).ToList();
//nombresPairs2.ForEach(Console.WriteLine);

//// équivalent C# classique
//List<int> nombresPairs = new();
//foreach (int n in mesNombres)
//{
//    if (n % 2 == 0) nombresPairs.Add(n);
//}
//nombresPairs.ForEach(Console.WriteLine);


//Console.WriteLine("---------------------");

using Demo13Linq;

List<Personne> mesPersonnes = new()
{
 new() { Nom = "DUPONT", Prenom = "John", Age = 47, Email = "j.dupont@gmail.com", Phone = "+33 147 741 256"},
 new() { Nom = "SCHMIDT", Prenom = "Martha", Age = 29, Email = "m.schmit@hotmail.com", Phone = "+33 159 236 478"},
 new() { Nom = "DUPONT", Prenom = "Chloé", Age = 16, Email = "c.dupont@gmail.com", Phone = "+33 125 896 478"},
 new() { Nom = "DUPONTE", Prenom = "Chloé", Age = 120, Email = "c.duponte@gmail.com", Phone = "+33 125 896 479"},
 new() { Nom = "MALTEZ", Prenom = "Clark", Age = 47, Email = "c.martez@aol.com", Phone = "+32 147 852 369"},
 new() { Nom = "MALTEZ", Prenom = "Clark", Age = 47, Email = "c.martez@aol.com", Phone = "+32 147 852 369"},
 new() { Nom = "MALTEZ", Prenom = "Clark", Age = 47, Email = "c.martez@aol.com", Phone = "+32 147 852 369"},
 new() { Nom = "MALTEZ", Prenom = "Clark", Age = 47, Email = "c.martez@aol.com", Phone = "+32 147 852 369"},
 new() { Nom = "MALTEZ", Prenom = "Clark", Age = 47, Email = "c.martez@aol.com", Phone = "+32 147 852 369"},
};

//// RECHERCHER UNE entrée dans la collection

//// avec C#
//Personne? chloe = mesPersonnes.Find(x => x.Prenom == "Chloé");
//Personne chloeParDefaut = mesPersonnes.Find(x => x.Prenom == "Chloé") ?? new() { Nom = "DÉFAUT", Prenom = "Chloé" };

//Console.WriteLine(chloe);

//// avec Linq

//// On peut chercher dans le listing à partir du début
//Personne chloeAvecLinq = mesPersonnes.First(x => x.Prenom == "Chloé"); // erreur si non trouvé
//Personne? chloeAvecLinqNullable = mesPersonnes.FirstOrDefault(x => x.Prenom == "Chloé"); // null si non trouvé
//Console.WriteLine(chloeAvecLinq);
//Console.WriteLine(chloeAvecLinqNullable);

//// A partir de la fin
//Personne chloeAPartirDeLaFin = mesPersonnes.Last(x => x.Prenom == "Chloé");
//Personne? chloeAPartirDeLaFinNullable = mesPersonnes.LastOrDefault(x => x.Prenom == "Chloé");
//Console.WriteLine(chloeAPartirDeLaFin);
//Console.WriteLine(chloeAPartirDeLaFinNullable);


//// A partir du début et s'assurer des non doublons de notre critère
//Personne laSeuleEtUniqueChloe = mesPersonnes.Single(x => x.Prenom == "Chloé");
//Personne? laSeuleEtUniqueChloeNullable = mesPersonnes.SingleOrDefault(x => x.Prenom == "Chloé");
//Console.WriteLine(laSeuleEtUniqueChloe);
//Console.WriteLine(laSeuleEtUniqueChloeNullable);


// TRI

mesPersonnes.OrderBy(x => x.Age)
            .ToList()
            .ForEach(Console.WriteLine);

Console.WriteLine("---------------------");

mesPersonnes.OrderByDescending(x => x.Age)
            .ToList()
            .ForEach(Console.WriteLine);

Console.WriteLine("---------------------");

mesPersonnes.OrderBy(x => x.Nom)
            .OrderBy(x => x.Prenom)
            .ToList()
            .ForEach(Console.WriteLine);


Console.WriteLine("---------------------");

mesPersonnes.OrderBy(x => x.Nom)
            .ThenBy(x => x.Prenom)
            .ToList()
            .ForEach(Console.WriteLine);

Console.WriteLine("---------------------");

IEnumerable<Personne> personneLaPlusJeune = mesPersonnes.OrderBy(x => x.Age).Take(1);
personneLaPlusJeune.ToList().ForEach(Console.WriteLine);
personneLaPlusJeune.ToList().ForEach(p => Console.WriteLine(p));


Console.WriteLine("---------------------");

int noPage = 1;
int nbElem = 2;
var personnesALaPageX = mesPersonnes.Skip(nbElem * (noPage - 1))
                                    .Take(nbElem);
personnesALaPageX.ToList().ForEach(Console.WriteLine);

Console.WriteLine("---------------------");

// Aggrégation => une seule valeur résultat

Console.WriteLine(mesPersonnes.Sum(x => x.Age));
Console.WriteLine(mesPersonnes.Max(x => x.Age));
Console.WriteLine(mesPersonnes.Min(x => x.Age));
Console.WriteLine(mesPersonnes.Average(x => x.Age));

Console.WriteLine(mesPersonnes.Where(p => p.Age <= 60).Average(x => x.Age));

Console.WriteLine("---------------------");

Func<string, Personne, string> foncAggregation = (concat, element) =>
{
    if (mesPersonnes.Last() != element) return concat + element.Nom.Substring(0, 1).ToUpper() + ", ";
    return concat + element.Nom.Substring(0, 1).ToUpper();
};

string chaineDesInitiales = mesPersonnes.Aggregate("Liste des initiales : ", foncAggregation);


Console.WriteLine(chaineDesInitiales);

Console.WriteLine("---------------------");

Func<int, int, int> max = (a, b) => a > b ? a : b;

Console.WriteLine(Enumerable.Range(0, 100).Aggregate(max));
Console.WriteLine(Enumerable.Range(0, 100).Aggregate(15000, max));


Console.WriteLine(Enumerable.Range(1, 100).Aggregate(1,(a,b) => a + b));


Console.WriteLine("---------------------");

IEnumerable<string> personnes = from p in mesPersonnes
                                where p.Age > 20
                                select $"{p.Prenom} {p.Nom}";

personnes.ToList().ForEach(Console.WriteLine);


(from p in mesPersonnes
 where p.Age > 20
 select $"{p.Prenom} {p.Nom}").ToList()
                              .ForEach(Console.WriteLine);
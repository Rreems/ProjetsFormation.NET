/*

# TP 3 - LINQ

### Exercices LINQ to Objects

Voici une liste de 14 exercices progressifs basés sur une liste d'objets `Person`. Chaque `Person` a les propriétés suivantes : `Id`, `Name`, `Age`, et `City`.

#### Données initiales
```csharp
using Person = (int Id, string Name, int Age, string City);

var people = new List<Person>
{
    (1, "Alice", 25, "Paris"),
    (2, "Bob", 30, "Lyon"),
    (3, "Charlie", 35, "Marseille"),
    (4, "Diana", 40, "Paris"),
    (5, "Eve", 28, "Lyon"),
    (6, "Frank", 33, "Paris")
};
```

#### Exercices

1. * *Trouver toutes les personnes de Paris.**
2. **Trouver les noms des personnes ayant plus de 30 ans.**
3. **Trier les personnes par âge croissant.**
4. **Compter le nombre de personnes vivant à Lyon.**
5. **Trouver la personne la plus âgée.**
6. **Obtenir une liste des villes distinctes.**
7. **Vérifier si toutes les personnes ont plus de 20 ans.**
8. **Projeter une nouvelle liste contenant uniquement les noms et âges.**
9. **Trouver le nom de la personne la plus jeune vivant à Paris.**
10. **Grouper les personnes par ville et afficher le nombre de personnes dans chaque ville.**
11. **Créer une séquence infinie de nombres pairs et récupérer les 10 premiers.**  
12. **Paginer une liste de nombres de 1 à 100 pour obtenir le 3ème bloc de 10 nombres (21 à 30).**
13. **Trouver le nombre maximum dans une liste d'entiers.** `[4, 8, 15, 16, 23, 42]`
14. **Filtrer les mots d'une liste contenant plus de 5 lettres.** `["chat", "ordinateur", "table", "lampe", "programme"]`

*/


using Exo08Linq;
using Person = (int Id, string Name, int Age, string City);

var people = new List<Person>
{
    (1, "Alice", 25, "Paris"),
    (2, "Bob", 30, "Lyon"),
    (3, "Charlie", 35, "Marseille"),
    (4, "Diana", 40, "Paris"),
    (5, "Eve", 28, "Lyon"),
    (6, "Frank", 33, "Paris")
};

people.ForEach(t => Console.WriteLine(t));
//people.ForEach(Console.WriteLine); // ne marche pas avec les tuples...

//people.Display(); // utilisation de l'extension de méthide
//IEnumerableExtension.Display(people); // équivalent 

//1. Trouver toutes les personnes de Paris.
//people.Where(p => p.City == "Paris").Display();
people.Where(p => p.City == "Paris").ToList().ForEach(t => Console.WriteLine(t));
// syntaxe de requête / SQL-Like
(from p in people
 where p.City == "Paris"
 select p).ToList();

//2. Trouver les noms des personnes ayant plus de 30 ans.
people.Where(p => p.Age > 30).Select(p => p.Name).ToList().ForEach(t => Console.WriteLine(t));
(from p in people
 where p.Age > 30
 select p.Name).ToList();

//3. Trier les personnes par âge croissant.
people.OrderBy(p => p.Age);
(from p in people
 orderby p.Age
 select p).ToList();

//4. Compter le nombre de personnes vivant à Lyon.
people.Where(p => p.City == "Lyon").Count();
people.Count(p => p.City == "Lyon");
(from p in people
 where p.City == "Lyon"
 select p).Count();

//5. Trouver la personne la plus âgée.
people.OrderByDescending(p => p.Age).FirstOrDefault();
people.OrderBy(p => p.Age).LastOrDefault();
//people.FirstOrDefault(p => p.Age == people.Max(p2 => p2.Age)); // à éviter car plus lourd
(from p in people
 orderby p.Age descending
 select p).FirstOrDefault();


//6. Obtenir une liste des villes distinctes.
people.Select(p => p.City).Distinct();
//people.Select(p => p.City).ToHashSet(); // pas du linq
(from p in people
 select p.City).Distinct().ToList();

//7. Vérifier si toutes les personnes ont plus de 20 ans.
people.All(p => p.Age > 20);
//people.Any(p => p.Age <= 20) == null ? "" : "";
(from p in people
 select p.Age > 20).All(value => value /*== true*/);

//8. Projeter une nouvelle liste contenant uniquement les noms et âges.
people.Select(p => (p.Name, p.Age));
people.Select(p => ((string Name, int Age))(p.Name, p.Age)); // cast en tuple nommé
people.Select(p => new { p.Name,  p.Age}); // type annonyme (ses champs/prop sont Nom et Age => déduit)

people.Select(p => new { Nom = p.Name, Age = p.Age * 10, Majeur= p.Age>=18}); // type annonyme avec des transformations

(from p in people
 select new { p.Name, p.Age }).ToList();


//9. Trouver le nom de la personne la plus jeune vivant à Paris.
people.Where(p => p.City == "Paris").OrderBy(p => p.Age).FirstOrDefault();
people.OrderBy(p => p.Age).Where(p => p.City == "Paris").FirstOrDefault(); // plus lourd/couteux en perf (plus de choses à trier)

(from p in people
 where p.City == "Paris"
 orderby p.Age
 select p.Name).FirstOrDefault();

//10. Grouper les personnes par ville et afficher le nombre de personnes dans chaque ville.
people.GroupBy(p => p.City).Select(g => new { City = g.Key, Count = g.Count() });

(from p in people
 group p by p.City into g
 select new { City = g.Key, Count = g.Count() }).ToList();

// regroupement avancés
people.GroupBy(p => p.Age >= 18 ? "Majeur" : "Mineur");
people.GroupBy(p => p.Age switch
{
    < 0 => "pas né",
    < 18 => "mineur",
    <125 => "majeur",
    _ => "probablement mort",
});


//11. Créer une séquence infinie de nombres pairs et récupérer les 10 premiers
Enumerable.Range(0, int.MaxValue).Take(10);

(from x in Enumerable.Range(0, int.MaxValue)
 where x % 2 == 0
 select x).Take(10).ToList();

//12. Paginer une liste de nombres de 1 à 100 pour obtenir le 3ème bloc de 10 nombres (21 à 30).
int noPage = 3 - 1; // 0-based index
int nbElem = 10;
Enumerable.Range(1, 100).Skip(nbElem * noPage).Take(nbElem);

(from n in Enumerable.Range(1, 100)
 select n).Skip(noPage * nbElem)
          .Take(nbElem)
          .ToList();

//Enumerable.Range(1, 100).Skip(20).Reverse().Skip(70).Reverse().ToList().ForEach(x => Console.WriteLine($"{x}")); // pitié non...

//13. Trouver le nombre maximum dans une liste d'entiers. `[4, 8, 15, 16, 23, 42]`
new List<int>() { 4, 8, 15, 16, 23, 42 }.Max();

(from n in new List<int>() { 4, 8, 15, 16, 23, 42 }
 select n).Max();

//new Random().Next();

//14. Filtrer les mots d'une liste contenant plus de 5 lettres. `["chat", "ordinateur", "table", "lampe", "programme"]`
new List<string>() { "chat", "ordinateur", "table", "lampe", "programme" }.Where(s => s.Length > 5);

(from w in new List<string>() { "chat", "ordinateur", "table", "lampe", "programme" }
 where w.Length > 5
 select w).ToList();


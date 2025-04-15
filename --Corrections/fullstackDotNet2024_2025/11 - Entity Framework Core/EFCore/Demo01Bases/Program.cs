using System;
using Demo01Bases.Data;
using Demo01Bases.Models;

// utilisation du DbContext et donc connexion à la BDD, penser au "using" pour la fermeture automatique de la connexion
using var context = new ApplicationDbContext();

var fleursDuMal = new Livre()
{
    Titre = "Les fleurs du mal",
    Auteur = "Charles Baudelaire",
    DatePublication = new DateTime(1857, 06, 21),
    Description = "Un livre qu'il est rempli de poèmes"
};

var tchoupi = new Livre()
{
    Titre = "Tchoupi à l'école",
    Auteur = "Auteur pour enfants",
    DatePublication = new DateTime(1950, 12, 21),
    Description = "Passionnante histoire de tchoupi, drame comique et sinique..."
};

// CREATE

//// Prépraration de la requête SQL
//context.Livres.Add(fleursDuMal); // INSERT
//context.Livres.Add(tchoupi); // INSERT
////context.Set<Livre>().Add(tchoupi); // INSERT
//// à noter que DbSet<> implémente IQueryable et donc IEnumerable

//// Exécute les MODIFICATIONS qui ont été effectuées (Create Update Delete)
//context.SaveChanges(); 


//READ

//// Lire un enregistrement
//Livre? result = context.Livres.FirstOrDefault(l => l.Titre!.Contains("tchoupi"));
//Console.WriteLine(result?.Titre); // ? => si élément null, on va pas chercher son titre, on renvoit null

//// Afficher tous les livres
//context.Livres.ToList().ForEach(l => Console.WriteLine(l.Auteur));

//// Lire avec l'Id
//result = context.Livres.FirstOrDefault(l => l.Id == 3);
//result = context.Livres.Find(3); // équivalent, attention au type utilisé (type de la PK)


//// Récupérer une liste d'éléments avec un filtre
////var vieuxLivres = context.Livres.Where(l => l.DatePublication < new DateTime(1900, 1, 1)).ToList();
//var vieuxLivres = context.Livres.Where(l => l.DatePublication < DateTime.Now.AddYears(-50)).ToList();
//vieuxLivres.ForEach(l => Console.WriteLine($"{l.DatePublication}"));
//vieuxLivres.ForEach(l => Console.WriteLine($"{l.DatePublication:d}"));
//vieuxLivres.ForEach(l => Console.WriteLine($"{l.DatePublication:yy-MM-dd}"));


// UPDATE
var livre = context.Livres.FirstOrDefault(l => l.Id == 3);  // Un objet récupéré est TRAQUÉ par EFCore
livre.Titre = "Nouveau titre";
context.SaveChanges();                                      // Ses modifications peuvent lui être appliquées avec un SaveChanges


//Version moins optimisée, part d'un nouvel objet
var nouveauLivreRemplacement = new Livre() // NOUVELLE INSTANCE NON TRAQUÉE
                               {
                                   Id = 3, // Id de correspondance pour l'Update
                                   Titre = "Les fleurs du mal 2",
                                   Auteur = "Cyber Charles Baudelaire Version 2",
                                   DatePublication = new DateTime(2300, 06, 21),
                                   Description = "Un livre qu'il est rempli de cyber-poèmes"
                               };

context.Livres.Update(nouveauLivreRemplacement); // mets à jour TOUT les champs à partir de la nouvelle instance
context.SaveChanges();

// Autre approche plus avancée, donnera le même résultat que la première méthode

var nouveauLivreRemplacement2 = new Livre() // NOUVELLE INSTANCE NON TRAQUÉE
{
    Id = 1, // Id de correspondance pour l'Update
    Titre = "Les fleurs du mal 2",
    Auteur = "Cyber Charles Baudelaire Version 2",
    //DatePublication = new DateTime(2300, 06, 21),
    //Description = "Un livre qu'il est rempli de cyber-poèmes"
};

context.Attach(nouveauLivreRemplacement2); // on la lie à la BDD (avec l'id), l'objet devient traqué
context.Entry(nouveauLivreRemplacement2).Property(p => p.Titre).IsModified = true; // on précise ce qui a été modifié
context.Entry(nouveauLivreRemplacement2).Property(p => p.Auteur).IsModified = true;// on précise ce qui a été modifié
context.SaveChanges();


// DELETE

//var livre = context.Livres.Find(3);
//context.Livres.Remove(livre); // récupération de l'entitée obligatoire
//context.SaveChanges();


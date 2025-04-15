using Exercice05.Data;
using Exercice05.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exercice04.Controllers
{
    public class MarmosetController : Controller
    {
        // Pour pouvoir accéder aux marmosets, on va avoir besoin de l'accès à la fausse base de données
        //private readonly FakeDb _db;
        
        // Pour ajouter la couche donnée réelle, on fait en sorte de conserver le même nom de variable pour éviter de réecrire le code de notre contrôleur
        private readonly ApplicationDbContext _db;


        // On a simplement besoin de modifier l'injection, c'est à dire on fourni une autre classe ayant le même fonctionnement que la précédente
        public MarmosetController(ApplicationDbContext db)
        {
            // On va récupérer la fausse base de données injectée par ASP.NET et on la stocke dans notre variable privée
            _db = db;
        }


        public IActionResult List()
        {
            // On transforme en liste notre DbSet pour l'envoyer à notre vue
            var marmosets = _db.Marmosets.ToList();
            return View(marmosets); // On les envoie à la vue List.cshtml
        }

        // On obtiendra l'id de la route /Marmoset/Details/{valeur} dans les paramètres de la méthode
        // GET: /Marmoset/Details/id
        public IActionResult Details(long id)
        {
            var marmoset = _db.Marmosets.FirstOrDefault(m => m.Id == id); // On cherche un marmoset via l'Id envoyé en paramètre de route
            if (marmoset == null) return View("Error"); // Si on en trouve pas, on retourne la vue d'erreur
            return View(marmoset); // Sinon, on retourne la vue Details.cshtml peuplée du marmoset trouvé
        }

        // GET: /Marmoset/CreateRandom
        public IActionResult CreateRandom()
        {
            // On génère une nouvelle instance de Marmoset, en peuplant ces champs de valeurs aléatoire (sauf pour l'ID)
            var randomMarmoset = new Marmoset()
            {
                // On retire la propriété Id, car EF Core va s'en charger
                Name = GenerateRandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 8),
                Color = GenerateRandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 4),
                Age = new Random().Next(51)
            };

            // On ajoute ce nouveau marmoset à la collection des marmosets
            _db.Marmosets.Add(randomMarmoset);

            // Ne pas oublier de sauvegarder l'ajout sous peine de ne pas avoir la persistence
            _db.SaveChanges();

            // On redirige vers l'action permettant l'affichage du listing de tous les marmosets
            return RedirectToAction(nameof(List));
        }

        private string GenerateRandomString(string chars, int length)
        {
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}

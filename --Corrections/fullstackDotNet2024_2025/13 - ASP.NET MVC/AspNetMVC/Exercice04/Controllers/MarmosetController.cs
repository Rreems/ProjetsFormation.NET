using Exercice04.Data;
using Exercice04.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exercice04.Controllers
{
    public class MarmosetController : Controller
    {
        // Pour pouvoir accéder aux marmosets, on va avoir besoin de l'accès à la fausse base de données
        private readonly FakeDb _db;

        public MarmosetController(FakeDb db)
        {
            // On va récupérer la fausse base de données injectée par ASP.NET et on la stocke dans notre variable privée
            _db = db;
        }


        public IActionResult List()
        {
            var marmosets = _db.Marmosets; // On récupère l'ensemble des marmosets
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
                Id = _db.Marmosets.Max(m => m.Id) + 1,
                Name = GenerateRandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 8),
                Color = GenerateRandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 4),
                Age = new Random().Next(51)
            };

            // On ajoute ce nouveau marmoset à la collection des marmosets
            _db.Marmosets.Add(randomMarmoset);

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

using System.Text.Json;
using Demo01.Data;
using Demo01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo01.Controllers
{
    public class CatController : Controller
    {
        private readonly IRepository<Cat> _repo;
        public CatController(IRepository<Cat> repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var cats = _repo.GetAll();
            return View("List", cats);
        }

        public IActionResult Create()
        {
            ViewBag.FormMode = "Create"; // On ajoute une donnée utile à notre vue unique de sorte à ce qu'elle sache dans quel mode nous sommes (Edition ou Création)
            return View("Form");
        }

        [HttpPost]
        // On utilise [Bind] pour identifier les propriétés de notre classe qu'on veut tester lors du processus de validation (le reste sera ignoré)
        public IActionResult Create([Bind("Name", "Breed", "Age", "Color")] Cat cat)
        {
            if (ModelState.IsValid) // Si le modèle est valide...
            {
                if (_repo.Create(cat) != null) // Si l'ajout en base de donnée à fonctionné...
                {
                    return RedirectToAction(nameof(Index)); // On redirige vers le listing des chats
                }
                else // Si la sauvegarde n'a pas fonctionné...
                {
                    ModelState.AddModelError("db-status", "Cannot save in the database!"); // On ajoute une erreur personnalisée informant de la non-sauvegarde...
                    ViewBag.FormMode = "Create";
                    return View("Form", cat); // On retourne les données du chat de sorte à ne pas avoir à retaper tout le formulaire
                }
            } else // Si le modèle n'est de base pas valide...
            {
                ViewBag.FormMode = "Create";
                return View("Form", cat); // On retourne les données du chat de sorte à ne pas avoir à retaper tout le formulaire
            }
        }

        public IActionResult Edit(int id)
        {
            var catFound = _repo.GetById(id); // On cherche le chat
            if (catFound == null) return View("Error", new ErrorViewModel() { RequestId = "404" }); // Si on en trouve pas, on redirige vers la page d'erreur en indiquant qu'il s'agit d'un 404 (Idéalement, on aurait fait une page d'erreur mieux que celle fournie de base par ASP.NET...)
            ViewBag.FormMode = "Edit";
            return View("Form", catFound); // Si on a trouvé un chat, on envoie le formulaire avec les données du chat trouvé
        }

        [HttpPost]
        public IActionResult Edit(Cat cat)
        {
            if (ModelState.IsValid) // Si le modèle est valide...
            {
                if (_repo.Update(cat) != null) // Si l'édition en base de donnée à fonctionné...
                {
                    return RedirectToAction(nameof(Index)); // On redirige vers le listing des chats
                }
                else // Si la sauvegarde n'a pas fonctionné...
                {
                    ModelState.AddModelError("db-status", "Cannot save in the database!"); // On ajoute une erreur personnalisée informant de la non-sauvegarde...
                    ViewBag.FormMode = "Edit";
                    return View("Form", cat); // On retourne les données du chat de sorte à ne pas avoir à retaper tout le formulaire
                }
            }
            else // Si le modèle n'est de base pas valide...
            {
                ViewBag.FormMode = "Edit";
                return View("Form", cat); // On retourne les données du chat de sorte à ne pas avoir à retaper tout le formulaire
            }
        }
    }
}

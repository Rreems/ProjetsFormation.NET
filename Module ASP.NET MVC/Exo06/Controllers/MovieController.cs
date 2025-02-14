using Exo06.Data;
using Exo06.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exo06.Controllers;

public class MovieController : Controller
{
    private readonly IRepository<Movie> _repo;
    public MovieController(IRepository<Movie> repo)
    {
        _repo = repo;
    }


    public IActionResult Index()
    {
        var movies = _repo.GetAll();

        ViewBag.ListMode = "List";

        return View("List", movies);
    }

    public IActionResult Create()
    {
        ViewBag.FormMode = "Create"; // On ajoute une donnée utile à notre vue unique de sorte à ce qu'elle sache dans quel mode nous sommes (Edition ou Création)
        return View("Form");
    }

    [HttpPost]
    // On utilise [Bind] pour identifier les propriétés de notre classe qu'on veut tester lors du processus de validation (le reste sera ignoré)
    public IActionResult Create([Bind("Nom", "Genre", "Duree", "Realisateur", "Statut")] Movie movie)
    {
        if (ModelState.IsValid) // Si le modèle est valide...
        {
            if (_repo.Create(movie) != null) // Si l'ajout en base de donnée à fonctionné
            {
                return RedirectToAction(nameof(Index)); // On redirige vers le listing des films
            }
            else // Si la sauvegarde n'a pas fonctionné
            {
                ModelState.AddModelError("db-status", "Cannot save in the database!"); // On ajoute une erreur personnalisée informant de la non-sauvegarde...
                ViewBag.FormMode = "Create";
                return View("Form", movie); // On retourne les données du chat de sorte à ne pas avoir à retaper tout le formulaire
            }
        }
        else // Si le modèle n'est de base pas valide...
        {
            ViewBag.FormMode = "Create";
            return View("Form", movie); // On retourne les données du chat de sorte à ne pas avoir à retaper tout le formulaire
        }
    }

    public IActionResult Edit(int id)
    {
        var movieFound = _repo.GetById(id); // On cherche le chat
        if (movieFound == null) return View("Error", new ErrorViewModel() { RequestId = "404" }); // Si on en trouve pas, on redirige vers la page d'erreur en indiquant qu'il s'agit d'un 404 (Idéalement, on aurait fait une page d'erreur mieux que celle fournie de base par ASP.NET...)
        ViewBag.FormMode = "Edit";
        return View("Form", movieFound); // Si on a trouvé un chat, on envoie le formulaire avec les données du chat trouvé
    }

    [HttpPost]
    public IActionResult Edit(Movie movie)
    {
        if (ModelState.IsValid) // Si le modèle est valide...
        {
            if (_repo.Update(movie) != null) // Si l'édition en base de donnée à fonctionné...
            {
                return RedirectToAction(nameof(Index)); // On redirige vers le listing des films
            }
            else // Si la sauvegarde n'a pas fonctionné...
            {
                ModelState.AddModelError("db-status", "Cannot save in the database!"); // On ajoute une erreur personnalisée informant de la non-sauvegarde...
                ViewBag.FormMode = "Edit";
                return View("Form", movie); // On retourne les données du chat de sorte à ne pas avoir à retaper tout le formulaire
            }
        }
        else // Si le modèle n'est de base pas valide...
        {
            ViewBag.FormMode = "Edit";
            return View("Form", movie); // On retourne les données du chat de sorte à ne pas avoir à retaper tout le formulaire
        }
    }

    // On obtiendra l'id de la route /Marmoset/Details/{valeur} dans les paramètres de la méthode
    // GET: MarsupilamiController/Details/5
    public IActionResult Details(int id)
    {
        var movieFound = _repo.GetById(id);

        if (movieFound != null)
        {
            ViewBag.ListMode = "Details";
            return View("List", new HashSet<Movie>() { movieFound });
        }
        else
        {
            return View("Error");
        }
    }


    // GET: MarsupilamiController/Delete/5
    public IActionResult Delete(int id)
    {
        Movie movieFound = _repo.GetAll().FirstOrDefault(c => c.Id == id);

        if (movieFound != null)
        {
            _repo.Delete(movieFound);
            return RedirectToAction(nameof(Index));
        }
        else
        {
            return View("Error");
        }
    }

    public IActionResult ChangeStatut(int id)
    {
        Movie movieFound = _repo.GetAll().FirstOrDefault(c => c.Id == id);

        if (movieFound != null)
        {
            if (movieFound.Statut == "À voir")
            {
                    movieFound.Statut = "Visionné";
            } else
            {
                    movieFound.Statut = "À voir";
            }


            if (_repo.Update(movieFound) != null) // Si l'édition en base de donnée à fonctionné...
            {
                return RedirectToAction(nameof(Index)); // On redirige vers le listing des films
            }
            else // Si la sauvegarde n'a pas fonctionné...
            {
                ModelState.AddModelError("db-status", "Cannot save in the database!"); // On ajoute une erreur personnalisée informant de la non-sauvegarde...
                return RedirectToAction(nameof(Index));
            }
        }
        else
        {
            return View("Error");
        }
    }

}

using System.Diagnostics;
using System.Threading.Channels;
using Demo01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo01.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}


        // une ACTION (une méthode PUBLIC d'un CONTROLLER) => correspond à une route Http
        public IActionResult Index() 
        {
            // données potentitellement récupérées de la BDD
            var chaines = new List<string>() 
            {
                "chaine1",
                "chaine2",
                "chaine3",
                "chaine3",
            };

            // passer des données à la vue

            // méthode 1: ViewData => un dictionnaire
            ViewData["chaines"] = chaines;

            ViewData["message"] = "message depuis Index";

            // méthode 2: ViewBag => un dynamic
            ViewBag.Chaines = chaines;

            // méthode 3: Model => un UNIQUE objet qui sera donné à la vue
            return View(chaines); // cf. @model dans la vue Index.cshtml


            //return View();
            //return View("Index");
            //return View("Privacy");
        }

        public IActionResult Index2()
        {
            return View("Index"); // => on retourne directement la vue Index.cshtml
        }


        public IActionResult Index3()
        {
            //return RedirectToAction("Index"); // => repasse par l'action/la méthode Index de HomeController
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        // /Home/DitBonjour
        public string DitBonjour()
        {
            return "Bonjour à toi !";
        }

        // /Home/DitBonjourA?personne=Guillaume
        // /Home/DitBonjourA?personne=Léandre
        public string DitBonjourA(string personne)
        {
            return $"Bonjour à toi {personne}!";
        }


        // /Home/Compter?id=15 // QueryParameter
        // /Home/Compter/15    // RouteParameter => config Map dans le Program.cs
        public string Compter(int id)
        {
            string chaine = "";
            for (int i = 0; i < id; i++)
            {
                chaine += i + ", ";
            }
            return $"Compte : {chaine}!";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

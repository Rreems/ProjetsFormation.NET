using ExoCaisseEnregistreuse.Models;
using ExoCaisseEnregistreuse.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ExoCaisseEnregistreuse.Services; //img
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

// J'ai tout mis dans le même controller, c'est mal
namespace ExoCaisseEnregistreuse.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IRepository<Produit> _produitRepository;
        private readonly IRepository<Categorie> _categorieRepository;

        private readonly IUploadService _uploadService; //img

        public HomeController(IRepository<Produit> produitRepository, IRepository<Categorie> categorieRepository, IUploadService uploadService)
        {
            _produitRepository = produitRepository;
            _categorieRepository = categorieRepository;
            _uploadService = uploadService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DetailsProduit(int id)
        {
            var produit = _produitRepository.GetById(id);
            return View(produit);
        }

        public IActionResult DetailsCategorie(int id)
        {
            var categorie = _categorieRepository.GetById(id);
            return View(categorie);
        }

        public IActionResult ListeProduits()
        {
            var listeProduits = _produitRepository.GetAll();
            return View(listeProduits);
        }

        public IActionResult ListeCategories()
        {
            var listeCategories = _categorieRepository.GetAll();
            return View(listeCategories);
        }

        public IActionResult AjoutProduit()
        {
            ViewBag.Cat = new SelectList(_categorieRepository.GetAll(), "Id", "Nom");

            return View("FormProduit");        }


        public IActionResult ModifierProduit(int id)
        {            
            ViewBag.Cat = new SelectList(_categorieRepository.GetAll(), "Id", "Nom");
            var produit = _produitRepository.GetById(id);
            return View("FormProduit", produit);
        }

        public IActionResult SubmitProduit(Produit produit, IFormFile image)
        {
            if (image != null) { 
            string filePath = _uploadService.Upload(image);
            produit.ImagePath = filePath;
            }

            if (produit.ImagePath == null)
            {
                produit.ImagePath = "/images/cd0317d6-962a-4a51-9aed-52ee018cd754-placeholder.png";
            }


            if (produit.Id == 0)
                _produitRepository.Add(produit);
            else
                _produitRepository.Update(produit);

            return RedirectToAction(nameof(ListeProduits));
        }

        public IActionResult AjoutCategorie()
        {
            return View("FormCategorie");
        }
        public IActionResult ModifierCategorie(int id)
        {
            var categorie = _categorieRepository.GetById(id);
            return View("FormCategorie", categorie);
        }



        public IActionResult SubmitCategorie(Categorie categorie)
        {
            if (categorie.Id == 0)
                _categorieRepository.Add(categorie);
            else
                _categorieRepository.Update(categorie);

            return RedirectToAction(nameof(ListeCategories));
        }

        public IActionResult DeleteProduit(int id)
        {
            var produit = _produitRepository.GetById(id);
            if (produit == null)
                return View("Error");
            _produitRepository.Delete(id);

            return RedirectToAction(nameof(ListeProduits));
        }

        public IActionResult DeleteCategorie(int id)
        {
            var categorie = _categorieRepository.GetById(id);
            if (categorie == null)
                return View("Error");
            _categorieRepository.Delete(id);
            // et si la catégorie n'est pas vide

            return RedirectToAction(nameof(ListeCategories));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        //////////////////// panier ////////////////////



        public IActionResult Panier()
        {
            var panier = _GetPanier();

            var produitsPanier = new List<Produit>();

            foreach (int id in panier)
            {
                var produitFromDb = _produitRepository.GetById(id);
                if (produitFromDb != null)
                    produitsPanier.Add(produitFromDb);
            }

            return View(produitsPanier);
        }

        private List<int> _GetPanier()
        {
            List<int> panier = new List<int>();

            // Récupération d'un cookie
            string? panierCookie = HttpContext.Request.Cookies["panier"]; // on récupère un cookie, sous forme de chaine de caractères (depuis la requête entrante)

            if (panierCookie != null)
            {
                panier = JsonSerializer.Deserialize<List<int>>(panierCookie)!; // on passe d'un string avec du json vers une List<int>
            }

            return panier;
        }

        public IActionResult AjouterAuPanier(int id)
        {
            List<int> panier = _GetPanier(); // on récupère d'abord la liste de cookies

            panier.Add(id); // on ajoute un nouvel id de produit

            string panierCookie = JsonSerializer.Serialize(panier); // on passe d'une List<int> vers un string avec du json

            // Set du cookie
            HttpContext.Response.Cookies.Append("panier", panierCookie); // on définit le cookie

            // Set d'une information dans la Session
            //HttpContext.Session.SetString("panier", panierCookie);

            //retourner qch pour pouvoir afficher "xyz a été ajouté au panier" ?

            

            return RedirectToAction(nameof(ListeProduits));
        }

        public IActionResult ViderPanier()
        {
            
            HttpContext.Response.Cookies.Delete("panier");



            return RedirectToAction(nameof(ListeProduits));
        }


        ///////////////////////////////////////////////////


    }
}


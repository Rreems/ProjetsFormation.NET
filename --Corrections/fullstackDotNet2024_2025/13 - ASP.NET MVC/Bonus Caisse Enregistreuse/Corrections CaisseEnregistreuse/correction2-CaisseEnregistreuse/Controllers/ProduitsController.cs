using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TpCaisseEnregistreuse.Models;
using TpCaisseEnregistreuse.Repositories;
using TpCaisseEnregistreuse.Services;

namespace TpCaisseEnregistreuse.Controllers
{
    public class ProduitsController : Controller
    {
        private readonly IRepository<Produit> _prodRepository;
        private readonly IUploadService _uploadService;

        public ProduitsController(IRepository<Produit> prodRepository, IUploadService uploadService)
        {
            _prodRepository = prodRepository;
            _uploadService = uploadService;
        }

        public IActionResult Index()
        {
            var prodList = _prodRepository.GetAll();
            return View("Produits", prodList);
        }
        
        public IActionResult DeleteProd(int id)
        {
            var prod = _prodRepository.GetById(id);
            if (prod == null)
                return View("Error");
            _prodRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult UpdateProd(int id)
        {
            var prod =_prodRepository.GetById(id);
            return View("UpdateProduct", prod);
        }
        public IActionResult ProduitDetail(int id)
        {

            var prod = _prodRepository.GetById(id);
            return View(prod);
        }
        public IActionResult SubmitProduct(Produit prod, IFormFile image)
        {
            string filePath = _uploadService.Upload(image);
            prod.ProduitPath = filePath;
            // 2 cas de submit possible:
            // -ajout d'un contact => Id == 0
            // -modification d'un contact => Id != 0

            if (prod.Id == 0)
                _prodRepository.Add(prod);
            else
                _prodRepository.Update(prod);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult FormulaireAjoutProd()
        {
            return View("UpdateProduct");
        }

        public IActionResult Favoris()
        {
            var favList = _GetFavoris();

            var favContactList = new List<Produit>();

            foreach (int id in favList)
            {
                var contactFromDb = _prodRepository.GetById(id);
                if (contactFromDb != null)
                    favContactList.Add(contactFromDb);
            }

            return View(favContactList);
        }

        private List<int> _GetFavoris()
        {
            List<int> favList = new List<int>();

            // Récupération d'un cookie
            //string? favCookie = HttpContext.Request.Cookies["favoris"]; // on récupère un cookie, sous forme de chaine de caractères (depuis la requête entrante)

            // Récupération d'une information dans la Session
            string? favCookie = HttpContext.Session.GetString("favoris");

            if (favCookie != null)
            {
                favList = JsonSerializer.Deserialize<List<int>>(favCookie)!; // on passe d'un string avec du json vers une List<int>
            }

            return favList;
        }

        public IActionResult AddToFavoris(int id)
        {
            List<int> favList = _GetFavoris(); // on récupère d'abord la liste de cookies

            favList.Add(id); // on ajoute un nouvel id de contact (nouveau favoris)

            string favCookie = JsonSerializer.Serialize(favList); // on passe d'une List<int> vers un string avec du json

            // Set du cookie
            //HttpContext.Response.Cookies.Append("favoris", favCookie); // on définit le cookie

            // Set d'une information dans la Session
            HttpContext.Session.SetString("favoris", favCookie);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddToCart(Produit prod)
        {
            if (prod.Id == 0)
                _prodRepository.Add(prod);
            else
                _prodRepository.Update(prod);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Panier()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using TpCaisseEnregistreuse.Models;
using TpCaisseEnregistreuse.Repositories;

namespace TpCaisseEnregistreuse.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly IRepository<Categorie> _catRepository;

        public CategoriesController(IRepository<Categorie> catRepository)
        {
            _catRepository = catRepository;
        }

        public IActionResult Index()
        {
            var catList = _catRepository.GetAll();
            return View("Categories", catList);
        }

        public IActionResult Delete(int id)
        {
            var cat = _catRepository.GetById(id);
            if (cat == null)
                return View("Error");
            _catRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult UpdateCategories(int id)
        {
            var cat = _catRepository.GetById(id);
            return View("UpdateCategories", cat);
        }
        public IActionResult CategorieDetails(int id)
        {

            var cat = _catRepository.GetById(id);
            return View(cat);
        }
        public IActionResult SubmitCategorie(Categorie cat)
        {
            // 2 cas de submit possible:
            // -ajout d'un contact => Id == 0
            // -modification d'un contact => Id != 0

            if (cat.Id == 0)
                _catRepository.Add(cat);
            else
                _catRepository.Update(cat);

            return RedirectToAction(nameof(Index));
        }
        public IActionResult FormulaireAjout()
        {
            return View("UpdateCategories");
        }
    }
}

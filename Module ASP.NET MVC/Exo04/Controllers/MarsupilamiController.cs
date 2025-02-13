using System;
using Exo04.Data;
using Exo04.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exo04.Controllers
{
    public class MarsupilamiController : Controller
    {
        private readonly MarsupilamiRepository _repo;
        public MarsupilamiController(MarsupilamiRepository repo)
        {
            _repo = repo;
        }


        public static string RandomString(List<String> items, int length)
        {
            Random random = new Random();
            string result = "";
            for (int i = 0; i < length; i++)
            {
                result += items[random.Next(items.Count)];
            }

            //string result = new string(Enumerable.Repeat(items, length)
            //    .Select(s => s[random.Next(s.Count)]).ToArray())
            return result;
        }



        // GET: MarsupilamiController
        public IActionResult Index()
        {
            var marsupilamis = _repo.GetAll();
            return View(marsupilamis);
        }

        // On obtiendra l'id de la route /Marmoset/Details/{valeur} dans les paramètres de la méthode
        // GET: MarsupilamiController/Details/5
        public IActionResult Details(int id)
        {
            var marsupilamiFound = _repo.GetById(id);

            if (marsupilamiFound != null)
            {
                return View(marsupilamiFound);
            }
            else
            {
                return View("Error");
            }
        }



        // GET: MarsupilamiController/CreateRandom
        public IActionResult CreateRandom()
        {
            string chaine = RandomString(new List<string>() {
                "Houba",
                "Hop",
                "Bahou",
                "Bou",
                "Baba",
                "Ba",
                "Bou",
                "Houla"

                }, 3);

            Random random = new Random();
            string color = new List<string>() {
                "Jaune",
                "Jaune à points noirs",
                "Noir",
                "Noir à points jaunes"
                }[random.Next(4)];

            _repo.Add(new Marsupilami()
            {
                PetitNom = chaine,
                Couleur = color
            });

            return RedirectToAction(nameof(Index));
        }

        // POST: MarsupilamiController/Create
        [HttpPost]
        public IActionResult Create(Marsupilami marsupilami)
        {
            if (ModelState.IsValid)
            {
                //var newId = _repo.Marsupilamis.Max(c => c.Id) + 1;
                //marsupilami.Id = newId;
                _repo.Add(marsupilami);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(marsupilami);
            }
        }

        // GET: MarsupilamiController/Create
        public IActionResult Create()
        {
            return View();
        }


        // GET: MarsupilamiController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }


        // GET: MarsupilamiController/Delete/5
        public IActionResult Delete(int id)
        {
            var marsupilamiFound = _repo.GetAll().FirstOrDefault(c => c.Id == id);

            if (marsupilamiFound != null)
            {
                _repo.Delete(marsupilamiFound.Id);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View("Error");
            }
        }

    }
}

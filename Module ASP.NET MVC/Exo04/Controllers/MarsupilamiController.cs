using System;
using Exo04.Data;
using Exo04.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exo04.Controllers
{
    public class MarsupilamiController : Controller
    {
        private readonly FakeDb _db;
        public MarsupilamiController(FakeDb db)
        {
            _db = db;
        }


        public static string RandomString(List<String> items, int length)
        {
            Random random = new Random();
            string result="";
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
            return View(_db.Marsupilamis);
        }

        // GET: MarsupilamiController/Details/5
        public IActionResult Details(int id)
        {
            var marsupilamiFound = _db.Marsupilamis.FirstOrDefault(c => c.Id == id);

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

            _db.Marsupilamis.Add(new Marsupilami()
            {
                Id= _db.Marsupilamis
                         .Select(x => x.Id)
                         .DefaultIfEmpty(0)
                         .Max()+1,

                //_db.Marsupilamis.Max(c => c.Id) + 1  ,
                PetitNom = chaine,
                Couleur = color
            });

            return RedirectToAction("Index");
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
            var marsupilamiFound = _db.Marsupilamis.FirstOrDefault(c => c.Id == id);

            if (marsupilamiFound != null)
            {
                _db.Marsupilamis.Remove(marsupilamiFound);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }

    }
}

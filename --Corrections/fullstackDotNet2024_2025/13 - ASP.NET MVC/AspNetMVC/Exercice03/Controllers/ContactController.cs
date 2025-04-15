using Exercice03.Data;
using Exercice03.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exercice03.Controllers
{
    public class ContactController : Controller
    {
        private readonly FakeDb _db;
        public ContactController(FakeDb db)
        {
            _db = db;
        }

        public IActionResult List()
        {
            ViewBag.Contacts = _db.Contacts;
            ViewData["contacts"] = _db.Contacts;
            return View(_db.Contacts);
        }

        public IActionResult Details(long id)
        {
            var contactFound = _db.Contacts.FirstOrDefault(c => c.Id == id);

            if (contactFound != null)
            {
                return View(contactFound);
            } else
            {
                return View("Error");
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                var newId = _db.Contacts.Max(c => c.Id) + 1;
                contact.Id = newId;
                _db.Contacts.Add(contact);
                return RedirectToAction("List");
            } else
            {
                return View(contact);
            }
        }
    }
}

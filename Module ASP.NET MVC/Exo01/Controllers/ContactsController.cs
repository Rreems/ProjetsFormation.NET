using System.Diagnostics;
using Exo01.Data;
using Exo01.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exo01.Controllers;

public class ContactsController : Controller
{
    private readonly FakeDb _db;
    public ContactsController(FakeDb db)
    {
        _db = db;
    }


    //List<Contact> _db.Contacts = new List<Contact>()
    //    {
    //     new Contact(){ Id = 1,Nom = "Smith", Prenom = "Bob" , Numero = "0101026"},
    //     new Contact(){ Id = 2,Nom = "Doe", Prenom = "John" , Numero = "8801026"},
    //     new Contact(){ Id = 3,Nom = "Bourziz", Prenom = "Mehdi" , Numero = "6333975"},
    //     new Contact(){ Id = 4,Nom = "Belambert", Prenom = "Melfou" , Numero = "97575"},
    //     new Contact(){ Id = 5,Nom = "Oswalt", Prenom = "Rémi" , Numero = "72758578"}
    //    };



    // /Contact/    => Possible grace au app Map Controler ("default" , .. ) de program.cs
    // /Contact/Index
    public IActionResult Index()
    {
        
        return View(_db.Contacts);
    }



    // /Contact/Details
    public IActionResult Details(string? id)
    {
        // Contrôle de saisie ID invalide / Hors liste
        if (!int.TryParse(id, out int idInt) || idInt > _db.Contacts.Count || idInt < 0)
        {
            return RedirectToAction(nameof(Index));
        }
        
        Contact contact = _db.Contacts.FirstOrDefault(c => c.Id == id);  

        return View(contact);
    }



    // /Contact/Add    /id nullable  ou  /?id=x 
    public IActionResult Add(string? idUpdate)
    {
        ViewData["id"] = idUpdate;
        return View();
    }

    [HttpPost]
    public IActionResult Add(Contact contact)
    {
        if (ModelState.IsValid)
        {
            var newId = _db.Contacts.Max(c => c.Id) + 1;
            contact.Id = newId;
            _db.Contacts.Add(contact);
            return RedirectToAction("Index");
        }
        else
        {
            return View(contact);
        }
    }
}
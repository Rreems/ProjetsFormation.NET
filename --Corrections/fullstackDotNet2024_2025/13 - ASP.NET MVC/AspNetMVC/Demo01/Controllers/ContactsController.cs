using Microsoft.AspNetCore.Mvc;

namespace Demo01.Controllers
{
    public class ContactsController : Controller
    {
        // /Contacts/       => possible grace au app.MapControllerRoute("default", ...) de program.cs
        // /Contacts/Index
        public IActionResult Index()
        {
            //return "Je suis la page pour afficher les contacts.";
            return View();
        }
        // /Contacts/Details/5
        public IActionResult Details(int id)
        {
            //return $"Je suis la page pour afficher le contact n°{id} en détail...";
            return View();
        }
        public IActionResult Add()
        {
            //return "Je suis la page pour ajouter un contact...";
            return View();
        }
    }
}

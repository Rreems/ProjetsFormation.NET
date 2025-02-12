using System.ComponentModel.DataAnnotations;
using Exo01.Models;

namespace Exo01.Data
{
    public class FakeDb
    {
        public readonly HashSet<Contact> Contacts = new()
        {
            new Contact() { Id = "1", Nom = "Smith", Prenom = "Bob", Numero = "0101026" },
            new Contact() { Id = "2", Nom = "Doe", Prenom = "John", Numero = "8801026" },
            new Contact() { Id = "3", Nom = "Bourziz", Prenom = "Mehdi", Numero = "6333975" },
            new Contact() { Id = "4", Nom = "Belambert", Prenom = "Melfou", Numero = "97575" },
            new Contact() { Id = "5", Nom = "Oswalt", Prenom = "Rémi", Numero = "72758578" }
        };
    }
}

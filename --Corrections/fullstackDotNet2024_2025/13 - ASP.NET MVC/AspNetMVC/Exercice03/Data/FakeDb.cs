using Exercice03.Models;

namespace Exercice03.Data
{
    public class FakeDb
    {
        public readonly HashSet<Contact> Contacts = new()
        {
            new Contact() { Email = "j.dupont@example.com", PhoneNumber = "+33715478965" },
            new Contact() { Id = 2L, FirstName = "Martha", LastName = "Smith", Email = "m.smith@example.com", PhoneNumber = "+33648759615" }
        };
    }
}

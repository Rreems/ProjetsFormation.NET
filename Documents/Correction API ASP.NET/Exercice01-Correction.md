# Correction Exercice 01

### **Étape 1 : Créer un projet ASP.NET Core Web API**  

1. **Ouvrir Visual Studio 2022**  
2. **Créer un nouveau projet**  
   - Sélectionner **ASP.NET Core Web API**  
   - Cliquer sur **Suivant**  
3. **Configurer le projet**  
   - Donner un nom au projet (ex: `ContactApi`)  
   - Choisir l’emplacement du projet  
   - Cliquer sur **Suivant**  
4. **Configurer les options supplémentaires**  
   - Sélectionner **.NET 8** (ou une version compatible)  
   - Désactiver l’authentification (option **Aucune**)  
   - Activer **Use controllers** (désactiver les minimal APIs)  
   - Cliquer sur **Créer**  

Le projet est maintenant prêt avec une structure de base contenant un `Program.cs` et un `Controllers` par défaut.  

---

### **Étape 2 : Créer le modèle `Contact`**  

1. **Dans l'Explorateur de solutions**, ajouter un dossier `Models`.  
2. **Créer une nouvelle classe** `Contact.cs` et définir le modèle selon les contraintes demandées :  

#### **Implémentation du modèle `Contact`**  

```csharp
using System.ComponentModel.DataAnnotations;

namespace ContactApi.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le nom est requis.")]
        [StringLength(30)]
        [RegularExpression(@"^[A-Z]+$", ErrorMessage = "Le nom doit être en majuscules.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le prenom est requis.")]
        [StringLength(30)]
        [RegularExpression(@"^[A-Z][a-z]*$", ErrorMessage = "Le prénom doit commencer par une majuscule.")]
        public string FirstName { get; set; } = string.Empty;

        public string FullName => $"{FirstName} {LastName}";

        [Required(ErrorMessage = "Le genre est requis.")]
        [StringLength(1)]
        [RegularExpression("^[FMN]$", ErrorMessage = "Le genre doit être F, M ou N.")]
        public string Gender { get; set; } = string.Empty;

        [Required(ErrorMessage = "La date de naissance est requise.")]
        [Range(typeof(DateOnly), "1911-01-01", "9999-12-31", ErrorMessage = "La date de naissance doit être après 1910.")]
        public DateOnly BirthDate { get; set; }

        public int Age
        {
            get
            {
                int age = DateTime.Now.Year - BirthDate.Year;
                if (BirthDate > DateOnly.FromDateTime(DateTime.Now.AddYears(-age))) //ajout de vérification mois/jour
                    age--;
                return age;
            }
        }

        [EmailAddress(ErrorMessage = "Le format de l'email est invalide.")] // peu précis mais fonctionnel
        //[RegularExpression(@"^([a-zA-Z0-9\.\-_]+)@([a-zA-Z0-9\-_]+)(\.)?([a-zA-Z0-9\-_]+)?(\.){1}([a-zA-Z]{2,11})$", ErrorMessage = "Le format de l'email est invalide.")]
        public string? Email { get; set; }

        [RegularExpression(@"^\+?[0-9]{10,15}$", ErrorMessage = "Le numéro de téléphone est invalide.")]
        public string? PhoneNumber { get; set; }
    }
}
```

---

### **Étape 3 : Configurer Entity Framework Core**  

1. **Installer Entity Framework Core**  
   - Dans **Visual Studio 2022**, ouvrir le **Gestionnaire de packages NuGet**  
   - Installer les packages suivants :  
     - `Microsoft.EntityFrameworkCore.SqlServer`  
     - `Microsoft.EntityFrameworkCore.Design`  
2. **Ajouter un dossier `Data`**  
3. **Créer une classe `AppDbContext.cs`**  

#### **Implémentation de `AppDbContext`**  

```csharp
using ContactApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
```

4. **Configurer la connexion à la base de données**  
   - Ouvrir `appsettings.json` et ajouter :  

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=ContactDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

5. **Configurer le `Program.cs` pour enregistrer `AppDbContext`**  

```csharp
// A mettre avant  la ligne : var app = builder.Build();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

---

### **Étape 4 : Implémenter le Repository**  

1. **Ajouter un dossier `Repositories`**  
2. **Créer une interface `IRepository.cs`**  

```csharp
namespace ContactApi.Repositories
{
    internal interface IRepository<T, Tid> where T : new()
    {
        T? Add(T entity);
        T? GetById(Tid id);
        T? Get(Expression<Func<Contact, bool>> predicate); // Expression permet une meilleure optimisation avec EF Core
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<Contact, bool>> predicate);
        T? Update(T entity);
        bool Delete(Tid id);
    }
}
```

3. **Créer la classe `ContactRepository.cs`**  

```csharp
using ContactApi.Data;
using ContactApi.Models;

namespace ContactApi.Repositories
{
    public class ContactRepository : IRepository<Contact, int>
    {
        private readonly AppDbContext _db;

        public ContactRepository(AppDbContext db)
        {
            _db = db;
        }

        public Contact? Add(Contact contact)
        {
            _db.Contacts.Add(contact);
            _db.SaveChanges();
            return contact;
        }

        public Contact? GetById(int id) => _db.Contacts.Find(id);

        public Contact? Get(Expression<Func<Contact, bool>> predicate) => _db.Contacts.FirstOrDefault(predicate);

        public IEnumerable<Contact> GetAll() => _db.Contacts;

        public IEnumerable<Contact> GetAll(Expression<Func<Contact, bool>> predicate) => _db.Contacts.Where(predicate);

        public Contact? Update(Contact contact)
        {
            var contactFromDb = GetById(contact.Id);
            if (contactFromDb is null)
                return null;

            if (contactFromDb.FirstName != contact.FirstName)
                contactFromDb.FirstName = contact.FirstName;
            if (contactFromDb.LastName != contact.LastName)
                contactFromDb.LastName = contact.LastName;
            if (contactFromDb.Gender != contact.Gender)
                contactFromDb.Gender = contact.Gender;
            if (contactFromDb.BirthDate != contact.BirthDate)
                contactFromDb.BirthDate = contact.BirthDate;
            if (contactFromDb.Email != contact.Email)
                contactFromDb.Email = contact.Email;
            if (contactFromDb.PhoneNumber != contact.PhoneNumber)
                contactFromDb.PhoneNumber = contact.PhoneNumber;

            _db.SaveChanges();
            return contactFromDb;
        }

        public bool Delete(int id)
        {
            var contact = GetById(id);
            if (contact is null)
                return false;

            _db.Contacts.Remove(contact);
            _db.SaveChanges();
            return true;
        }
    }
}
```

---

### **Étape 5 : Implémenter le Service `ContactService`**  

1. **Ajouter un dossier `Services`**  
2. **Créer l'interface `IContactService.cs`**  

```csharp
using ContactApi.Models;

namespace ContactApi.Services
{
    public interface IContactService
    {
        IEnumerable<Contact> GetAll(string? firstName = null, string? lastName = null, string? phoneNumber = null, string? email = null);
        Contact? GetById(int id);
        Contact? GetByLastName(string lastName);
        Contact Create(Contact contact);
        Contact? Update(int id, Contact contact);
        bool Delete(int id);
    }
}
```

3. **Créer `ContactService.cs`**  

```csharp
using ContactApi.Models;
using ContactApi.Repositories;

namespace ContactApi.Services
{
    public class ContactService : IContactService
    {
        private readonly IRepository<Contact, int> _repository;

        public ContactService(IRepository<Contact, int> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Contact> GetAll(string? firstName = null, string? lastName = null, string? phoneNumber = null, string? email = null)
        {
            return _repository.GetAll(c =>
                (string.IsNullOrEmpty(firstName) || c.FirstName.Contains(firstName, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(lastName) || c.LastName.Contains(lastName, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(phoneNumber) || c.PhoneNumber.Contains(phoneNumber)) &&
                (string.IsNullOrEmpty(email) || c.Email.Contains(email, StringComparison.OrdinalIgnoreCase)));
        }

        public Contact? GetById(int id) => _repository.GetById(id);

        public Contact? GetByLastName(string lastName) => _repository.Get(c => c.LastName.Contains(lastName, StringComparison.OrdinalIgnoreCase));

        public Contact Create(Contact contact)
        {
            try
            {
                return _repository.Add(contact) ?? throw new Exception("Échec de la création du contact.");
            }
            catch (Exception)
            {
                // Ajout de logging ici
                throw;
            }
        }

        public Contact? Update(int id, Contact contact)
        {
            try
            {
                contact.Id = id;
                var updatedContact = _repository.Update(contact);
                if (updatedContact == null)
                {
                    throw new Exception($"Contact avec l'id {id} non trouvé.");
                }
                return updatedContact;
            }
            catch (Exception)
            {
                // Ajout de logging ici
                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                return _repository.Delete(id);
            }
            catch (Exception)
            {
                // Ajout de logging ici
                throw;
            }
        }
    }
}
```

---


---

### **Étape 6 : Implémenter le `ContactController`**  

1. **Ajouter un dossier `Controllers`**  
2. **Créer la classe `ContactController.cs`**  

#### **Implémentation du `ContactController`**  

```csharp
using ContactApi.Models;
using ContactApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactApi.Controllers
{
    [Route("contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // GET /contacts
        [HttpGet]
        public ActionResult<IEnumerable<Contact>> GetAllContacts(
            [FromQuery] string? firstName, 
            [FromQuery] string? lastName, 
            [FromQuery] string? phoneNumber, 
            [FromQuery] string? email)
        {
            var contacts = _contactService.GetAll(firstName, lastName, phoneNumber, email);
            return Ok(contacts);
        }

        // GET /contacts/name/{lastName}
        [HttpGet("name/{lastName}")]
        public ActionResult<Contact> GetByLastName(string lastName)
        {
            var contact = _contactService.GetByLastName(lastName);
            return contact != null ? Ok(contact) : NotFound($"Contact avec le nom \"{lastName}\" non trouvé.");
        }

        // GET /contacts/{id}
        [HttpGet("{id}")]
        public ActionResult<Contact> GetById(int id)
        {
            var contact = _contactService.GetById(id);
            return contact != null ? Ok(contact) : NotFound($"Contact avec l'id {id} non trouvé.");
        }

        // POST /contacts
        [HttpPost]
        public ActionResult<Contact> Create([FromBody] Contact contact)
        {
            try
            {
                var newContact = _contactService.Create(contact);
                return CreatedAtAction(nameof(GetById), new { id = newContact.Id }, newContact);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erreur lors de la création du contact : {ex.Message}");
            }
        }

        // PUT /contacts/{id}
        [HttpPut("{id}")]
        public ActionResult<Contact> Update(int id, [FromBody] Contact contact)
        {
            try
            {
                var updatedContact = _contactService.Update(id, contact);
                if (updatedContact == null)
                {
                    return NotFound($"Contact avec l'id {id} non trouvé.");
                }
                return Ok(updatedContact);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erreur lors de la mise à jour du contact : {ex.Message}");
            }
        }

        // DELETE /contacts/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var result = _contactService.Delete(id);
                return result ? NoContent($"Contact {id} supprimé.") : NotFound($"Contact avec l'id {id} non trouvé.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Erreur lors de la suppression du contact : {ex.Message}");
            }
        }
    }
}
```

---

### **Étape 7 : Configurer l'injection des dépendances dans `Program.cs`**  

Dans `Program.cs`, enregistrer les services et le repository :  

```csharp
using ContactApi.Data;
using ContactApi.Repositories;
using ContactApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuration de la base de données
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Injection des dépendances
builder.Services.AddScoped<IRepository<Contact, int>, ContactRepository>();
builder.Services.AddScoped<IContactService, ContactService>();

// Ajout des contrôleurs
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();
```

---

### **Étape 8 : Tester l'API avec Postman ou Swagger**  

1. **Démarrer l’application**  
   - Lancer l'API en appuyant sur `Ctrl + F5` dans Visual Studio  
   - Swagger s'ouvre automatiquement sur `https://localhost:port/swagger`  

2. **Tester les endpoints**  

| Méthode | URL | Description |
|---------|------------------------|---------------------------------|
| GET | `/contacts` | Récupérer tous les contacts |
| GET | `/contacts?firstName=John` | Filtrer par prénom |
| GET | `/contacts/name/DUPONT` | Trouver par nom |
| GET | `/contacts/1` | Trouver un contact par ID |
| POST | `/contacts` | Ajouter un contact |
| PUT | `/contacts/1` | Modifier un contact |
| DELETE | `/contacts/1` | Supprimer un contact |

3. **Exemple de requête `POST` (Ajout de contact) dans Postman**  

- URL : `https://localhost:port/contacts`  
- Méthode : `POST`  
- Body (JSON) :  

```json
{
    "firstName": "Jean",
    "lastName": "DUPONT",
    "gender": "M",
    "birthDate": "1990-05-15",
    "email": "jean.dupont@email.com",
    "phoneNumber": "+33612345678"
}
```

4. **Exemple de requête `PUT` (Modification d'un contact)**  

- URL : `https://localhost:port/contacts/1`  
- Méthode : `PUT`  
- Body (JSON) :  

```json
{
    "firstName": "Jean",
    "lastName": "DUPONT",
    "gender": "M",
    "birthDate": "1990-05-15",
    "email": "jean.dupont@gmail.com",
    "phoneNumber": "+33698765432"
}
```

---


### **Étape 8 : Amméliorer la documentation OpenAPI**  

Voici des ajouts pour améliorer la documentation Swagger/OpenAPI du ContactController, avec des attributs et signatures de méthodes uniquement.

#### **1. `GetAllContacts`**

```csharp
[HttpGet]
[SwaggerOperation(Summary = "Obtenir la liste des contacts",
                  Description = "Récupère tous les contacts avec des filtres optionnels sur le prénom, le nom, le numéro de téléphone et l'email.")]
[ProducesResponseType(typeof(IEnumerable<Contact>), StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public IActionResult GetAllContacts([FromQuery] string? firstName, [FromQuery] string? lastName, [FromQuery] string? phoneNumber, [FromQuery] string? email)
```


#### **2. `GetByLastName`**

```csharp
[HttpGet("name/{lastName}")]
[SwaggerOperation(Summary = "Obtenir un contact par nom", 
                  Description = "Récupère un contact en fonction de son nom de famille.")]
[ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
public IActionResult GetByLastName(string lastName)
```


#### **3. `GetById`**

```csharp
[HttpGet("{id}")]
[SwaggerOperation(Summary = "Obtenir un contact par ID", 
                  Description = "Récupère un contact en fonction de son identifiant unique.")]
[ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
public IActionResult GetById(int id)
```


#### **4. `Create`**

```csharp
[HttpPost]
[SwaggerOperation(Summary = "Créer un nouveau contact", 
                  Description = "Ajoute un nouveau contact dans le répertoire.")]
[ProducesResponseType(typeof(Contact), StatusCodes.Status201Created)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public IActionResult Create([FromBody] Contact contact)
```


#### **5. `Update`**

```csharp
[HttpPut("{id}")]
[SwaggerOperation(Summary = "Mettre à jour un contact", 
                  Description = "Met à jour les informations d'un contact existant.")]
[ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public IActionResult Update(int id, [FromBody] Contact contact)
```


#### **6. `Delete`**

```csharp
[HttpDelete("{id}")]
[SwaggerOperation(Summary = "Supprimer un contact", 
                  Description = "Supprime un contact à partir de son identifiant.")]
[ProducesResponseType(StatusCodes.Status204NoContent)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
public IActionResult Delete(int id)
```


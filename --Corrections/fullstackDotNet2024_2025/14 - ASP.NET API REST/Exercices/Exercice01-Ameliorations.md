# **Améliorations possibles**  

#### **1. Gestion des erreurs et logging**  
L'ajout de `ILogger` permettrait de mieux suivre les erreurs en production et d'améliorer le débogage.  

**Exemple d'implémentation dans le service :**  
```csharp
private readonly ILogger<ContactService> _logger;

public ContactService(IRepository<Contact, int> repository, ILogger<ContactService> logger)
{
    _repository = repository;
    _logger = logger;
}

public Contact Create(Contact contact)
{
    try
    {
        return _repository.Add(contact) ?? throw new Exception("Échec de la création du contact.");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Erreur lors de la création du contact.");
        throw;
    }
}
```
---

#### **2. Filtrage plus flexible**  
Améliorer le filtrage en ajoutant des critères optionnels, comme la date de naissance ou le genre.  

**Exemple :**  
```csharp
public IEnumerable<Contact> GetAll(string? firstName = null, string? lastName = null, string? phoneNumber = null, string? email = null, DateTime? birthDate = null, string? gender = null)
{
    return _repository.GetAll(c =>
        (string.IsNullOrEmpty(firstName) || c.FirstName.Contains(firstName, StringComparison.OrdinalIgnoreCase)) &&
        (string.IsNullOrEmpty(lastName) || c.LastName.Contains(lastName, StringComparison.OrdinalIgnoreCase)) &&
        (string.IsNullOrEmpty(phoneNumber) || c.PhoneNumber.Contains(phoneNumber)) &&
        (string.IsNullOrEmpty(email) || c.Email.Contains(email, StringComparison.OrdinalIgnoreCase)) &&
        (!birthDate.HasValue || c.BirthDate == birthDate.Value) &&
        (string.IsNullOrEmpty(gender) || c.Gender == gender));
}
```
---

#### **3. Utilisation du DTO pattern**  
Séparer les modèles de la base de données des objets utilisés dans les requêtes et réponses en utilisant DTOs. Cela permet de mieux contrôler la validation et la sérialisation.

**1. Création des DTOs**
On définit des **DTOs** pour la création et la mise à jour des contacts :

```csharp
public class ContactDto
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    [Phone]
    public string PhoneNumber { get; set; }
}
```

**2. Configuration AutoMapper**
Ajout du package `Automapper`. 
On configure **AutoMapper** pour mapper automatiquement les DTOs vers l’entité `Contact` :

```csharp
public class ContactProfile : Profile
{
    public ContactProfile()
    {
        CreateMap<ContactDto, Contact>();
    }
}
```

**3. Implémentation dans le Service**
On applique la conversion dans le **service**, et non dans le contrôleur :

```csharp
public class ContactService : IContactService
{
    private readonly IRepository<Contact, int> _repository;
    private readonly IMapper _mapper;

    public ContactService(IRepository<Contact, int> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public ContactDto Create(ContactDto contactDto)
    {
        var contact = _mapper.Map<Contact>(contactDto);
        return _mapper.Map<ContactDto>(_repository.Add(contact)) ?? throw new Exception("Échec de la création du contact.");
    }
}
```

4. Modification du Contrôleur**
Le contrôleur est maintenant plus propre :

```csharp
[HttpPost]
public IActionResult Create([FromBody] ContactDto contactDto)
{
    if (!ModelState.IsValid)
        return BadRequest(ModelState);

    var newContact = _contactService.Create(contactDto);
    return CreatedAtAction(nameof(GetById), new { id = newContact.Id }, newContact);
}
```

---

#### **4. Utilisation de méthodes asynchrones**  
Passer les méthodes de service et repository en **async/await** pour améliorer les performances sur des bases de données ou services externes.  

**Exemple :**  
Service asynchrone :  
```csharp
public async Task<Contact> CreateAsync(Contact contact)
{
    try
    {
        return await _repository.AddAsync(contact) ?? throw new Exception("Échec de la création du contact.");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Erreur lors de la création du contact.");
        throw;
    }
}
```
Utilisation dans le contrôleur :  
```csharp
[HttpPost]
public async Task<IActionResult> Create([FromBody] ContactDto contactDto)
{
    if (!ModelState.IsValid)
        return BadRequest(ModelState);

    var contact = _mapper.Map<Contact>(contactDto);
    var newContact = await _contactService.CreateAsync(contact);
    return CreatedAtAction(nameof(GetById), new { id = newContact.Id }, newContact);
}
```
---

#### **5. Gestion d'erreurs centralisée**  
Éviter la répétition de `try/catch` en utilisant un **middleware global** pour intercepter et formater les erreurs.  

**Middleware d'erreur global :**  
```csharp
public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Une erreur non gérée est survenue.");
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Une erreur interne s'est produite.");
        }
    }
}
```
Enregistrement du middleware dans `Program.cs` :  
```csharp
app.UseMiddleware<GlobalExceptionMiddleware>();
```


---

#### **6. Pour aller (toujours) plus loin...** 
- Implémenter la Programmation Orientée Aspect (AOP) pour une meilleure gestion des Exceptions, gestion du Logging ou encore des Transactions EF Core
- Ajouter un système d'Authentification (JWT/OAuth) pour sécuriser l'accès aux données de l'API
- Découper le projet en plusieurs projets C# par responsabilitées : ContactsProject.API (PL), ContactsProject.BLL, ContactsProject.DAL, ContactsProject.Models, ContactsProject.DTOs
 
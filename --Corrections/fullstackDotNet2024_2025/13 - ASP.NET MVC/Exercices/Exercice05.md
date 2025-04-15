### Exercice 5 Asp.NET Core
**Objectifs:** Comprendre l'utilisation EFCore dans un projet ASP.NET Core MVC

En partant de l'exercice 4, 
- créer une BDD à l'aide d'Entity Framework Core pour les Marmosets avec un seed (Data Seeding)
- récupérer ces données dans les actions liste et détails pour les afficher dans les views

Le but final étant de remplacer la FakeDb pour stoquer durablement nos entités

##### Aides :
- Toutes les méthodes vues dans le module EFCore fonctionnent toujours dans ce type de projet
- Enregistrer un DbContext dans le conteneur de dépendances (nécessaire aux migrations):
```cs
builder.Services.AddDbContext<ApplicationDbContext>();
```

Bonus : Réussir à déplacer le Connection String dans la partie adaptée de appsettings.json
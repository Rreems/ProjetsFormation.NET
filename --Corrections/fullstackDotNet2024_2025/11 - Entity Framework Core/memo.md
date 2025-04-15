# Mémo EFCore

## Méthode 01 - dotnet ef CLI
1. Installer Entity Framework
	- installation du CLI de EFCore: `dotnet tool install --global dotnet-ef --version "6.x.x"` 
	- /!\ Sélectionner la version en lien avec votre SDK .NET (ex: 6.x.x)
	- Installer le package nugget : `Microsoft.EntityFrameworkCore.SqlServer` 
	- Puis : `Microsoft.EntityFrameworkCore.Design` qui permet d'exécuter des commandes dans le terminal
2. Créer des modèles de l'application
3. Création de la classe DbContext
	- Créer une classe qui hérite de `DbContext` généralement `ApplicationDbContext`
	- Surcharger la méthode `OnConfiguring()` pour utiliser la base de données souhaitée
	- Créer des propriétés `DbSet<>` pour vos entités, nommer les au pluriel !
	- Créer un constructeur de base qui utilise le constructeur du parent
4. Commandes dotnet ef
	- Pour créer une migration, taper `dotnet ef migrations add <nom migration>`
	- Pour mettre à jour le schéma de la base de données taper : `dotnet ef database update`
5. Supprimer la base de données
	- `dotnet ef database drop`

## Méthode 02 - Package Tools
1. Installer Entity Framework
	- /!\ Sélectionner la version en lien avec votre SDK .NET (ex: 6.x.x)
	- Installer le package nugget : `Microsoft.EntityFrameworkCore.SqlServer` 
	- Puis : `Microsoft.EntityFrameworkCore.Tools` qui permet d'exécuter des commandes dans le terminal
2. Créer des modèles de l'application
3. Création de la classe DbContext
	- Créer une classe qui hérite de `DbContext` généralement `ApplicationDbContext`
	- Surcharger la méthode `OnConfiguring()` pour utiliser la base de données souhaitée
	- Créer des propriétés `DbSet<>` pour vos entités, nommer les au pluriel !
	- Créer un constructeur de base qui utilise le constructeur du parent
4. Commandes dotnet ef dans la console du Package Manager `Outils -> Gestionnaire de package Nugget -> Console du gestionnaire de package`
	- Pour créer une migration, taper `Add-Migration <nom>`
	- Pour mettre à jour le schéma de la base de données taper : `Update-Database`
5. Supprimer la base de données
	- `Drop-Database`

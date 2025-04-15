# Exercice 01 – Création d’une Web API

## Objectif

Découverte du fonctionnement des Web API en ASP.NET, dans la réalisation d’un projet de répertoire en ligne de contacts. L’API aura pour but de réaliser un CRUD basique dans une base de données réelle via Entity Framework Core. L’API ne disposera pas de sécurité particulière et permettra de gérer des contacts dans une base de données.

## Sujet

Vous allez créer une Web API permettant de gérer des contacts dans un répertoire. Les utilisateurs de l'API pourront :
- Voir un contact en fonction de son Id.
- Voir un contact en fonction de son nom.
- Voir tous les contacts.
- Filtrer les contacts en fonction de leur prénom, nom, numéro et/ou email (utiliser des Contains).
- Ajouter un contact (avec validations).
- Modifier un contact (avec validations).
- Supprimer un contact.

### Contraintes de validation

Lors de l'ajout ou de la modification des contacts, les champs suivants devront être validés :
- **Nom** : Doit être en majuscules.
- **Prénom** : Doit commencer par une majuscule.
- **Date de naissance** : Doit être après 1910.
- **Genre** : Doit être un seul caractère parmi `[F, M, N]`.
- **Email** : Facultatif, si fourni, doit respecter un format valide d'email (validation via regex ou annotation appropriée).
- **Numéro de téléphone** : Facultatif, si fourni, doit respecter un format valide de numéro de téléphone (validation via regex ou annotation appropriée).

### Modèle Contact

Voici le modèle de données pour le contact :

- **Id** : `int`
- **FirstName** : `string` (obligatoire)
- **LastName** : `string` (obligatoire)
- **FullName** : `string` (lecture seule, à générer à partir du prénom et du nom)
- **Gender** : `string` (obligatoire)
- **BirthDate** : `DateOnly` (obligatoire)
- **Age** : `int` (lecture seule, à calculer à partir de la date de naissance)
- **Email** : `string` (facultatif)
- **PhoneNumber** : `string` (facultatif)

### Architecture en couches (N-Tier)

Votre application devra suivre une architecture en couches :
1. **Controller** : Contient les actions HTTP pour interagir avec l'API.
2. **Service** : Contient la logique métier de gestion des contacts.
3. **Repository** : Gère l'accès à la base de données via Entity Framework Core.

Vous devrez utiliser L'Inversion de Contrôle en dépendant d'interfaces plutôt que d'implémentations.

### Tâches à réaliser

1. Créer un projet ASP.NET Core Web API.
2. Créer le modèle `Contact` en suivant les spécifications mentionnées.
3. Configurer Entity Framework Core pour utiliser une base de données.
4. Implémenter le ContactRepository et son interface (CRUD avec EF Core).
5. Implémenter le ContactService et son interface (Logique Métier, ici peu de choses en réalité).
6. Implémenter le ContactController (Endpoints : routes et verbes, normaliser les code de retour et les body).
7. Ajouter les validations de champs demandées avec des annotations sur le modèle.
8. Tester l'API avec Postman et Swagger.

Bonne chance !

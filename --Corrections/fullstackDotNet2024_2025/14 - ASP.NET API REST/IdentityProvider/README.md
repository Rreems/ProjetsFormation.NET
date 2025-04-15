# IdentityProvider Microservice

## Migrations et premier lancement
Les migrations de db sont faites automatiquement au premier lancement de l'application
Un utilisateur racine avec le role admin est créé

## Identifiants du root admin
```json
{
  "email": "admin@aston.com",
  "password": "P@ssWord!12"
}
```

## Variables d'environnement
Les varenv a saisir avec exemples :
```
ASPNETCORE_ENVIRONMENT=Production
ConnectionStrings__DefaultConnection="Host=localhost;Port=5432;Database=mydatabase;Username=myuser;Password=mysecretpassword" \
AppSettings__SecretKey="Ceci est ma super clé secrete indéchiffrable. Vous ne la trouverez jamais." \
AppSettings__TokenExpirationDays=7
```

## Swagger
SwaggerUI est disponnible (exceptionnellement) en production
Route : /swagger
Spec OpenAPI : /swagger/v1/swagger.json


## Lancement simple docker
```sh
docker build -t yourappname . && docker run -d -p 8080:80 --name yourappname \
-e ConnectionStrings__DefaultConnection="Host=localhost;Port=5432;Database=mydatabase;Username=myuser;Password=mysecretpassword" \
-e AppSettings__SecretKey="Ceci est ma super clé secrete indéchiffrable. Vous ne la trouverez jamais." \
-e AppSettings__TokenExpirationDays=7 \
yourappname
```

## Liste des Endpoints

| Méthode HTTP | Point de terminaison              | Description                                  | Requiert un administrateur |
|--------------|-----------------------------------|----------------------------------------------|----------------------------|
| GET          | /api/Users                        | Récupérer la liste de tous les utilisateurs  | Oui                        |
| GET          | /api/Users/{id}                   | Récupérer les détails d'un utilisateur par ID| Oui                        |
| DELETE       | /api/Users/{id}                   | Supprimer un utilisateur spécifique par ID   | Oui                        |
| POST         | /api/Authentication/register      | Enregistrer un nouvel utilisateur            | Non (sauf si isAdmin == true)   |
| POST         | /api/Authentication/login         | Se connecter et obtenir un token JWT         | Non                        |
| GET          | /api/Authentication/validate      | Valider le token JWT actuel                  | Non                        |


### Règle de l'endpiont `api/register`
Possible de créer un utilisateur sur api/register selon ces règles (Gherkin):

```gherkin
Fonctionnalité: Enregistrement d'utilisateur

  Scénario: S'enregistrer en tant qu'utilisateur non-admin
    Étant donné qu'un nouvel utilisateur tente de s'enregistrer avec l'email "user@example.com"
    Et l'utilisateur n'a pas de privilèges administratifs
    Et aucun utilisateur n'existe avec l'email "user@example.com"
    Quand l'utilisateur soumet le formulaire d'inscription
    Alors l'utilisateur doit être créé avec succès
    Et la réponse doit indiquer un succès
    Et le champ "CreatedBy" doit être nul

  Scénario: S'enregistrer avec un email déjà existant
    Étant donné qu'un utilisateur existe avec l'email "user@example.com"
    Quand un nouvel utilisateur tente de s'enregistrer avec le même email "user@example.com"
    Alors l'enregistrement doit échouer
    Et la réponse doit indiquer que l'email existe déjà

  Scénario: S'enregistrer en tant qu'admin sans privilèges administratifs
    Étant donné qu'un utilisateur non-admin tente de s'enregistrer avec l'email "admin@example.com"
    Et la demande d'inscription spécifie des privilèges administratifs
    Quand l'utilisateur soumet le formulaire d'inscription
    Alors l'enregistrement doit échouer
    Et la réponse doit indiquer un accès non autorisé
    Et le message d'erreur doit indiquer "Vous ne pouvez pas créer un administrateur en tant qu'utilisateur."

  Scénario: S'enregistrer en tant qu'admin avec des privilèges administratifs
    Étant donné qu'un utilisateur admin authentifié avec UserId "1234"
    Et l'utilisateur tente de s'enregistrer un nouvel utilisateur admin avec l'email "admin@example.com"
    Et aucun utilisateur n'existe avec l'email "admin@example.com"
    Quand l'utilisateur admin soumet le formulaire d'inscription
    Alors le nouvel utilisateur admin doit être créé avec succès
    Et la réponse doit indiquer un succès
    Et le champ "CreatedBy" doit être défini à "1234"

```
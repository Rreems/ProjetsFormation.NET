# Memo SQL Server

## Créer une base de donnée sql server
> Ne fonctionne que sur Windows Pro et certaines éditions de Windows Famille

- Ouvrir un terminal (Terminal ou PowerShell) => peu importe l'endroit
- Créer la base (utiliser le nom de base que vous voulez): 
  `sqllocaldb c CoursSQL` 
- Lancer la base : 
  `sqllocaldb s CoursSQL`

Arreter et supprimer :
- `sqllocaldb p CoursSQL`
- `sqllocaldb d CoursSQL`


## Utiliser une BDD avec Visual Studio
- Accéder à l'Explorateur de Serveur (Menu rechercher en haut)
- Sélectionner "Microsoft SQL Server" comme source de données
- Ajouter une connexion à une Base de Données
- Saisir cette chaine : `(localdb)\NomdeLaBase`  
  (remplacer par le nom de votre base exemple :`(localdb)\CoursSQL`)
- Pensez à renommer la Base de donnée pour la retrouver facilement (avec le nom)


## Se connecter depuis un fichier sql
- En haut du fichier, bouton "Connexion" 
- Dans Local sélectionner votre base de données > Se Connecter


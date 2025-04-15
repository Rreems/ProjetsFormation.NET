# Memo SQL Server

## Cr�er une base de donn�e sql server
> Ne fonctionne que sur Windows Pro et certaines �ditions de Windows Famille

- Ouvrir un terminal (Terminal ou PowerShell) => peu importe l'endroit
- Cr�er la base (utiliser le nom de base que vous voulez): 
  `sqllocaldb c CoursSQL` 
- Lancer la base : 
  `sqllocaldb s CoursSQL`

Arreter et supprimer :
- `sqllocaldb p CoursSQL`
- `sqllocaldb d CoursSQL`


## Utiliser une BDD avec Visual Studio
- Acc�der � l'Explorateur de Serveur (Menu rechercher en haut)
- S�lectionner "Microsoft SQL Server" comme source de donn�es
- Ajouter une connexion � une Base de Donn�es
- Saisir cette chaine : `(localdb)\NomdeLaBase`  
  (remplacer par le nom de votre base exemple :`(localdb)\CoursSQL`)
- Pensez � renommer la Base de donn�e pour la retrouver facilement (avec le nom)


## Se connecter depuis un fichier sql
- En haut du fichier, bouton "Connexion" 
- Dans Local s�lectionner votre base de donn�es > Se Connecter


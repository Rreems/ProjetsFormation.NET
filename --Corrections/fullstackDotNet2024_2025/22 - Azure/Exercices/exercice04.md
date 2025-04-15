# Exercice 04

Réaliser le déploiement d'une application web de type ASP.NET Core MVC sur Azure. 

Cette application devra utiliser un conteneur pour fonctionner et une base de données elle-aussi présente sur Azure. 

Il vous faudra donc réaliser les étapes suivantes: 

* Créer une base de données Azure SQL Database
* Créer une application de type ASP.NET Core MVC
* Connecter, via Entity Framework Core, votre application à la base de données dans le but d'en manipuler les entités
* Réaliser le code de votre application web de sorte à pouvoir réaliser un CRUD d'une entité de données.
* Conteneuriser votre application Web 
* Créer un registre de conteneur sur Azure
* Publier notre image d'application sur le registre de conteneur Azure 
* Déployer sur Azure une instance de conteneur faisant tourner notre image nouvellement publiée
* Vérifier que l'application fonctionne bien sur Azure
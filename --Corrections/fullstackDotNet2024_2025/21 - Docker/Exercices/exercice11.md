# Exercice 11

Réaliser le déploiement avec Docker d'une API réalisée en .NET accompagnée d'une base de données de type MySQL. 

Ces deux ressources devront être déployées au moyen d'un fichier `docker-compose.yml`. 

## Conseils 

Attention à bien utiliser des variables d'environnement pour que la chaine de connexion de l'API pour l'accès à la base de donnée soit en lien avec la configuration de la base de données. 

Procéder par étapes: 

* Faire un conteneur de type MySQL et faire en sorte de pouvoir y accéder sur notre machine, avec par exemple l'interface de connexion à un serveur de BdD de Visual Studio
* Réaliser un projet de type Web API et faire en sorte d'utiliser Entity Framework Core pour se connecter et gérer les données dans la base de données créée en étape 1
* Dockerizer l'application web de sorte à ce que elle aussi puisse tourner dans un conteneur
* Ecrire un fichier docker-compose.yml permettant le déploiement de l'ensemble de nos ressources d'un seul coup
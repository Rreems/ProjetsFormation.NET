# Exercice 2

Réaliser, via Docker, un déploiement de deux site web gérés par NGINX. Chaque site devra posséder une page d'accueil personnalisée, par exemple avec "Welcome to container A" et "Welcome to container B".

Il devra être possible d'atteindre ces deux serveurs web depuis notre propre ordinateur, pour cela, il faudra réaliser un `port forwarding`. 

**Attention** à ne pas tenter de brancher deux fois le même port de notre machine sous peine d'avoir une erreur

L'objectif est ici d'obtenir, lors de l'appel GET des noms de domaines, deux sites indépendants;
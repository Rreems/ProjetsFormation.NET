# Exercice 1

Réaliser, via Docker, un déploiement de deux environnements de travail de type Linux (distributions au choix). Chaque environnement devra contenir un dossier `app` qui contiendra en son sein un fichier texte : `config.txt`. Le contenu de ce fichier de configuration est libre, il peut s'agir d'un simple `Hello World from container XXXX`.

L'objectif est ici d'obtenir, lors de l'inspection des conteneurs, deux conteneurs faisant tourner de façon indépendante deux environnements distincts, pouvant provenir de la même distribution. Ces deux environnements devront avoir un nom différent.
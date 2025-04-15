# Exercice 4

Réaliser la publication d'un site web déployé sur un conteneur Docker et en réaliser le développement localement via VS Code. 

Pour cela, il vous faudra relier votre dossier de travail au dossier de déploiement NGINX du conteneur.

Pour realiser un Bind Mount, il faut utiliser la syntaxe suivante : 

```bash
docker run -v <chemin fichier PC>:<chemin fichier conteneur> <nom image>
```
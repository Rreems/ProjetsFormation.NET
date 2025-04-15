#!/bin/bash

# Lister toutes les branches (locales + remotes)
git branch -a

# Ajouter une origin distante au repository
git remote add origin https://votre-repo.git

# Vérifier les dépôts distants configurés
git remote -v

# Créer une nouvelle branche et basculer dessus
git checkout -b nouvelle-branche

# Faire des modifications (simulées ici par la création d'un fichier)
touch nouveau_fichier.txt
git add nouveau_fichier.txt
git commit -m "Ajout d'un nouveau fichier sur nouvelle-branche"

# Pousser la nouvelle branche vers le dépôt distant
git push origin nouvelle-branche

# Basculer sur la branche principale
git checkout main

# Récupérer les dernières modifications du dépôt distant
git fetch

# Lister toutes les branches locales et distantes après le fetch
git branch -a

# Fusionner les modifications de 'nouvelle-branche' dans 'main'
git merge origin/nouvelle-branche

# Pousser les modifications fusionnées vers le dépôt distant
git push origin main

# Afficher le statut final du dépôt
git status

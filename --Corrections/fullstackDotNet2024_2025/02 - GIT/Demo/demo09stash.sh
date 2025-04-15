#!/bin/bash

# Afficher le statut actuel du dépôt
git status

# Sauvegarder les modifications non validées
echo "Stash des modifications non validées..."
git stash save "temporaire"

# Afficher le statut après le stash
git status

# Effectuer des opérations ou des changements ici
# Par exemple, changer de branche
git checkout main

# List l'ensemble des éléments stash
git stash list

# Restaurer les modifications sauvegardées
git stash pop

git status

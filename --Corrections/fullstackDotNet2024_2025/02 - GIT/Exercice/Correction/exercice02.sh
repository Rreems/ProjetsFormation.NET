#!/bin/bash

# Étape 1 : Créer un nouveau repository Git
git init

# Étape 2 : Ajouter un fichier et le commiter
echo "Contenu du premier fichier" > fichier1.txt
git add fichier1.txt
git commit -m "Ajout du premier fichier"

# Étape 3 : Ajouter un deuxième fichier et le commiter
echo "Contenu du deuxième fichier" > fichier2.txt
git add fichier2.txt
git commit -m "Ajout du deuxième fichier"

# Étape 4 : Vérifier l’historique (on doit avoir 2 commits)
git log --oneline

# Étape 5 : Faire des modifications sur le deuxième fichier et le commiter
echo "Modification du deuxième fichier" >> fichier2.txt
git add fichier2.txt
git commit -m "Modification du deuxième fichier"

# Étape 6 : Annuler les modifications du dernier commit
git reset --hard HEAD~1

# Étape 7 : Vérifier l’historique (on doit avoir 2 commits)
git log --oneline

# Étape 8 : Créer une branche à partir du 1er commit
git checkout -b nouvelle_branche $(git rev-list --max-parents=0 HEAD)

# Étape 9 : Faire un commit sur la branche
echo "Contenu supplémentaire pour la branche" > fichier_branche.txt
git add fichier_branche.txt
git commit -m "Ajout d'un fichier sur la nouvelle branche"

# Étape 10 : Vérifier l’historique de la branche (on doit avoir 2 commits)
git log --oneline

# Étape 11 : Lister les branches (on doit avoir 1 branche)
git branch

# Étape 12 : Tagger la version
git tag v1.0

# Étape 13 : Revenir au sommet de la branche `main`
git checkout main

# Étape 14 : Lister les tags (on doit avoir un tag)
git tag

# Étape 15 : Supprimer la branche
git branch -d nouvelle_branche

# Étape 16 : Lister les branches
git branch
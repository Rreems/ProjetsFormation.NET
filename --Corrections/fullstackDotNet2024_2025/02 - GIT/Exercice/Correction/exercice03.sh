#!/bin/bash

# Étape 1 : Créer un nouveau repository Git
git init

# Étape 2 : Ajouter un fichier et le commiter `(C1)`
echo "Première ligne originale" > fichier.txt
git add fichier.txt
git commit -m "C1: Ajout du fichier initial"

# Étape 3 : Modifier la première ligne du fichier et commiter `(C2)`
echo "Première ligne modifiée dans C2" > fichier.txt
git add fichier.txt
git commit -m "C2: Modification de la première ligne"

# Étape 4 : Créer une feature branch `B1` à partir de `C1`
git checkout -b B1 HEAD~1

# Étape 5 : Faire une modification de la première ligne du fichier et commiter `(C3)`
echo "Première ligne modifiée dans C3" > fichier.txt
git add fichier.txt
git commit -m "C3: Modification de la première ligne dans B1"

# Étape 6 : Merger `B1` dans main en résolvant les conflits
git checkout main
git merge B1

# Résolution manuelle des conflits
echo "Première ligne modifiée dans C2 et C3" > fichier.txt
git add fichier.txt

# Finaliser le merge
git commit -m "Résolution des conflits et merge de B1 dans main"

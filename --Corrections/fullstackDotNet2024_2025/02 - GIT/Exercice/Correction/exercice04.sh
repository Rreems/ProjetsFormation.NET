#!/bin/bash

# Étape 1 : Créer un nouveau repository Git
git init

# Étape 2 : Ajouter un fichier et le commiter `(C1)`, le modifier et le commiter `(C2)`
echo "Contenu initial" > fichier.txt
git add fichier.txt
git commit -m "C1: Ajout du fichier initial"

echo "Modification pour C2" >> fichier.txt
git add fichier.txt
git commit -m "C2: Modification du fichier"

# Étape 3 : Créer une branche `B1` à partir de `C1`
git checkout -b B1 HEAD~1

# Étape 4 : Faire une modification du fichier et commiter `C3`
echo "Modification pour C3 sur B1" >> fichier.txt
git add fichier.txt
git commit -m "C3: Modification sur B1"

# Étape 5 : Rebaser la branche `B1` sur main
git checkout main
git rebase B1
# ou
git merge B1 --ff-only
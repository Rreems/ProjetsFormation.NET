#!/bin/bash

mkdir cherry-pick-demo && cd cherry-pick-demo
git init

echo "Fichier initial" > fichier1.txt
git add fichier1.txt
git commit -m "Commit 1 : Ajout de fichier1.txt"

echo "Modifications dans fichier1.txt" >> fichier1.txt
git add fichier1.txt
git commit -m "Commit 2 : Mise à jour de fichier1.txt"

git checkout -b feature

echo "Nouveau fichier pour la fonctionnalité" > fichier2.txt
git add fichier2.txt
git commit -m "Commit 3 : Ajout de fichier2.txt sur la branche 'feature'"

echo "Modifications dans fichier2.txt" >> fichier2.txt
git add fichier2.txt
git commit -m "Commit 4 : Mise à jour de fichier2.txt sur la branche 'feature'"

git checkout main

# Cherry-pick du commit spécifique
git cherry-pick HEAD~1

# Cherry-pick de plusieurs commits en une seule commande
git cherry-pick HEAD..feature

# Étape 6 : Gérer les conflits (simulation)
echo "6. Simulation de conflit dans cherry-pick"
echo "Conflit possible" >> fichier1.txt
git add fichier1.txt
git commit -m "Commit 5 : Changement conflictuel dans fichier1.txt"

# Cherry-pick d'un commit qui provoquera un conflit
git cherry-pick feature~1

echo "Résolution simulée de conflit"
echo "Résolu" >> fichier1.txt
git add fichier1.txt
git cherry-pick --continue

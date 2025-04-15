#!/bin/bash

mkdir rebase-demo && cd rebase-demo
git init

echo "Fichier principal, version 1" > fichier1.txt
git add fichier1.txt
git commit -m "Commit 1 : Ajout de fichier1.txt dans main"

echo "Fichier principal, version 2" >> fichier1.txt
git add fichier1.txt
git commit -m "Commit 2 : Mise à jour de fichier1.txt dans main"

git checkout -b feature

echo "Fichier fonctionnalité, version 1" > fichier2.txt
git add fichier2.txt
git commit -m "Commit 3 : Ajout de fichier2.txt dans feature"

echo "Fichier fonctionnalité, version 2" >> fichier2.txt
git add fichier2.txt
git commit -m "Commit 4 : Mise à jour de fichier2.txt dans feature"

git checkout main

echo "Fichier principal, version 3" >> fichier1.txt
git add fichier1.txt
git commit -m "Commit 5 : Nouvelle mise à jour de fichier1.txt dans main"

git checkout feature
git rebase main

git checkout main
echo "Conflit potentiel" >> fichier1.txt
git add fichier1.txt
git commit -m "Commit 6 : Modification conflictuelle dans fichier1.txt"

git checkout feature
git rebase main

echo "Résolution du conflit" >> fichier1.txt
git add fichier1.txt
git rebase --continue

git log --oneline --graph --all
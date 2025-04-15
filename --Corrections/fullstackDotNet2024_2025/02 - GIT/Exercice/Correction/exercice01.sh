#!/bin/bash

git init exerice01 && cd exercice01

echo "nouveau fichier" > fichier.txt
git status

git add fichier.txt
git status

git commit -m "ajout de fichier.txt"

echo "ajout de contenu" >> fichier.txt
git status

git commit -am "edition de fichier.txt"
# ou git add fichier.txt + git commit -m "edition de fichier.txt"

git log --oneline
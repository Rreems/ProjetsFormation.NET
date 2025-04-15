#!/bin/bash

# Recherche par dichotomie
mkdir bisect-demo && cd bisect-demo
git init
echo "Version OK" > fichier.txt
git add fichier.txt
git commit -m "Version OK"
echo "Version avec bug" >> fichier.txt
git commit -am "Bug introduit"
echo "Version OK après correction" > fichier.txt
git commit -am "Correction du bug"
git bisect start
git bisect bad
git bisect good HEAD~2
# Git trouve le commit fautif automatiquement
git bisect reset

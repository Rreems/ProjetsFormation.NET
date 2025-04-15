#!/bin/bash

mkdir grep-params-demo && cd grep-params-demo
git init

echo "Voici un exemple de texte dans ce fichier." > exemple.txt
echo "La commande git grep est utile pour rechercher du texte." >> exemple.txt
echo "Recherche de motifs dans les fichiers git." >> exemple.txt
git add exemple.txt
git commit -m "Ajout du fichier exemple.txt avec du texte à rechercher."

git grep "texte"

git grep -n "texte"

git grep "git" exemple.txt

mkdir subdir
echo "Mot de recherche dans un sous-dossier." > subdir/subfile.txt
git add subdir/subfile.txt
git commit -m "Ajout d'un fichier dans un sous-répertoire"
git grep "recherche" subdir

# Recherche insensible à la casse (-i)
git grep -i "GIT"

# Recherche d'un motif exact (-w)
git grep -w "texte"

# Recherche inversée (-v) pour exclure un motif
git grep -v "recherche"

# Recherche dans l'historique des commits (-e pour le mot et --pickaxe-all pour rechercher dans tout l'historique)
git log -p -S"texte"

# Recherche avec un motif dans les différences entre les commits (-G)
git diff -G"recherche"

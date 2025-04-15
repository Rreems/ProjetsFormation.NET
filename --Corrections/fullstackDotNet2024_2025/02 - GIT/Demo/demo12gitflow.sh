#!/bin/bash

# Initialiser un nouveau dépôt Git et se déplacer dans le répertoire
git init demo-git-flow && cd demo-git-flow

# Initialiser Git Flow
git flow init -d

# Démarrer une nouvelle fonctionnalité "hello-world"
git flow feature start hello-world

# Créer un fichier Python avec un message "hello world"
echo "print('hello world')" > hello.py

# Exécuter le script Python pour vérifier son contenu
python hello.py

# Ajouter le fichier au suivi Git
git add hello.py

# Commiter la nouvelle fonctionnalité
git commit -m "Add hello world feature"

# Terminer la fonctionnalité
git flow feature finish hello-world

# Démarrer une nouvelle release "0.0.1"
git flow release start 0.0.1

# Ajouter et commiter les changements de la release
git add .
git commit -m "Release 0.0.1"

# Terminer la release
git flow release finish '0.0.1'

# Démarrer un hotfix "0.0.2"
git flow hotfix start 0.0.2

# Modifier le fichier Python pour corriger un bug
echo "print('Hello, corrected world!')" > hello.py

# Ajouter et commiter la correction
git add hello.py
git commit -m "Hotfix: correction de bugs"

# Terminer le hotfix
git flow hotfix finish '0.0.2'

# Afficher l'historique des commits
git log --oneline --graph --all

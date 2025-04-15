# Liste les tags
git tag

# Créé un tag sur le commit du HEAD
git tag v1.0

# Créer un tag avec un message
git tag -a v1.1 -m "correction de bugs"

# Afficher le détail d'un tag
git show v1.1

# Pousser les tags locaux sur le dépôt distant
git push origin --tags
git push --tags

# Suppression d'un tag
git tag -d v1.1

# Se déplacer à l'aide des tags
git checkout v1.0
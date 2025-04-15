# Lister les branches du dépots (en local)
git branch

# Lister les branches distantes
git branch -r

# Lister toutes les branches
git branch -a

# Créer une branche
git branch feature/admin-panel

# Créer une branche et s'y déplacer
git checkout -b feature/google-auth
git switch -c feature/admin-panel


# Se déplacer sur la branche
git checkout feature/admin-panel

# Alternative à la syntaxe précédente
git switch feature/admin-panel

# Supprimer une branche
git branch -d feature/admin-panel
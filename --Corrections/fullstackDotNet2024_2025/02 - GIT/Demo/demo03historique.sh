# Afficher l'historique des commits de l'application
git log

# Permet de limiter le nombre de commit à afficher
git log -n 1

# Affiche l'historique sur une seule ligne
git log --oneline

# Affichage sous forme de graph
git log --oneline --graph --all

# Historique détaillé
git log -p

# Personnaliser l'affichage des logs
git log --pretty=format:"%h - %an %ar : %s"

# Afficher les commits par auteurs
git shortlog

# Afficher l'historique des dernières modification
git whatchanged

# Historique des déplacements du curseur HEAD
git reflog

# Afficher les statistiques
git log --stat
# editer le contenu du dernier commit
git commit --amend

# Précision du nouveau message à l'aide du paramètre -m
git commit --amend -m "edition du commit"

# Dans le cas où l'on oublie d'indexer un fichier, on peut également
# L'ajouter puis ré-éditer le dernier commit
git add mon_fichier_oublie.txt
git commit --amend --no-edit
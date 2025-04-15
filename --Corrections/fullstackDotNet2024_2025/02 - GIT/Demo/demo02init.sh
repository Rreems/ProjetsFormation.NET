git init

echo "mon premier fichier" > fichier.txt

git add fichier.txt

git commit -m "ajout du fichier"

echo "modification du fichier" >> fichier.txt

git add fichier.txt
git commit -m "edition du fichier"

# syntaxe alternative 

# dans le cas où aucun nouveau fichier n'a été créé, on peut juste créer un nouveau
# commit avec le paramètre -a pour --all qui commit tous les modifications de fichiers
git commit -am "édition du fichier"
# git commit --all --message "édition du fichier"
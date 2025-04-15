# Lancer un conteneur de type debian / ubuntu de façon interactive
docker run -it ubuntu
docker run -it debian

# Créer un dossier 'app'
mkdir app

# Créer un fichier 'config.txt' dans le dossier app
touch config.txt

# Mettre à jour les repos de packages
apt update 

# Installer le package 'nano'
apt install nano

# Ajouter au fichier un texte du style 'Hello from container XXXX'
nano config.txt

# On édite le fichier, on sauvegarde (CTRL + O), on ferme le flux (CTRL + X)

# On vérifie dans le fichier le contenu 
cat config.txt 

# Sortir du conteneur 
exit

# Vérifier les fichiers du conteneur
docker ps -a 
docker start -i <id-conteneur>
cat app/config.txt
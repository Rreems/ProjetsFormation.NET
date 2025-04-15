# Créer les deux conteneurs d'image `nginx`
docker run -d --name <container-name> -p <port pc>:80 nginx
docker run -d --name <container-name> -p <port pc>:80 nginx

# Entrer dans les conteneurs pour y modifier les fichiers interne
docker exec -it <container-name> bash

# Installer nano pour pouvoir éditer le fichier de la page d'accueil
apt update
apt install nano

# Modifier le fichier de la page d'accueil
nano /usr/share/nginx/html/index.html

# Vérifier dans le navigateur que l'on a bien les pages modifiées

# Si marche pas, mettre à jour les instances de NGINX
docker exec <container-name> service nginx restart
docker exec <container-name> service nginx restart
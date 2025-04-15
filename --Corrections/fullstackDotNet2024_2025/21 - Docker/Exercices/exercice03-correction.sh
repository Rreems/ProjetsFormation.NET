# Chercher une image du jeu 2048 dans DockerHub

# Récupérer l'image trouvée
docker pull evilroot/docker-2048

# Lancer un conteneur à partir de cette image, en liant le port PC 80 au port exposé par le conteneur
docker run -d -p 80:80 evilroot/docker-2048
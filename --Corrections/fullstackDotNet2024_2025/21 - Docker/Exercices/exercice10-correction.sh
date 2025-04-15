# Ecrire le fichier 'docker-compose-yml'

# Créer plusieurs conteneurs d'un coup via un déploiement multi-conteneur
docker compose up -d

# Entrer dans l'un des conteneurs
docker exec -it ubuntu-a bash

# Installer la commande 'ping'
apt update 
apt install -y iputils-ping

# Ping le conteneur B depuis le conteneur A
ping ubuntu-b
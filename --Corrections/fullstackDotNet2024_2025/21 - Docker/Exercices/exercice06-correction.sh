# Créer un réseau qui va accueillir les deux conteneurs
docker network create exercice-06

# Créer deux conteneurs supportant le ping, bien penser à les brancher au même réseau
docker run -it --name ub-a --network exercice-06 ubuntu
docker run -it --name ub-b --network exercice-06 ubuntu

# Installer la commande 'ping'
apt-get update -y
apt update -y 

apt install -y iputils-ping

# Entrer dans le conteneur B pour ping le conteneur A
docker start -i ub-b

ping -c 1 ub-a
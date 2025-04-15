# Créer le conteneur de type 'mysql' avec la bonne configuration
docker run -d --name db-1 -e MYSQL_ROOT_PASSWORD=password -v db-data:/var/lib/mysql mysql
docker run -d --name db-2 -e MYSQL_ROOT_PASSWORD=password -v db-data:/var/lib/mysql mysql

# Faire des modifications dans la base de données, donc dans les données du volume
docker exec -it db-1 bash
mysql -h localhost -u root -p

docker exec -it db-1 mysql -h localhost -u root -p

# Faire les vérifications que le système de fichier à bien été modifié
docker exec -it db-2 mysql -h localhost -u root -p
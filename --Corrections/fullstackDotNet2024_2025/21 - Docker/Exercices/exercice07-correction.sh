# Créer le réseau qui va regrouper les deux conteneurs
docker network create exercice-07

# Créer le conteneur du serveur MySQL, avec son volume pour la sauvegarde de ses données en cas de problème
docker run -d --name mysql --network exercice-07 -e MYSQL_ROOT_PASSWORD=root-password -e MYSQL_DATABASE=testdb -e MYSQL_USER=user -e MYSQL_PASSWORD=user-password -v exercice-07-data:/var/lib/mysql mysql

# Créer un conteneur de client MySQL
docker run -d --name mysql-client --network exercice-07 -e MYSQL_ROOT_PASSWORD=root-password mysql

# Entrer dans le conteneur du client pour se connecter au serveur
docker exec -it mysql-client bash

mysql -h mysql -u root -p

# Manipuler le serveur pour y changer son état
use testdb;
create table cats (cat_id int auto_increment primary key, cat_name varchar(50) not null, cat_breed varchar(50) not null, cat_color varchar(50) not null);
insert into cats (cat_name, cat_breed, cat_color)  values ("Berlioz", "Chartreux", "Gris");
select * from cats;
exit;
exit
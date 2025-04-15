create database appDb;

use appDb;

create table if not exists cats (
    cat_id int auto_increment primary key,
    cat_name varchar(50) not null,
    cat_breed varchar(50) not null,
    cat_color varchar(50) not null
);

insert into cats (cat_name, cat_breed, cat_color) values
    ("Berlioz", "Siamese", "Beige"),
    ("Caramel", "Chartreux", "Brown"),
    ("Spooky", "Sphinx", "Grey");
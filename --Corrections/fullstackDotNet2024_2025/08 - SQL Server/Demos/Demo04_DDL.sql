-- DDL : Data Definition Language

-- 1. CREATE

-- Cr�ation d'une base de donn�es
CREATE DATABASE demo_ddl;

-- Utilisation de la base de donn�es
USE demo_ddl;

USE master;

DROP DATABASE demo_ddl;

IF NOT EXISTS (SELECT [name] FROM sys.databases WHERE [name] = 'demo_ddl')
BEGIN
	-- Cr�ation de la base de donn�es avec encodage Fran�ais
	CREATE DATABASE demo_ddl COLLATE French_CI_AS;
END

CREATE TABLE users (
	users_id INT IDENTITY(1,1) PRIMARY KEY, -- Cl� primaire de la table, garanti l'unicit� de chaque enregistrement
	first_name NVARCHAR(50) NOT NULL, -- Champ pr�nom obligatoire
	last_name NVARCHAR(50) NOT NULL, -- Champ nom obligatoire
	email VARCHAR(255) NOT NULL UNIQUE, -- Impossible d'avoir 2 emails similaire
	created_at DATETIME2 DEFAULT GETDATE() -- Ajout d'une date de cr�ation par d�faut
);

SELECT * FROM sys.tables WHERE [name] = 'users';

-- Permet de v�rifier l'existence de la table users
IF OBJECT_ID('users', 'U') IS NOT NULL
BEGIN
	DROP TABLE users;
END

-- ALTER

-- Modification d'une table pour ajouter une colonne
ALTER TABLE users
ADD phone VARCHAR(10);

-- Modification du type de la colonne phone
ALTER TABLE users
ALTER COLUMN phone VARCHAR(20);

-- Renommer une table
EXEC sp_rename 'users', 'customers';

-- R�cup�rer le d�tail des colonnes d'une table
SELECT *
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'customers';

CREATE TABLE product (
	product_id INT IDENTITY(1,1),
	name NVARCHAR(50) NOT NULL,
	price MONEY NOT NULL,
	stock INT NOT NULL DEFAULT 0,
	category NVARCHAR(50),
	CONSTRAINT pk_product_id PRIMARY KEY(product_id), -- d�finition de la contrainte nomm�e
	CONSTRAINT ck_product_price CHECK(price > 0), -- v�rification du prix
	CONSTRAINT ck_product_stock CHECK(stock >= 0) -- Impossible d'avoir un stock n�gatif
);

EXEC sp_rename 'product', 'products';

CREATE TABLE orders (
	order_id INT IDENTITY(1,1),
	quantity INT NOT NULL,
	created_at DATETIME2 DEFAULT GETDATE(),
	customer_id INT NOT NULL,
	product_id INT NOT NULL,
	CONSTRAINT pk_order_id PRIMARY KEY(order_id),
	-- On pr�cise le nom de la foreign key, 
	-- la colonne qui abrite la cl�, 
	-- et la colonne de la table � laquelle elle fait r�f�rence
	CONSTRAINT fk_orders_customer_id FOREIGN KEY(customer_id) REFERENCES customers(users_id),
	CONSTRAINT fk_orders_product_id FOREIGN KEY(product_id) REFERENCES products(product_id)
);

-- Cr�ation d'une table virtuelle d�di�e � la lecture uniquement
CREATE VIEW OrderDetails
AS 
SELECT
	c.first_name,
	c.last_name,
	o.order_id,
	o.created_at,
	p.name,
	p.price,
	o.quantity,
	o.quantity * p.price AS total
FROM
	customers c
INNER JOIN
	orders o ON o.customer_id = c.users_id
INNER JOIN
	products p ON p.product_id = o.product_id;
GO

SELECT * FROM OrderDetails;
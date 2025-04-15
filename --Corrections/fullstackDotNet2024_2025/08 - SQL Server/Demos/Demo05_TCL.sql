-- TCL - Transaction Control Language

-- Démarrer une transaction sur la connexion
BEGIN TRAN;
BEGIN TRANSACTION;

INSERT INTO products
	([name], price, stock, category)
VALUES
	('scooter vmax', 3000, 2, 'véhicule');

SELECT * FROM products;
SELECT * FROM customers;

INSERT INTO
	customers
	(first_name, last_name, email, phone)
VALUES
	('Francky', 'Vincent', 'francky@vincent.fr', '0102030405');

-- Récupérer le dernier ID généré en base de données
SELECT SCOPE_IDENTITY();

-- Savepoint: checkpoint de la transaction, sauvegarde l'état actuel
SAVE TRAN checkpoint1;
SAVE TRANSACTION checkpoint1;

INSERT INTO orders
	(quantity, customer_id, product_id)
VALUES
	(1, 1, 3);

SELECT * FROM orders;

-- Permet de revenir à un état précédent de la transaction ou l'annuler complétement
ROLLBACK;
ROLLBACK TRAN checkpoint1;
ROLLBACK TRANSACTION checkpoint1;

-- Valide les opérations effectuées lors de la transaction
COMMIT;
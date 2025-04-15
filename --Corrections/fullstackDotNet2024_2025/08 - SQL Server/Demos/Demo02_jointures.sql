-- Création de la table Clients
--CREATE TABLE Clients (
--    id INT PRIMARY KEY IDENTITY(1,1),
--    first_name NVARCHAR(100),
--    last_name NVARCHAR(100),
--    city NVARCHAR(100),
--    age INT,
--    --CONSTRAINT PK_Clients_Id PRIMARY KEY (id)
--);

-- Création de la table Abonnements
--CREATE TABLE Abonnements (
--    client_id INT, -- FOREIGN KEY (client_id) REFERENCES Clients(id),
--    abonnement_type NVARCHAR(100),
--    CONSTRAINT FK_Client_Abonnement FOREIGN KEY (client_id)
--    REFERENCES Clients(id)
--);


-- Insertion des données dans la table Clients
--INSERT INTO Clients (first_name, last_name, city, age)
--VALUES 
--    ('John', 'Doe', 'New York', 34),
--    ('Alice', 'Smith', 'London', 28),
--    ('Michael', 'Johnson', 'Berlin', 40),
--    ('Emily', 'Brown', 'Paris', 25),
--    ('David', 'Lee', 'Tokyo', 31),
--    ('Sophia', 'Taylor', 'Sydney', 29),
--    ('Daniel', 'Anderson', 'Toronto', 45),
--    ('Olivia', 'Jackson', 'Rome', 38),
--    ('James', 'Moore', 'Moscow', 50),
--    ('Emma', 'Davis', 'New York', 22);

-- Insertion des données dans la table Abonnements
--INSERT INTO Abonnements (client_id, abonnement_type)
--VALUES 
--    (1, 'Premium'),
--    (2, 'Standard'),
--    (3, 'Premium'),
--    (4, 'Basic'),
--    (5, 'Premium'),
--    (5, 'Standard'), -- Un client avec plusieurs abonnements
--    (6, 'Basic'),
--    (7, 'Standard'), -- le n°8 n'a pas d'abonnement
--    (9, 'Premium'),
--    (10, 'Basic');


SELECT [Clients].first_name, Clients.last_name, Abonnements.abonnement_type
FROM Clients
INNER JOIN Abonnements
ON Clients.id = Abonnements.client_id;


SELECT Clients.first_name, Clients.last_name, COUNT(Abonnements.abonnement_type) AS nb_abo
FROM Clients
INNER JOIN Abonnements
ON Clients.id = Abonnements.client_id
GROUP BY Clients.first_name, Clients.last_name;



SELECT Clients.first_name, Clients.last_name, COUNT(Abonnements.abonnement_type) AS nb_abo
FROM Clients LEFT JOIN Abonnements
ON Clients.id = Abonnements.client_id
GROUP BY Clients.first_name, Clients.last_name;

-- Produit Cartésien
SELECT Clients.first_name, Clients.last_name,Clients.id,Abonnements.client_id, Abonnements.abonnement_type
FROM Clients, Abonnements;

-- Jointure par Produit Cartésien => A NE JAMAIS FAIRE 
SELECT Clients.first_name, Clients.last_name,Abonnements.client_id, Abonnements.abonnement_type
FROM Clients, Abonnements
WHERE Clients.id = Abonnements.client_id;


SELECT c.first_name, c.last_name, a.abonnement_type
FROM Clients AS c
INNER JOIN Abonnements AS a
ON c.id = a.client_id;





SELECT Clients.first_name, Clients.last_name, Abonnements.abonnement_type
FROM Clients LEFT JOIN Abonnements
ON Clients.id = Abonnements.client_id; 
-- Olivia est incluse à gauche, même si elle n'a pas d'abonnement


SELECT *
FROM Clients
LEFT JOIN Abonnements ON Clients.id = Abonnements.client_id;

SELECT *
FROM Clients
RIGHT JOIN Abonnements ON Clients.id = Abonnements.client_id;


-- Tout les clients qui n'ont pas d'abonnements
SELECT *
FROM Clients
WHERE Clients.id NOT IN (SELECT Abonnements.client_id FROM Abonnements);



-- Tables et données pour l'execice sur les jointures

-- Création de la table Purchases
CREATE TABLE Purchases (
    client_id INT,                    -- Clé étrangère vers la table Clients
    product NVARCHAR(100),            -- Nom du produit acheté
    amount DECIMAL(10, 2),            -- Montant de l'achat
    CONSTRAINT FK_Client_Purchases FOREIGN KEY (client_id) REFERENCES Clients(id) -- Contrainte de clé étrangère
);

-- Insertion des données dans la table Purchases
INSERT INTO Purchases (client_id, product, amount)
VALUES 
    (1, 'Laptop', 1200.50),           -- Achat par le client 1
    (1, 'Keyboard', 45.99),           -- Achat par le client 1
    (2, 'Smartphone', 800.00),        -- Achat par le client 2
    (2, 'Earbuds', 29.99),            -- Achat par le client 2
    (3, 'Tablet', 300.00),            -- Achat par le client 3
    (3, 'Cover', 20.00),              -- Achat par le client 3
    (4, 'TV', 500.00),                -- Achat par le client 4
    (4, 'HDMI Cables', 10.00),        -- Achat par le client 4
    (1, 'Mouse', 25.50),              -- Achat supplémentaire pour le client 1
    (5, 'Gaming Console', 450.00);    -- Achat par le client 5



--INNER JOIN :
--Sélectionnez les noms et prénoms des clients ainsi que les détails
--de leurs achats (si disponibles).

SELECT  
    c.first_name, 
    c.last_name, 
    p.product, 
    p.amount 
FROM 
    Clients c 
INNER JOIN 
    Purchases p
ON 
    c.id = p.client_id;


--LEFT JOIN :
--Sélectionnez tous les clients et les détails de leurs achats s'ils ont
--effectué des achats, sinon affichez les colonnes des achats avec des
--valeurs NULL.
SELECT  
    c.first_name, 
    c.last_name, 
    p.product, 
    p.amount 
FROM 
    Clients c 
LEFT JOIN 
    Purchases p
ON 
    c.id = p.client_id;

--RIGHT JOIN :
--Sélectionnez tous les achats et les détails des clients
--correspondants, même s'il n'y a pas de correspondance.
SELECT  
    c.first_name, 
    c.last_name, 
    p.product, 
    p.amount 
FROM 
    Clients c 
RIGHT JOIN 
    Purchases p
ON 
    c.id = p.client_id;


--FULL JOIN :
--Sélectionnez tous les clients et tous les achats, en affichant les
--détails des clients même s'ils n'ont pas effectué d'achats, et vice
--versa

SELECT  
    c.first_name, 
    c.last_name, 
    p.product, 
    p.amount 
FROM 
    Clients c 
FULL JOIN 
    Purchases p
ON 
    c.id = p.client_id;


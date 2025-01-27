
--## Partie DDL : Manipulation des structures (CREATE, ALTER, DROP)

--### Script SQL : Ajout de nouvelles tables

--1. **Table `Chat` (pour les chats)**
--   - Cr�ez une table nomm�e `Chat` avec les colonnes suivantes :
--     - `id` : Identifiant unique (cl� primaire, type `INT` avec auto-incr�mentation).
--     - `name` : Nom du chat (`NVARCHAR(50)`).
--     - `age` : �ge du chat (`INT`).
--     - `color` : Couleur du chat (`NVARCHAR(50)`).
--     - `id_maitre` : Identifiant du ma�tre (`INT`), cl� �trang�re vers `Personne`.

--2. **Table `RelationChatChien` (relations entre chats et chiens)**
--   - Cr�ez une table nomm�e `RelationChatChien` pour g�rer les relations entre les chats et les chiens, avec les colonnes suivantes :
--     - `id_chat` : Identifiant du chat (cl� �trang�re vers `Chat`).
--     - `id_chien` : Identifiant du chien (cl� �trang�re vers `Chien`).
--     - `relation_type` : Type de relation (`NVARCHAR(50)`), valeurs possibles : `loves`, `hates`, `neutral`.

-----

--### Questions

--#### Niveau 1 : CREATE
--1. Cr�ez la table `Chat` avec les sp�cifications ci-dessus.
--CREATE TABLE Chats (
--	id INT IDENTITY(1,1), 
--	name NVARCHAR(50) NOT NULL,
--	age INT DEFAULT 0,
--	color NVARCHAR(50),
--	id_maitre INT NOT NULL,
--	CONSTRAINT pk_id PRIMARY KEY(id),
--	CONSTRAINT fk_id_maitre FOREIGN KEY(id_maitre) REFERENCES Personne(id)
--);


--2. Cr�ez la table `RelationChatChien` pour g�rer les relations entre chats et chiens.
--CREATE TABLE RelationChatChien (
--	id_chat INT, 
--	id_chien INT, 
--	relation_type NVARCHAR(50) CHECK ( relation_type = 'loves' OR
--									   relation_type = 'hates' OR 
--								       relation_type = 'neutral'),
--	CONSTRAINT fk_id_chat FOREIGN KEY(id_chat) REFERENCES Chats(id),
--	CONSTRAINT fk_id_chien FOREIGN KEY(id_chien) REFERENCES Chien(id)
--	);






--#### Niveau 2 : INSERT et relations
--3. Ajoutez deux chats nomm�s "Garfield" (�ge : 5 ans, couleur : orange, ma�tre : Gandalf; 5) 
--      et "Salem" (�ge : 7 ans, couleur : noir, ma�tre : Frodo Baggins; 9).
--4. Ajoutez des relations dans `RelationChatChien` :
--   - "Garfield" aime "Milou".
--   - "Salem" d�teste "Idefix".
--   - "Garfield" est neutre avec "Hercules".

--INSERT INTO Chats (name, age, color, id_maitre)
--VALUES 
--    ('Garfield', 5, 'orange', 5), 
--    ('Salem', 7, 'noir', 9) ;
    
--INSERT INTO RelationChatChien (id_chat, id_chien, relation_type)
--VALUES 
--    (1, 11, 'loves' ),
--    (2, 13, 'hates' ),
--    (1, 15, 'neutral' );

--#### Niveau 3 : ALTER
--5. Ajoutez une colonne `gender` (type `NVARCHAR(10)`) � la table `Personne` pour indiquer le 
--genre du ma�tre (valeurs possibles : `Male`, `Female`, `Other`).

--ALTER TABLE Personne
--ADD gender NVARCHAR(50) DEFAULT 'other' CHECK ( gender = 'male' OR
--								   gender = 'female' OR 
--								   gender = 'other');


----6. Modifiez la colonne `size` dans la table `Chien` pour qu'elle soit de type `DECIMAL(6,2)`.
--ALTER TABLE Chien
--ALTER COLUMN size DECIMAL(6,2);


--#### Niveau 4 : DROP
--7. Supprimez la table `RelationChatChien`.

--DROP TABLE RelationChatChien;


--8. Supprimez la colonne `weight` de la table `Chien`.
--ALTER TABLE Chien
--DROP COLUMN weight;


-----

--### Questions bonus (DDL + DML)
--1. Listez tous les chats et leurs ma�tres respectifs.
--SELECT 
--    c.* , p.*
--FROM 
--    Chats AS c
--    LEFT JOIN Personne AS p
--    ON c.id_maitre = p.id ;

--2. Affichez toutes les relations entre les chats et les chiens, y compris leurs types de relations.
--SELECT 
--    r.id_chat,
--    c.name,
--    r.relation_type,
--    ch.id,
--    ch.name
--FROM 
--    RelationChatChien AS r
--    INNER JOIN Chats AS c  ON c.id = r.id_chat
--    INNER JOIN Chien AS ch ON ch.id = r.id_chien


--3. Modifiez la relation entre "Garfield" et "Hercules" pour qu'elle devienne `loves`.
--UPDATE RelationChatChien
--SET relation_type = 'loves'
--WHERE id_chat IN 
--                (SELECT id 
--                FROM Chats
--                WHERE name = 'Garfield')
--      AND id_chien IN
--                    (SELECT id
--                     FROM Chien
--                     WHERE name = 'Hercules') ;
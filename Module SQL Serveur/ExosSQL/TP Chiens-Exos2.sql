--## Partie DML : Manipulation des données (INSERT, UPDATE, DELETE, TRUNCATE)

--### Script SQL : Pratique du DML
--Ajoutez, modifiez ou supprimez des enregistrements dans les tables existantes pour renforcer la 
--compréhension des manipulations de données.

-----

--### Questions

--#### Niveau 1 : INSERT
--1. Ajoutez un nouveau maître nommé "Arya Stark", âgé de 18 ans, habitant à "Winterfell", avec un numéro 
--de téléphone "1231231234".
--INSERT INTO Personne (first_name, last_name, age, phone_number, address)
--VALUES ('Arya' , 'Stark' , 18, 1231231234, 'Winterfell');


--2. Insérez un nouveau chien nommé "Nymeria" (race : Loup géant, âge : 3 ans, taille : 120 cm, poids : 60 kg) appartenant à Arya Stark.
--INSERT INTO Chien (name, breed, age, size, weight, id_maitre)
--VALUES ('Nymeria', 'Loup géant', 3, 120, 60, 1002)



--#### Niveau 2 : UPDATE
--3. Modifiez le poids du chien "Milou" pour le mettre à 9 kg.
--UPDATE Chien
--SET weight = 9
--WHERE name = 'Milou'



--4. Changez l'adresse de "Daenerys Targaryen" pour "Dragonstone".
--UPDATE Personne
--SET address = 'Dragonstone'
--WHERE first_name = 'Daenerys'


--5. Mettez à jour tous les chiens sans maître pour les associer à "Sherlock Holmes".
--UPDATE Chien
--SET id_maitre = 3
--WHERE id_maitre IS NULL


--#### Niveau 3 : DELETE
--6. Supprimez tous les chiens pesant moins de 5 kg.
--DELETE FROM Chien
--WHERE weight < 5
--7. Supprimez le maître "Waldo Rosenbaum" et tous les chiens qui lui appartiennent.
--DELETE FROM Personne
--WHERE first_name = 'Waldo'

--DELETE FROM Chien
--WHERE id_maitre = 10

--#### Niveau 4 : TRUNCATE
--8. **Attention :** Effectuez un `TRUNCATE` sur la table `Chien` pour supprimer toutes les données de manière 
-- rapide, puis réinsérez les données initiales. Vérifiez la structure de la table avant et après.
--TRUNCATE TABLE Chien


--INSERT INTO Chien (name, breed, age, size, weight, id_maitre)
--VALUES 
--    ('Milou', 'Fox Terrier', 5, 30.0, 8.0, 1), -- Lié à Tintin Dupont
--    ('Idefix', 'Dogmatix', 4, 25.0, 6.0, 2), -- Lié à Asterix Gaulois
--    ('Watson', 'Bulldog', 6, 60.0, 30.0, 3), -- Lié à Sherlock Holmes
--    ('Hercules', 'Pitbull', 3, 60.0, 28.0, 4), -- Lié à Hercule Poirot
--    ('Gandalf', 'Great Dane', 8, 80.0, 50.0, 5), -- Lié à Gandalf Le Gris
--    ('Chewie', 'Malamute', 7, 70.0, 40.0, 6), -- Lié à Luke Skywalker
--    ('Buck', 'Saint Bernard', 6, 70.0, 50.0, 7), -- Lié à Harry Potter
--    ('Drogo', 'Dobermann', 5, 55.0, 35.0, 8), -- Lié à Daenerys Targaryen
--    ('Baggins', 'Shiba Inu', 4, 30.0, 10.0, 9), -- Lié à Frodo Baggins
----    ('Waldo', 'Chihuahua', 3, 20.0, 2.5, 10), -- Lié à Waldo Rosenbaum
--    ('Rex', 'Chihuahua', 3, 20.0, 3.0, NULL), -- Pas de maître
--    ('Pepette', 'Rottweiler', 6, 60.0, 40.0, NULL), -- Pas de maître
--    ('Princesse', 'Dobermann', 4, 50.0, 30.0, NULL), -- Pas de maître
--    ('Rex', 'Dalmatian', 2, 45.0, 25.0, NULL), -- Pas de maître
--    ('Trixie', 'Poodle', 5, 30.0, 12.0, NULL), -- Pas de maître
--    ('Nina', 'Boxer', 4, 50.0, 35.0, NULL), -- Pas de maître
--    ('Pikachu', 'Corgi', 2, 25.0, 10.0, NULL), -- Pas de maître
--    ('Rolo', 'Dachshund', 3, 28.0, 8.5, NULL), -- Pas de maître
--    ('Fifi', 'Maltese', 4, 25.0, 6.0, NULL), -- Pas de maître
--    ('Charlie', 'Beagle', 6, 40.0, 15.0, NULL), -- Pas de maître
--    ('Max', 'Labrador', 5, 55.0, 30.0, NULL), -- Pas de maître
--    ('Biscuit', 'Shih Tzu', 2, 25.0, 6.0, NULL), -- Pas de maître
--    ('Daisy', 'Pug', 3, 35.0, 10.0, NULL), -- Pas de maître
--    ('Oscar', 'Terrier', 4, 28.0, 8.0, NULL), -- Pas de maître
--    ('Nala', 'Pitbull', 4, 50.0, 30.0, NULL); -- Pas de maître
